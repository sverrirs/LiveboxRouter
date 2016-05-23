using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orange.Livebox.json
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FirewallRuleResults : LiveboxResult<Dictionary<string, FirewallRule>>
    {
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class FirewallRule
    {
        public static string ProtocolTCP = "6";
        public static string ProtocolUDP = "17";
        public static string ProtocolBoth = ProtocolTCP + "," + ProtocolUDP;

        [JsonProperty("Id")] public string Name { get; set; }
        [JsonProperty("Target")] public string Target { get; set; }
        [JsonProperty("Status")] public string Status { get; set; }
        [JsonProperty("Class")] public string Class { get; set; }
        [JsonProperty("IPVersion")] public int IPVersion { get; set; }
        [JsonProperty("Protocol")] public string Protocol { get; set; }
        [JsonProperty("DestinationPort")] public string DestinationPort { get; set; }
        [JsonProperty("SourcePort")] public string SourcePort { get; set; }
        [JsonProperty("DestinationMACAddress")] public string DestinationMACAddress { get; set; }
        [JsonProperty("SourceMACAddress")] public string SourceMACAddress { get; set; }
        [JsonProperty("DestinationPrefix")] public string DestinationPrefix { get; set; }
        [JsonProperty("SourcePrefix")] public string SourcePrefix { get; set; }
        [JsonProperty("TargetChain")] public string TargetChain { get; set; }
        [JsonProperty("Description")] public string Description { get; set; }
        [JsonProperty("Time")] public string Time { get; set; }
        [JsonProperty("Enable")] public bool Enable { get; set; }
        /*
        "Id": "HTTP",
        "Target": "Accept",
        "Status": "Enabled",
        "Class": "Forward",
        "IPVersion": 4,
        "Protocol": "6",
        "DestinationPort": "80",
        "SourcePort": "",
        "DestinationMACAddress": "",
        "SourceMACAddress": "",
        "DestinationPrefix": "",
        "SourcePrefix": "",
        "TargetChain": "",
        "Description": "",
        "Time": "0 sec, 0 usec",
        "Enable": true
            */
    }
}
