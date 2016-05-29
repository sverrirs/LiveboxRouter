using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orange.Livebox.json;
using Orange.Livebox.Properties;

namespace Orange.Livebox
{
    public partial class MainForm : Form
    {
        private TaskScheduler _uiScheduler;
        private DeviceInfoResult _deviceInfo;
        private WANData _WANInfo;
        private string _currentFirewallLevel;

        public string CurrentFirewallLevel
        {
            get { return _currentFirewallLevel; }
            set
            {
                _currentFirewallLevel = value;

                // Hide both labels and buttons
                lblFirewallBlockEnabled.Visible = lblFirewallBlockDisabled.Visible = false;
                btnFirewallBlockDisable.Visible = btnFirewallBlockEnable.Visible = false;

                if ("custom".Equals(_currentFirewallLevel, StringComparison.OrdinalIgnoreCase))
                {
                    lblFirewallBlockEnabled.Visible = true;
                    btnFirewallBlockDisable.Visible = true;
                }
                else
                {
                    lblFirewallBlockDisabled.Visible = true;
                    btnFirewallBlockEnable.Visible = true;
                }
            }
        }


        public MainForm()
        {
            InitializeComponent();
            _uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            scMain.Enabled = false;
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

            // Initialize the program
            InitializeForm();
        }

        private void Log(string message)
        {
            tbResults.Text += message + Environment.NewLine;
        }

        private void InitializeForm()
        {
            LiveboxAdapter a = CreateLiveboxAdapter();
            if (a == null)
                return;
            
            Log("Connecting to Livebox Router at "+a.Origin );
            scMain.Enabled = true;

            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.GetDeviceInfo().OnSuccess((t2, o2) =>
                {
                    _deviceInfo = t2.Result;
                    if (_deviceInfo == null)
                    {
                        Log("Error: No Device info data returned");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var p in _deviceInfo.Parameters)
                            sb.AppendLine(p.Name + ": " + p.Value);

                        Log("Device info:");
                        Log(sb.ToString());
                    }
                }, _uiScheduler);

                a.GetNetworkStatus().OnSuccess((t2, o2) =>
                {
                    _WANInfo = t2.Result;
                    if (_WANInfo == null)
                    {
                        Log("Error: No Network information found");
                    }
                    else
                    {
                        Log("Network: ");
                        Log(_WANInfo.ConnectionState 
                                + " : " + _WANInfo.IPAddress 
                                + " : " + _WANInfo.LinkState);
                    }
                }, _uiScheduler);

                a.GetFirewallLevel().OnSuccess(GetFirewallLevelSuccessHandler(), _uiScheduler);
            });
        }

        private Action<Task<StringResult>, object> GetFirewallLevelSuccessHandler()
        {
            return (t2, o2) =>
            {
                CurrentFirewallLevel = t2.Result.Status;
                if (string.IsNullOrEmpty(CurrentFirewallLevel))
                {
                    Log("Error: No Firewall level information found");
                }
                else
                {
                    Log("Firewall Level: " + CurrentFirewallLevel);
                }
            };
        }


        private LiveboxAdapter CreateLiveboxAdapter()
        {
            var username = tbUsername.Text;
            var password = tbPassword.Text;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                return null;
            
            // Save the values in the user settings
            Settings.Default.Username = username;
            Settings.Default.Password = password;
            Settings.Default.Save();

            return new LiveboxAdapter(username, password);
        }
        
        private void btnClearFirewallBlock_Click(object sender, EventArgs e)
        {
            Log("Setting Firewall to Medium");

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.SetFirewallToMedium().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (!res.Status.GetValueOrDefault())
                    {
                        Log("Error: " + res.Errors.First().Description);
                    }
                    else
                    {
                        Log("Success: " + res.Status);
                    }
                }, _uiScheduler);
            });
        }

        private void btnApplyFirewallBlock_Click(object sender, EventArgs e)
        {
            Log("Setting Firewall to Custom");

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.SetFirewallToCustom().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (!res.Status.GetValueOrDefault())
                    {
                        Log("Error: " + res.Errors.First().Description);
                    }
                    else
                    {
                        Log("Success: " + res.Status);
                    }
                }, _uiScheduler);

            });
        }

        private void btnGetWANStatus_Click(object sender, EventArgs e)
        {
            Log("Getting NETWORK status");

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.GetNetworkStatus().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (res == null)
                    {
                        Log("Error: NO data returned");
                    }
                    else
                    {
                        Log("Success: " + res.ConnectionState + " : "+res.IPAddress + " : "+res.LinkState);
                    }
                }, _uiScheduler);

            });
        }

        private void btnGetFirewallCustomRules_Click(object sender, EventArgs e)
        {
            Log("Getting FIREWALL rules");

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.GetFirewallCustomRules().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (res == null || res.Length <= 0)
                    {
                        Log("Error: NO data returned");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var rule in res)
                        {
                            sb.AppendLine(rule.Id + " [" + rule.Enable +"]: " + rule.Target + " Protocol={"+rule.Protocol+"}");
                        }
                        Log(sb.ToString());
                    }
                }, _uiScheduler);
            });
        }

        private void btnGetDeviceInfo_Click(object sender, EventArgs e)
        {
            Log("Getting Device INFO");

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.GetDeviceInfo().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (res == null )
                    {
                        Log("Error: No data returned");
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var p in res.Parameters)
                            sb.AppendLine(p.Name + ": " + p.Value);

                        Log(sb.ToString());
                    }
                }, _uiScheduler);
            });
        }

        private void btnFirewallBlockEnable_Click(object sender, EventArgs e)
        {
            Log("Loading firewall rules from file 'ipblock.csv'");
            var rules = ReadFirewallRules();
            Log(rules.Length + " rules found");

            Log("Enabling Firewall Block");
            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.SetFirewallToCustom(rules).OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (!res.Status.GetValueOrDefault())
                    {
                        Log("Could not ENABLE firewall block, error: " + res.Errors.First().Description);
                    }
                    else
                    {
                        Log("Firewall block ENABLED: " + res.Status);
                    }
                }, _uiScheduler).OnSuccess((t3, o3) =>
                {
                    a.GetFirewallLevel().OnSuccess(GetFirewallLevelSuccessHandler(), _uiScheduler);
                });
            });
        }

        private FirewallRuleInstruction[] ReadFirewallRules()
        {
            return new[]
            {
                FirewallRuleInstruction.CreateBlock("AUTO01", IPAddress.Parse("8.8.4.4"), IPAddress.Parse("255.255.255.255")),
                FirewallRuleInstruction.CreateBlock("AUTO02", IPAddress.Parse("8.8.8.8"), IPAddress.Parse("255.255.255.255")),
                FirewallRuleInstruction.CreateBlock("AUTO03", IPAddress.Parse("23.246.0.0"), IPAddress.Parse("255.255.0.0")),
                FirewallRuleInstruction.CreateBlock("AUTO04", IPAddress.Parse("37.77.184.0"), IPAddress.Parse("255.255.255.0")),
                FirewallRuleInstruction.CreateBlock("AUTO05", IPAddress.Parse("45.57.0.0"), IPAddress.Parse("255.255.0.0")),
                //This block might create issues with local Netflix version. Only add if nothing else works.
                FirewallRuleInstruction.CreateBlock("AUTO06", IPAddress.Parse("108.175.0.0"), IPAddress.Parse("255.255.0.0")),
                FirewallRuleInstruction.CreateBlock("AUTO07", IPAddress.Parse("185.2.0.0"), IPAddress.Parse("255.255.0.0")),
                FirewallRuleInstruction.CreateBlock("AUTO08", IPAddress.Parse("198.38.0.0"), IPAddress.Parse("255.255.0.0")),
                FirewallRuleInstruction.CreateBlock("AUTO09", IPAddress.Parse("198.45.48.0"), IPAddress.Parse("255.255.255.0")),
            };
        }

        private void btnFirewallBlockDisable_Click(object sender, EventArgs e)
        {
            Log("Disabling Firewall Block");

            LiveboxAdapter a = CreateLiveboxAdapter();
            a.LoginAsync().OnSuccess((t, o) =>
            {
                a.SetFirewallToMedium().OnSuccess((t2, o2) =>
                {
                    var res = t2.Result;
                    if (!res.Status.GetValueOrDefault())
                    {
                        Log("Could not DISABLE firewall block, error: " + res.Errors.First().Description);
                    }
                    else
                    {
                        Log("Firewall block DISABLED: " + res.Status);
                    }
                }, _uiScheduler).OnSuccess((t3, o3) =>
                {
                    a.GetFirewallLevel().OnSuccess(GetFirewallLevelSuccessHandler(), _uiScheduler);
                });
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            InitializeForm();
        }
    }
}
