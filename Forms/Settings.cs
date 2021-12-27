using FileViewer.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileViewer.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            rdBasicAuth.Checked = true;
            LoadSettings();
            ctrlTabSettings.SelectedIndexChanged += CtrlTabSettings_SelectedIndexChanged;
        }

        private void CtrlTabSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tb = (TabControl)sender;
            if (tb.SelectedTab.Name == "tabNS")
            {
                erpLogo.BackgroundImage = Properties.Resources.NetSuite_Logo;
            }
            else if (tb.SelectedTab.Name == "tabD3FO")
            {
                erpLogo.BackgroundImage = Properties.Resources.d3fo_logo;            
            }
            else if (tb.SelectedTab.Name == "tabBC")
            {
                erpLogo.BackgroundImage = Properties.Resources.bc_logo;
            }
        }


        #region Events

        #endregion Events

        private void rdBasicAuth_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void rdOAuth_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = true;
        }

        private void SaveSettings()
        {
            List<DataSetting> settings = new List<DataSetting>();
            //NS Group
            settings.Add(new DataSetting()
            {
                authType = rdBasicAuth.Checked ? AuthType.Basic : AuthType.oAuth,
                erp = Erp.Netsuite,
                url = txtD3FOUrl.Text.Trim(),
                account = txtAccountNS.Text.Trim(),
                basicAuth = new BasicAuth()
                {
                    username = txtUserName.Text.Trim(),
                    password = txtPassword.Text.Trim(),
                    role = txtRole.Text.Trim()==string.Empty?0: int.Parse(txtRole.Text.Trim())
                },
                oAuth = new oAuth()
                {
                    ConsumerKey = txtConsumerNS.Text.Trim(),
                    ConsumerSerect = txtConsumerSerectNS.Text.Trim(),
                    Token = txtTokenNS.Text.Trim(),
                    TokenSerect = txtTokenSerectNS.Text.Trim()
                }
            });
            //D3FO Group
            settings.Add(new DataSetting()
            {
                authType = AuthType.oAuth,
                erp = Erp.D3FO,
                url = txtD3FOUrl.Text.Trim(),
                oAuth = new oAuth()
                {
                    accountid = txtD3FOAppId.Text.Trim(),
                    Tenant= txtD3FOTenant.Text.Trim(),
                    ClientId = txtD3FOClientId.Text.Trim(),
                    ResourceURL=txtD3FOResource.Text.Trim()
                }
            });
            //BC Group
            settings.Add(new DataSetting()
            {
                authType = AuthType.Basic,
                erp = Erp.BC,
                url = txtBCUrl.Text.Trim(),
                basicAuth = new BasicAuth()
                {
                    username = txtBCUserName.Text.Trim(),
                    password = txtBCPassword.Text.Trim()
                }
            });
            SchemaModel.SaveDataSettings(settings);
            MessageBox.Show("Save successful.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
        private void LoadSettings()
        {
            var settings = SchemaModel.LoadDataSettings();
            foreach (var st in settings)
            {
                if (st.erp == Erp.Netsuite)
                {
                    rdBasicAuth.Checked = (st.authType == AuthType.Basic);
                    rdOAuth.Checked = !(st.authType == AuthType.Basic);
                    txtNSUrl.Text = st.url;
                    txtUserName.Text = st.basicAuth.username;
                    txtPassword.Text = st.basicAuth.password;
                    txtRole.Text = st.basicAuth.role.ToString();
                    txtConsumerNS.Text = st.oAuth.ConsumerKey;
                    txtConsumerSerectNS.Text = st.oAuth.ConsumerSerect;
                    txtTokenNS.Text = st.oAuth.Token;
                    txtTokenSerectNS.Text = st.oAuth.TokenSerect;
                    txtAccountNS.Text = st.account;
                }
                if (st.erp == Erp.D3FO)
                {
                    txtD3FOUrl.Text = st.url;
                    txtD3FOTenant.Text = st.oAuth.Tenant;
                    txtD3FOAppId.Text = st.oAuth.accountid;
                    txtD3FOClientId.Text = st.oAuth.ClientId;
                    txtD3FOResource.Text = st.oAuth.ResourceURL;
                }
                if (st.erp == Erp.BC)
                {
                    txtBCUrl.Text = st.url;
                    txtBCUserName.Text = st.basicAuth.username;
                    txtBCPassword.Text = st.basicAuth.password;
                }
            }
        }

        private void btnBCSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btnD3FOSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }
    }
}
