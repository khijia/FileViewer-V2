
namespace FileViewer.Forms
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.panelForm = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ctrlTabSettings = new System.Windows.Forms.CustomTabControl();
            this.tabNS = new System.Windows.Forms.TabPage();
            this.txtAccountNS = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rdOAuth = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.rdBasicAuth = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTokenSerectNS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTokenNS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConsumerSerectNS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConsumerNS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNSUrl = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabD3FO = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtD3FOClientId = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtD3FOAppId = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtD3FOTenant = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtD3FOUrl = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabBC = new System.Windows.Forms.TabPage();
            this.btnBCSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBCPassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBCUrl = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBCUserName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.erpLogo = new System.Windows.Forms.PictureBox();
            this.btnD3FOSave = new System.Windows.Forms.Button();
            this.txtD3FOResource = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panelForm.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.ctrlTabSettings.SuspendLayout();
            this.tabNS.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabD3FO.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabBC.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.Controls.Add(this.pnlContent);
            this.panelForm.Controls.Add(this.pnlHeader);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(688, 529);
            this.panelForm.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.ctrlTabSettings);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlContent.Location = new System.Drawing.Point(0, 84);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(688, 444);
            this.pnlContent.TabIndex = 1;
            // 
            // ctrlTabSettings
            // 
            this.ctrlTabSettings.AllowDrop = true;
            this.ctrlTabSettings.Controls.Add(this.tabNS);
            this.ctrlTabSettings.Controls.Add(this.tabD3FO);
            this.ctrlTabSettings.Controls.Add(this.tabBC);
            this.ctrlTabSettings.DisplayStyle = System.Windows.Forms.TabStyle.IE8;
            // 
            // 
            // 
            this.ctrlTabSettings.DisplayStyleProvider.BorderColor = System.Drawing.Color.Gainsboro;
            this.ctrlTabSettings.DisplayStyleProvider.BorderColorHot = System.Drawing.SystemColors.ControlDark;
            this.ctrlTabSettings.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.DarkGray;
            this.ctrlTabSettings.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.ctrlTabSettings.DisplayStyleProvider.CloserColorActive = System.Drawing.Color.Red;
            this.ctrlTabSettings.DisplayStyleProvider.FocusColor = System.Drawing.Color.DarkSeaGreen;
            this.ctrlTabSettings.DisplayStyleProvider.FocusTrack = false;
            this.ctrlTabSettings.DisplayStyleProvider.HotTrack = true;
            this.ctrlTabSettings.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ctrlTabSettings.DisplayStyleProvider.Opacity = 1F;
            this.ctrlTabSettings.DisplayStyleProvider.Overlap = 0;
            this.ctrlTabSettings.DisplayStyleProvider.Padding = new System.Drawing.Point(0, 0);
            this.ctrlTabSettings.DisplayStyleProvider.Radius = 3;
            this.ctrlTabSettings.DisplayStyleProvider.ShowTabCloser = false;
            this.ctrlTabSettings.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.ctrlTabSettings.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.ctrlTabSettings.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.ctrlTabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTabSettings.HotTrack = true;
            this.ctrlTabSettings.ItemSize = new System.Drawing.Size(60, 16);
            this.ctrlTabSettings.Location = new System.Drawing.Point(0, 0);
            this.ctrlTabSettings.Name = "ctrlTabSettings";
            this.ctrlTabSettings.SelectedIndex = 0;
            this.ctrlTabSettings.Size = new System.Drawing.Size(688, 444);
            this.ctrlTabSettings.TabIndex = 10;
            // 
            // tabNS
            // 
            this.tabNS.Controls.Add(this.txtAccountNS);
            this.tabNS.Controls.Add(this.label9);
            this.tabNS.Controls.Add(this.rdOAuth);
            this.tabNS.Controls.Add(this.btnSave);
            this.tabNS.Controls.Add(this.rdBasicAuth);
            this.tabNS.Controls.Add(this.groupBox2);
            this.tabNS.Controls.Add(this.groupBox1);
            this.tabNS.Controls.Add(this.txtNSUrl);
            this.tabNS.Controls.Add(this.label8);
            this.tabNS.Location = new System.Drawing.Point(4, 21);
            this.tabNS.Name = "tabNS";
            this.tabNS.Padding = new System.Windows.Forms.Padding(3);
            this.tabNS.Size = new System.Drawing.Size(680, 419);
            this.tabNS.TabIndex = 0;
            this.tabNS.Text = "Netsuite";
            this.tabNS.UseVisualStyleBackColor = true;
            // 
            // txtAccountNS
            // 
            this.txtAccountNS.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtAccountNS.Location = new System.Drawing.Point(206, 51);
            this.txtAccountNS.Name = "txtAccountNS";
            this.txtAccountNS.Size = new System.Drawing.Size(230, 20);
            this.txtAccountNS.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(139, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Account";
            // 
            // rdOAuth
            // 
            this.rdOAuth.AutoSize = true;
            this.rdOAuth.ForeColor = System.Drawing.Color.DarkCyan;
            this.rdOAuth.Location = new System.Drawing.Point(75, 218);
            this.rdOAuth.Name = "rdOAuth";
            this.rdOAuth.Size = new System.Drawing.Size(55, 17);
            this.rdOAuth.TabIndex = 20;
            this.rdOAuth.TabStop = true;
            this.rdOAuth.Text = "OAuth";
            this.rdOAuth.UseVisualStyleBackColor = true;
            this.rdOAuth.CheckedChanged += new System.EventHandler(this.rdOAuth_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSave.Location = new System.Drawing.Point(278, 385);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 28);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rdBasicAuth
            // 
            this.rdBasicAuth.AutoSize = true;
            this.rdBasicAuth.ForeColor = System.Drawing.Color.DarkCyan;
            this.rdBasicAuth.Location = new System.Drawing.Point(75, 79);
            this.rdBasicAuth.Name = "rdBasicAuth";
            this.rdBasicAuth.Size = new System.Drawing.Size(122, 17);
            this.rdBasicAuth.TabIndex = 20;
            this.rdBasicAuth.TabStop = true;
            this.rdBasicAuth.Text = "Basic Authentication";
            this.rdBasicAuth.UseVisualStyleBackColor = true;
            this.rdBasicAuth.CheckedChanged += new System.EventHandler(this.rdBasicAuth_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTokenSerectNS);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTokenNS);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtConsumerSerectNS);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtConsumerNS);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(104, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 149);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // txtTokenSerectNS
            // 
            this.txtTokenSerectNS.Location = new System.Drawing.Point(97, 107);
            this.txtTokenSerectNS.Name = "txtTokenSerectNS";
            this.txtTokenSerectNS.Size = new System.Drawing.Size(374, 20);
            this.txtTokenSerectNS.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(19, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Token Serect";
            // 
            // txtTokenNS
            // 
            this.txtTokenNS.Location = new System.Drawing.Point(97, 81);
            this.txtTokenNS.Name = "txtTokenNS";
            this.txtTokenNS.Size = new System.Drawing.Size(374, 20);
            this.txtTokenNS.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(50, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Token";
            // 
            // txtConsumerSerectNS
            // 
            this.txtConsumerSerectNS.Location = new System.Drawing.Point(97, 55);
            this.txtConsumerSerectNS.Name = "txtConsumerSerectNS";
            this.txtConsumerSerectNS.Size = new System.Drawing.Size(374, 20);
            this.txtConsumerSerectNS.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(3, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Consumer Serect";
            // 
            // txtConsumerNS
            // 
            this.txtConsumerNS.Location = new System.Drawing.Point(97, 29);
            this.txtConsumerNS.Name = "txtConsumerNS";
            this.txtConsumerNS.Size = new System.Drawing.Size(374, 20);
            this.txtConsumerNS.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(37, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Consumer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRole);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Coral;
            this.groupBox1.Location = new System.Drawing.Point(104, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 111);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // txtRole
            // 
            this.txtRole.Location = new System.Drawing.Point(97, 74);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(235, 20);
            this.txtRole.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(58, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Role";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(97, 48);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(235, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(35, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(97, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(235, 20);
            this.txtUserName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(28, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "User Name";
            // 
            // txtNSUrl
            // 
            this.txtNSUrl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNSUrl.Location = new System.Drawing.Point(206, 25);
            this.txtNSUrl.Name = "txtNSUrl";
            this.txtNSUrl.Size = new System.Drawing.Size(380, 20);
            this.txtNSUrl.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label8.Location = new System.Drawing.Point(126, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Restlet URL";
            // 
            // tabD3FO
            // 
            this.tabD3FO.Controls.Add(this.btnD3FOSave);
            this.tabD3FO.Controls.Add(this.groupBox4);
            this.tabD3FO.Location = new System.Drawing.Point(4, 21);
            this.tabD3FO.Name = "tabD3FO";
            this.tabD3FO.Padding = new System.Windows.Forms.Padding(3);
            this.tabD3FO.Size = new System.Drawing.Size(680, 419);
            this.tabD3FO.TabIndex = 1;
            this.tabD3FO.Text = "D3FO";
            this.tabD3FO.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtD3FOClientId);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.txtD3FOAppId);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.txtD3FOTenant);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtD3FOResource);
            this.groupBox4.Controls.Add(this.txtD3FOUrl);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.ForeColor = System.Drawing.Color.Coral;
            this.groupBox4.Location = new System.Drawing.Point(6, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(664, 194);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            // 
            // txtD3FOClientId
            // 
            this.txtD3FOClientId.Location = new System.Drawing.Point(102, 123);
            this.txtD3FOClientId.Name = "txtD3FOClientId";
            this.txtD3FOClientId.Size = new System.Drawing.Size(556, 20);
            this.txtD3FOClientId.TabIndex = 5;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label17.Location = new System.Drawing.Point(51, 126);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Client Id";
            // 
            // txtD3FOAppId
            // 
            this.txtD3FOAppId.Location = new System.Drawing.Point(102, 97);
            this.txtD3FOAppId.Name = "txtD3FOAppId";
            this.txtD3FOAppId.Size = new System.Drawing.Size(556, 20);
            this.txtD3FOAppId.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label16.Location = new System.Drawing.Point(25, 100);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Application Id";
            // 
            // txtD3FOTenant
            // 
            this.txtD3FOTenant.Location = new System.Drawing.Point(102, 71);
            this.txtD3FOTenant.Name = "txtD3FOTenant";
            this.txtD3FOTenant.Size = new System.Drawing.Size(556, 20);
            this.txtD3FOTenant.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(67, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "URL";
            // 
            // txtD3FOUrl
            // 
            this.txtD3FOUrl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtD3FOUrl.Location = new System.Drawing.Point(102, 19);
            this.txtD3FOUrl.Name = "txtD3FOUrl";
            this.txtD3FOUrl.Size = new System.Drawing.Size(556, 20);
            this.txtD3FOUrl.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(55, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Tenant";
            // 
            // tabBC
            // 
            this.tabBC.Controls.Add(this.btnBCSave);
            this.tabBC.Controls.Add(this.groupBox3);
            this.tabBC.Location = new System.Drawing.Point(4, 21);
            this.tabBC.Name = "tabBC";
            this.tabBC.Padding = new System.Windows.Forms.Padding(3);
            this.tabBC.Size = new System.Drawing.Size(680, 419);
            this.tabBC.TabIndex = 2;
            this.tabBC.Text = "BC";
            this.tabBC.UseVisualStyleBackColor = true;
            // 
            // btnBCSave
            // 
            this.btnBCSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBCSave.BackColor = System.Drawing.Color.Transparent;
            this.btnBCSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBCSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBCSave.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBCSave.Location = new System.Drawing.Point(278, 385);
            this.btnBCSave.Name = "btnBCSave";
            this.btnBCSave.Size = new System.Drawing.Size(85, 28);
            this.btnBCSave.TabIndex = 4;
            this.btnBCSave.Text = "Save";
            this.btnBCSave.UseVisualStyleBackColor = false;
            this.btnBCSave.Click += new System.EventHandler(this.btnBCSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBCPassword);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtBCUrl);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtBCUserName);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.ForeColor = System.Drawing.Color.Coral;
            this.groupBox3.Location = new System.Drawing.Point(6, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(664, 112);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // txtBCPassword
            // 
            this.txtBCPassword.Location = new System.Drawing.Point(102, 71);
            this.txtBCPassword.Name = "txtBCPassword";
            this.txtBCPassword.PasswordChar = '*';
            this.txtBCPassword.Size = new System.Drawing.Size(235, 20);
            this.txtBCPassword.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label14.Location = new System.Drawing.Point(31, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Restlet URL";
            // 
            // txtBCUrl
            // 
            this.txtBCUrl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtBCUrl.Location = new System.Drawing.Point(102, 19);
            this.txtBCUrl.Name = "txtBCUrl";
            this.txtBCUrl.Size = new System.Drawing.Size(556, 20);
            this.txtBCUrl.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label12.Location = new System.Drawing.Point(43, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Password";
            // 
            // txtBCUserName
            // 
            this.txtBCUserName.Location = new System.Drawing.Point(102, 45);
            this.txtBCUserName.Name = "txtBCUserName";
            this.txtBCUserName.Size = new System.Drawing.Size(235, 20);
            this.txtBCUserName.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label13.Location = new System.Drawing.Point(36, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "User Name";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.erpLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(688, 84);
            this.pnlHeader.TabIndex = 0;
            // 
            // erpLogo
            // 
            this.erpLogo.BackgroundImage = global::FileViewer.Properties.Resources.NetSuite_Logo;
            this.erpLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.erpLogo.Location = new System.Drawing.Point(0, 3);
            this.erpLogo.Name = "erpLogo";
            this.erpLogo.Size = new System.Drawing.Size(201, 81);
            this.erpLogo.TabIndex = 21;
            this.erpLogo.TabStop = false;
            // 
            // btnD3FOSave
            // 
            this.btnD3FOSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnD3FOSave.BackColor = System.Drawing.Color.Transparent;
            this.btnD3FOSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnD3FOSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnD3FOSave.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnD3FOSave.Location = new System.Drawing.Point(278, 385);
            this.btnD3FOSave.Name = "btnD3FOSave";
            this.btnD3FOSave.Size = new System.Drawing.Size(85, 28);
            this.btnD3FOSave.TabIndex = 6;
            this.btnD3FOSave.Text = "Save";
            this.btnD3FOSave.UseVisualStyleBackColor = false;
            this.btnD3FOSave.Click += new System.EventHandler(this.btnD3FOSave_Click);
            // 
            // txtD3FOResource
            // 
            this.txtD3FOResource.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtD3FOResource.Location = new System.Drawing.Point(102, 45);
            this.txtD3FOResource.Name = "txtD3FOResource";
            this.txtD3FOResource.Size = new System.Drawing.Size(556, 20);
            this.txtD3FOResource.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label15.Location = new System.Drawing.Point(43, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Resource";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(688, 529);
            this.Controls.Add(this.panelForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panelForm.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ctrlTabSettings.ResumeLayout(false);
            this.tabNS.ResumeLayout(false);
            this.tabNS.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabD3FO.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabBC.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.erpLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.CustomTabControl ctrlTabSettings;
        private System.Windows.Forms.TabPage tabNS;
        private System.Windows.Forms.TabPage tabBC;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabD3FO;
        private System.Windows.Forms.PictureBox erpLogo;
        private System.Windows.Forms.RadioButton rdOAuth;
        private System.Windows.Forms.RadioButton rdBasicAuth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTokenSerectNS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTokenNS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConsumerSerectNS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConsumerNS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNSUrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAccountNS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBCPassword;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBCUrl;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBCUserName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnBCSave;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtD3FOClientId;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtD3FOAppId;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtD3FOTenant;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtD3FOUrl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnD3FOSave;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtD3FOResource;
    }
}