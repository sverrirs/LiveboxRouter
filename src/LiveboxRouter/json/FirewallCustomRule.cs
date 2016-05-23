using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orange.Livebox.json
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FirewallCustomRule
    {
        public static string ProtocolTCP = "6";
        public static string ProtocolUDP = "17";
        public static string ProtocolBoth = ProtocolTCP + "," + ProtocolUDP;

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("destinationPort")]
        public string DestinationPort { get; set; }

        [JsonProperty("destinationPrefix")]
        public string DestinationPrefix { get; set; }

        [JsonProperty("sourcePort")]
        public string SourcePort { get; set; }

        [JsonProperty("sourcePrefix")]
        public string SourcePrefix { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        [JsonProperty("ipversion")]
        public int IPversion { get; set; }

        [JsonProperty("enable")]
        public bool Enable { get; set; }

        [JsonProperty("chain")]
        public string Chain { get; set; }

        [JsonProperty("persistent")]
        public bool Persistent { get; set; }

    //{"parameters":{"id":"BLOCK","action":"Drop","destinationPort":"","destinationPrefix":"","sourcePort":"","sourcePrefix":"8.8.4.4","description":"BLOCK","protocol":"6,17","ipversion":4,"enable":false,"chain":"Custom","persistent":true}}

        public FirewallCustomRule()
        {
            Chain = "Custom";
            Persistent = true;
            IPversion = 4;
        }
    }
}
