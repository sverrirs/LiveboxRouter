using System.Windows.Forms;

namespace Orange.Livebox
{
    partial class MainForm : Form
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
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFirewallBlockDisable = new System.Windows.Forms.Button();
            this.btnFirewallBlockEnable = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFirewallBlockDisabled = new System.Windows.Forms.Label();
            this.lblFirewallBlockEnabled = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearFirewallBlock
            // 
            this.btnClearFirewallBlock.Location = new System.Drawing.Point(3, 47);
            this.btnClearFirewallBlock.Name = "btnClearFirewallBlock";
            this.btnClearFirewallBlock.Size = new System.Drawing.Size(149, 38);
            this.btnClearFirewallBlock.TabIndex = 11;
            this.btnClearFirewallBlock.Text = "Firewall to Medium";
            this.btnClearFirewallBlock.UseVisualStyleBackColor = true;
            this.btnClearFirewallBlock.Click += new System.EventHandler(this.btnClearFirewallBlock_Click);
            // 
            // btnApplyFirewallBlock
            // 
            this.btnApplyFirewallBlock.Location = new System.Drawing.Point(3, 3);
            this.btnApplyFirewallBlock.Name = "btnApplyFirewallBlock";
            this.btnApplyFirewallBlock.Size = new System.Drawing.Size(149, 38);
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
            this.tbResults.Location = new System.Drawing.Point(3, 95);
            this.tbResults.Multiline = true;
            this.tbResults.Name = "tbResults";
            this.tbResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbResults.Size = new System.Drawing.Size(427, 360);
            this.tbResults.TabIndex = 14;
            this.tbResults.TabStop = false;
            // 
            // btnGetWANStatus
            // 
            this.btnGetWANStatus.Location = new System.Drawing.Point(158, 3);
            this.btnGetWANStatus.Name = "btnGetWANStatus";
            this.btnGetWANStatus.Size = new System.Drawing.Size(124, 38);
            this.btnGetWANStatus.TabIndex = 12;
            this.btnGetWANStatus.Text = "Get WAN Status";
            this.btnGetWANStatus.UseVisualStyleBackColor = true;
            this.btnGetWANStatus.Click += new System.EventHandler(this.btnGetWANStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(12, 25);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(151, 20);
            this.tbUsername.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(174, 25);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(168, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // btnGetFirewallCustomRules
            // 
            this.btnGetFirewallCustomRules.Location = new System.Drawing.Point(158, 47);
            this.btnGetFirewallCustomRules.Name = "btnGetFirewallCustomRules";
            this.btnGetFirewallCustomRules.Size = new System.Drawing.Size(124, 38);
            this.btnGetFirewallCustomRules.TabIndex = 15;
            this.btnGetFirewallCustomRules.Text = "Get Firewall Rules";
            this.btnGetFirewallCustomRules.UseVisualStyleBackColor = true;
            this.btnGetFirewallCustomRules.Click += new System.EventHandler(this.btnGetFirewallCustomRules_Click);
            // 
            // btnGetDeviceInfo
            // 
            this.btnGetDeviceInfo.Location = new System.Drawing.Point(288, 3);
            this.btnGetDeviceInfo.Name = "btnGetDeviceInfo";
            this.btnGetDeviceInfo.Size = new System.Drawing.Size(136, 38);
            this.btnGetDeviceInfo.TabIndex = 16;
            this.btnGetDeviceInfo.Text = "Get Device Info";
            this.btnGetDeviceInfo.UseVisualStyleBackColor = true;
            this.btnGetDeviceInfo.Click += new System.EventHandler(this.btnGetDeviceInfo_Click);
            // 
            // scMain
            // 
            this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scMain.Location = new System.Drawing.Point(9, 51);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.btnApplyFirewallBlock);
            this.scMain.Panel1.Controls.Add(this.btnGetDeviceInfo);
            this.scMain.Panel1.Controls.Add(this.btnGetWANStatus);
            this.scMain.Panel1.Controls.Add(this.btnClearFirewallBlock);
            this.scMain.Panel1.Controls.Add(this.btnGetFirewallCustomRules);
            this.scMain.Panel1Collapsed = true;
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.scMain.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.scMain.Panel2.Controls.Add(this.tbResults);
            this.scMain.Size = new System.Drawing.Size(433, 458);
            this.scMain.SplitterDistance = 90;
            this.scMain.TabIndex = 17;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.btnFirewallBlockDisable);
            this.flowLayoutPanel2.Controls.Add(this.btnFirewallBlockEnable);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 32);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(433, 57);
            this.flowLayoutPanel2.TabIndex = 17;
            // 
            // btnFirewallBlockDisable
            // 
            this.btnFirewallBlockDisable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnFirewallBlockDisable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallBlockDisable.Location = new System.Drawing.Point(3, 3);
            this.btnFirewallBlockDisable.Name = "btnFirewallBlockDisable";
            this.btnFirewallBlockDisable.Size = new System.Drawing.Size(208, 50);
            this.btnFirewallBlockDisable.TabIndex = 15;
            this.btnFirewallBlockDisable.Text = "Disable Block";
            this.btnFirewallBlockDisable.UseVisualStyleBackColor = false;
            this.btnFirewallBlockDisable.Click += new System.EventHandler(this.btnFirewallBlockDisable_Click);
            // 
            // btnFirewallBlockEnable
            // 
            this.btnFirewallBlockEnable.BackColor = System.Drawing.Color.Red;
            this.btnFirewallBlockEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirewallBlockEnable.Location = new System.Drawing.Point(217, 3);
            this.btnFirewallBlockEnable.Name = "btnFirewallBlockEnable";
            this.btnFirewallBlockEnable.Size = new System.Drawing.Size(208, 50);
            this.btnFirewallBlockEnable.TabIndex = 15;
            this.btnFirewallBlockEnable.Text = "Enable Block";
            this.btnFirewallBlockEnable.UseVisualStyleBackColor = false;
            this.btnFirewallBlockEnable.Click += new System.EventHandler(this.btnFirewallBlockEnable_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.lblFirewallBlockDisabled);
            this.flowLayoutPanel1.Controls.Add(this.lblFirewallBlockEnabled);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(433, 26);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Firewall Status:";
            // 
            // lblFirewallBlockDisabled
            // 
            this.lblFirewallBlockDisabled.AutoSize = true;
            this.lblFirewallBlockDisabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirewallBlockDisabled.ForeColor = System.Drawing.Color.Green;
            this.lblFirewallBlockDisabled.Location = new System.Drawing.Point(144, 0);
            this.lblFirewallBlockDisabled.Name = "lblFirewallBlockDisabled";
            this.lblFirewallBlockDisabled.Size = new System.Drawing.Size(71, 24);
            this.lblFirewallBlockDisabled.TabIndex = 1;
            this.lblFirewallBlockDisabled.Text = "Normal";
            // 
            // lblFirewallBlockEnabled
            // 
            this.lblFirewallBlockEnabled.AutoSize = true;
            this.lblFirewallBlockEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirewallBlockEnabled.ForeColor = System.Drawing.Color.Red;
            this.lblFirewallBlockEnabled.Location = new System.Drawing.Point(221, 0);
            this.lblFirewallBlockEnabled.Name = "lblFirewallBlockEnabled";
            this.lblFirewallBlockEnabled.Size = new System.Drawing.Size(112, 24);
            this.lblFirewallBlockEnabled.TabIndex = 2;
            this.lblFirewallBlockEnabled.Text = "Block Active";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(348, 23);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(88, 23);
            this.btnConnect.TabIndex = 18;
            this.btnConnect.Text = "Connect >>";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 517);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(464, 38);
            this.Name = "MainForm";
            this.Text = "Orange Livebox Helper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Button btnFirewallBlockDisable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFirewallBlockDisabled;
        private System.Windows.Forms.Label lblFirewallBlockEnabled;
        private System.Windows.Forms.Button btnFirewallBlockEnable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Button btnConnect;
    }
}

