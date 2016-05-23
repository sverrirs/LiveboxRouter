namespace Orange.Livebox
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnClearFirewallBlock = new System.Windows.Forms.Button();
            this.btnApplyFirewallBlock = new System.Windows.Forms.Button();
            this.tbResults = new System.Windows.Forms.TextBox();
            this.btnGetWANStatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnGetFirewallCustomRules = new System.Windows.Forms.Button();
            this.btnGetDeviceInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClearFirewallBlock
            // 
            this.btnClearFirewallBlock.Location = new System.Drawing.Point(25, 143);
            this.btnClearFirewallBlock.Name = "btnClearFirewallBlock";
            this.btnClearFirewallBlock.Size = new System.Drawing.Size(194, 38);
            this.btnClearFirewallBlock.TabIndex = 11;
            this.btnClearFirewallBlock.Text = "Firewall to Medium";
            this.btnClearFirewallBlock.UseVisualStyleBackColor = true;
            this.btnClearFirewallBlock.Click += new System.EventHandler(this.btnClearFirewallBlock_Click);
            // 
            // btnApplyFirewallBlock
            // 
            this.btnApplyFirewallBlock.Location = new System.Drawing.Point(25, 76);
            this.btnApplyFirewallBlock.Name = "btnApplyFirewallBlock";
            this.btnApplyFirewallBlock.Size = new System.Drawing.Size(194, 38);
            this.btnApplyFirewallBlock.TabIndex = 10;
            this.btnApplyFirewallBlock.Text = "Firewall to Custom";
            this.btnApplyFirewallBlock.UseVisualStyleBackColor = true;
            this.btnApplyFirewallBlock.Click += new System.EventHandler(this.btnApplyFirewallBlock_Click);
            // 
            // tbResults
            // 
            this.tbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResults.Location = new System.Drawing.Point(12, 187);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResults.Size = new System.Drawing.Size(704, 357);
            this.tbResults.TabIndex = 14;
            this.tbResults.TabStop = false;
            // 
            // btnGetWANStatus
            // 
            this.btnGetWANStatus.Location = new System.Drawing.Point(236, 76);
            this.btnGetWANStatus.Name = "btnGetWANStatus";
            this.btnGetWANStatus.Size = new System.Drawing.Size(169, 38);
            this.btnGetWANStatus.TabIndex = 12;
            this.btnGetWANStatus.Text = "Get WAN Status";
            this.btnGetWANStatus.UseVisualStyleBackColor = true;
            this.btnGetWANStatus.Click += new System.EventHandler(this.btnGetWANStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(28, 30);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(191, 20);
            this.tbUsername.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(236, 29);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(191, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // btnGetFirewallCustomRules
            // 
            this.btnGetFirewallCustomRules.Location = new System.Drawing.Point(236, 143);
            this.btnGetFirewallCustomRules.Name = "btnGetFirewallCustomRules";
            this.btnGetFirewallCustomRules.Size = new System.Drawing.Size(169, 38);
            this.btnGetFirewallCustomRules.TabIndex = 15;
            this.btnGetFirewallCustomRules.Text = "Get Firewall Rules";
            this.btnGetFirewallCustomRules.UseVisualStyleBackColor = true;
            this.btnGetFirewallCustomRules.Click += new System.EventHandler(this.btnGetFirewallCustomRules_Click);
            // 
            // btnGetDeviceInfo
            // 
            this.btnGetDeviceInfo.Location = new System.Drawing.Point(424, 76);
            this.btnGetDeviceInfo.Name = "btnGetDeviceInfo";
            this.btnGetDeviceInfo.Size = new System.Drawing.Size(181, 38);
            this.btnGetDeviceInfo.TabIndex = 16;
            this.btnGetDeviceInfo.Text = "Get Device Info";
            this.btnGetDeviceInfo.UseVisualStyleBackColor = true;
            this.btnGetDeviceInfo.Click += new System.EventHandler(this.btnGetDeviceInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 556);
            this.Controls.Add(this.btnGetDeviceInfo);
            this.Controls.Add(this.btnGetFirewallCustomRules);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetWANStatus);
            this.Controls.Add(this.tbResults);
            this.Controls.Add(this.btnApplyFirewallBlock);
            this.Controls.Add(this.btnClearFirewallBlock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Orange Livebox Helper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClearFirewallBlock;
        private System.Windows.Forms.Button btnApplyFirewallBlock;
        private System.Windows.Forms.TextBox tbResults;
        private System.Windows.Forms.Button btnGetWANStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnGetFirewallCustomRules;
        private System.Windows.Forms.Button btnGetDeviceInfo;
    }
}

