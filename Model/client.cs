using D3FOUploadService;
using FileViewer.Utility;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FileViewer.Model
{
    public static class client
    {
        public static async Task<IRestResponse> PostAsync(BasicAuth header, string body)
        {
            var restClient = new RestClient(header.url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Authorization", $"NLAuth nlauth_account={header.accountid}, nlauth_email={header.username}, nlauth_signature={header.password},nlauth_role={header.role}");
            request.AddParameter("application/xml", body, ParameterType.RequestBody);
            return await restClient.ExecuteAsync(request);
        }

        public static IRestResponse PostAuthor(BasicAuth header, string body)
        {
            var restClient = new RestClient(header.url);

            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "text/plain");
            request.AddHeader("Authorization", $"NLAuth nlauth_account={header.accountid}, nlauth_email={header.username}, nlauth_signature={header.password},nlauth_role={header.role}");
            request.AddParameter("application/xml", body, ParameterType.RequestBody);
            return restClient.Execute(request);
        }
        public static IRestResponse PostBasic(BasicAuth header, string body)
        {
            var restClient = new RestClient(header.url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            var authenticator = new HttpBasicAuthenticator(header.username, header.password);
            restClient.Authenticator = authenticator;
            return restClient.Execute(request);
        }

        public static IRestResponse Post(oAuth header, string body)
        {
            Uri myUri = new Uri(header.url);
            var authticator = OAuth1Authenticator.ForAccessToken(
                header.ConsumerKey,
                header.ConsumerSerect,
                header.Token,
                header.TokenSerect,
                RestSharp.Authenticators.OAuth.OAuthSignatureMethod.HmacSha256
                );
            authticator.Realm = header.accountid;
            var restClient = new RestClient(myUri.AbsoluteUri.Replace(myUri.Query, ""));
            restClient.Authenticator = authticator;
            var paras = HttpUtility.ParseQueryString(myUri.Query);
            foreach (var p in paras.AllKeys)
            {
                restClient.AddDefaultQueryParameter(p, paras.Get(p));
            }
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "text/plain");
            request.AddParameter("application/xml", body, ParameterType.RequestBody);
            return restClient.Execute(request);
        }
        public static UploadDocResponse PostSoapService(oAuth header, string body)
        {
            var serviceUriString = SoapHelper.GetSoapServiceUriString("EISUploadWebService", header.url);
            var endpointAddress = new EndpointAddress(serviceUriString);
            var binding = SoapHelper.GetBinding();
            var eisClient = new EISUploadServiceClient(binding, endpointAddress);
            var channel = eisClient.InnerChannel;
            using (OperationContextScope operationContextScope = new OperationContextScope(channel))
            {
                //Get token
                HttpRequestMessageProperty requestMessage = new HttpRequestMessageProperty();
                requestMessage.Headers[OAuthHelper.OAuthHeader] = OAuthHelper.GetAuthenticationHeader(header);
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessage;
                UploadDoc upload = new UploadDoc();
                upload.diWS_ID = DateTime.Now.ToString("yyyyMMddhhmmss");
                upload.CallContext = new CallContext() { Company = "" };
                upload.l = body.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                return ((EISUploadService)channel).UploadDoc(upload);
            }
        }
        public static string PostSoapService2(BasicAuth header, string body)
        {
            var endpointAddress = new EndpointAddress(header.url);
            var binding = SoapHelper.GetBinding();
            var eisClient = new BCUploadService.EISUploadWebService2_PortClient(binding, endpointAddress);
            eisClient.ClientCredentials.UserName.UserName = header.username;
            eisClient.ClientCredentials.UserName.Password = header.password;
            using (OperationContextScope operationContextScope = new OperationContextScope(eisClient.InnerChannel))
            {
                HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
                httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{header.username }:{header.password}"));
                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
                return eisClient.UploadDoc(DateTime.Now.ToString("yyyyMMddhhmmss"), body);
            }
        }
        public static string AccessTokenGenerator(oAuth header)
        {
            string clientId = header.accountid;
            string clientSecret = header.ClientId; // Client secret generated in your App  
            string authority = header.Tenant; // Azure AD App Tenant ID  
            string resourceUrl = header.ResourceURL; // Your Dynamics 365 Organization URL  
            var credentials = new ClientCredential(clientId, clientSecret);
            var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authority);
            var result = authContext.AcquireTokenAsync(resourceUrl, credentials);
            return result.Result.AccessToken;
        }
        
    }

    public class ExportParams
    {
        public Erp erp { get; set; }
        public Auth auth { get; set; }
    }

    public class Auth
    {
        public string accountid { get; set; }
        public string url { get; set; }
    }
    public class BasicAuth : Auth
    {
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; } = 0;
    }
    public class oAuth : Auth
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSerect { get; set; }
        public string Token { get; set; }
        public string TokenSerect { get; set; }
        public string ClientId { get; set; }
        public string Tenant { get; set; }
        public string ResourceURL { get; set; }

    }

    public enum AuthType
    {
        Basic,
        oAuth
    }

    public enum Erp
    {
        Netsuite,
        D3FO,
        BC
    }    
}
