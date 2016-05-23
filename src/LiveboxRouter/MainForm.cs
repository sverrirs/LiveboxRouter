using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orange.Livebox.Properties;

namespace Orange.Livebox
{
    public partial class MainForm : Form
    {
        private TaskScheduler _uiScheduler;

        public MainForm()
        {
            InitializeComponent();

            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Upgrade the settings if needed
            Settings.Default.Upgrade();

            // Append the version number to the form title
            var version = typeof(MainForm).Assembly.GetName().Version;
            if (version != null)
                this.Text += $" | v{version}";

            // Apply the saved values to the form
            tbUsername.Text = Settings.Default.Username;
            tbPassword.Text = Settings.Default.Password;
        }

        private LiveboxAdapter CreateLiveboxAdapter()
        {
            var username = tbUsername.Text;
            var password = tbPassword.Text;
            
            // Save the values in the user settings
            Settings.Default.Username = username;
            Settings.Default.Password = password;
            Settings.Default.Save();

            return new LiveboxAdapter(username, password);
        }
        
        private void btnClearFirewallBlock_Click(object sender, EventArgs e)
        {
            tbResults.Text = "Setting Firewall to Medium";

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.SetFirewallToMedium().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (!res.Status.GetValueOrDefault())
                    {
                        tbResults.Text = "Error: " + res.Errors.First().Description;
                    }
                    else
                    {
                        tbResults.Text = "Success: " + res.Status;
                    }
                }, _uiScheduler);
                
            });
        }

        private void btnApplyFirewallBlock_Click(object sender, EventArgs e)
        {
            tbResults.Text = "Setting Firewall to Custom";

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.SetFirewallToCustom().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (!res.Status.GetValueOrDefault())
                    {
                        tbResults.Text = "Error: " + res.Errors.First().Description;
                    }
                    else
                    {
                        tbResults.Text = "Success: " + res.Status;
                    }
                }, _uiScheduler);

            });
        }

        private void btnGetWANStatus_Click(object sender, EventArgs e)
        {
            tbResults.Text = "Getting NETWORK status";

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.GetNetworkStatus().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (res == null)
                    {
                        tbResults.Text = "Error: NO data returned";
                    }
                    else
                    {
                        tbResults.Text = "Success: " + res.ConnectionState + " : "+res.IPAddress + " : "+res.LinkState;
                    }
                }, _uiScheduler);

            });
        }

        private void btnGetFirewallCustomRules_Click(object sender, EventArgs e)
        {
            tbResults.Text = "Getting FIREWALL rules";

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.GetFirewallCustomRules().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (res == null || res.Length <= 0)
                    {
                        tbResults.Text = "Error: NO data returned";
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var rule in res)
                        {
                            sb.AppendLine(rule.Name + " [" + rule.Enable +"]: " + rule.Target + " Protocol={"+rule.Protocol+"}");
                        }
                        tbResults.Text = sb.ToString();
                    }
                }, _uiScheduler);
            });
        }

        private void btnGetDeviceInfo_Click(object sender, EventArgs e)
        {
            tbResults.Text = "Getting Device INFO";

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.GetDeviceInfo().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (res == null )
                    {
                        tbResults.Text = "Error: No data returned";
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var p in res.Parameters)
                            sb.AppendLine(p.Name + ": " + p.Value);

                        tbResults.Text = sb.ToString();
                    }
                }, _uiScheduler);
            });
        }
    }
}
