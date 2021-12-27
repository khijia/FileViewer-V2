using FileViewer.Model;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;

namespace FileViewer.Utility
{
    public class OAuthHelper
    {
        /// <summary>
        /// The header to use for OAuth authentication.
        /// </summary>
        public const string OAuthHeader = "Authorization";

        /// <summary>
        /// Retrieves an authentication header from the service.
        /// </summary>
        /// <returns>The authentication header for the Web API call.</returns>
        public static string GetAuthenticationHeader(oAuth oAuth)
        {
            string tenant = oAuth.Tenant;
            string appId = oAuth.accountid;
            string clientId = oAuth.ClientId;
            string resource = oAuth.url;

            AuthenticationContext authenticationContext = new AuthenticationContext(tenant, false);
            AuthenticationResult authenticationResult;

            if (string.IsNullOrEmpty(clientId))
            {
                Console.WriteLine("Please fill AAD application secret in ClientConfiguration if you choose authentication by the application.");
                throw new Exception("Failed OAuth by empty application secret.");
            }

            try
            {
                // OAuth through application by application id and application secret.
                var creadential = new ClientCredential(appId, clientId);
                authenticationResult = authenticationContext.AcquireTokenAsync(resource, creadential).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Failed to authenticate with AAD by application with exception {0} and the stack trace {1}", ex.ToString(), ex.StackTrace));
                throw new Exception("Failed to authenticate with AAD by application.");
            }

            // Create and get JWT token
            return authenticationResult.CreateAuthorizationHeader();
        }
        
    }
}
