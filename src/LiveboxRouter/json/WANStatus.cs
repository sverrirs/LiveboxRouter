using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orange.Livebox.json
{
    /// <summary>
    /// The result object from a WAN get operation
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class WANStatus : LiveboxDataResult<bool?, WANData>
    {}

    [JsonObject(MemberSerialization.OptIn)]
    public class WANData
    {
        [JsonProperty("LinkType")] public string LinkType { get; set; }
        [JsonProperty("LinkState")] public string LinkState { get; set; }
        [JsonProperty("MACAddress")] public string MACAddress { get; set; }
        [JsonProperty("Protocol")] public string Protocol { get; set; }
        [JsonProperty("ConnectionState")] public string ConnectionState { get; set; }
        [JsonProperty("LastConnectionError")] public string LastConnectionError { get; set; }
        [JsonProperty("IPAddress")] public string IPAddress { get; set; }
        [JsonProperty("RemoteGateway")] public string RemoteGateway { get; set; }
        [JsonProperty("DNSServers")] public string DNSServers { get; set; }
        [JsonProperty("IPv6Address")] public string IPv6Address { get; set; }

        /*
        "LinkType":"dsl",
        "LinkState":"up",
        "MACAddress":"18:62:2C:A7:DF:31",
        "Protocol":"ppp",
        "ConnectionState":"Connected",
        "LastConnectionError":"ERROR_NONE",
        "IPAddress":"90.40.253.30",
        "RemoteGateway":"193.253.160.3",
        "DNSServers":"81.253.149.13,80.10.246.5",
        "IPv6Address":""*/
    }
}
