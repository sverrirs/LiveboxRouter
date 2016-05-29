using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orange.Livebox.json
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FirewallRuleCreateResult : LiveboxDataResult<string, FirewallRuleCreateData>
    {
        //{"result":{"status":"BLOCK3","data":{"persistent":true}}}
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class FirewallRuleCreateData
    {
        [JsonProperty("persistent")] public bool? Persistent { get; set; }
    }

    /// <summary>
    /// Container to instruct the modification or creation of a firewall rule
    /// this is distinctly different from the <see cref="FirewallRule"/> class
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class FirewallRuleInstruction
    {
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

        public FirewallRuleInstruction()
        {
            Chain = "Custom";
            Persistent = true;
            IPversion = 4;
        }

        private static FirewallRuleInstruction Create(string id, IPAddress ipAddress, IPAddress subnetMask = null, bool create = true)
        {
            return new FirewallRuleInstruction()
            {
                Id = id,
                Action = "Drop",
                SourcePrefix = subnetMask != null ? IPNetwork.Parse(ipAddress, subnetMask).ToString() : ipAddress.ToString(),
                Description = id,
                Protocol = FirewallRule.ProtocolBoth,
                IPversion = 4,
                Chain = "Custom",
                Persistent = true,
                Enable = create
            };
        }

        public static FirewallRuleInstruction CreateBlock(string id, IPAddress ipAddress, IPAddress subnetMask)
        {
            return Create(id, ipAddress, subnetMask, create:true);
        }

        public static FirewallRuleInstruction CreateUnblock(string id, IPAddress ipAddress)
        {
            return Create(id, ipAddress, create: false);
        }
    }

    public static class FirewallRuleExtensions
    {
        public static FirewallRuleInstruction ToInstruction(this FirewallRule rule, bool create = true)
        {
            return new FirewallRuleInstruction()
            {
                Action = rule.Target,
                Id = rule.Id,
                Description = rule.Description,
                IPversion = rule.IPVersion,
                Chain = "Custom",
                Persistent = true,
                Protocol = rule.Protocol == FirewallRule.ProtocolBoth ? "both" : rule.Protocol,

                // Should we create or deactivate this rule in the router
                Enable = true
            };
        }
    }
}
