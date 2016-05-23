using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orange.Livebox.json
{
    /// <summary>
    /// Result from a login attempt
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LoginResult : LiveboxDataResult<int, LoginData>
    {
    }

    /// <summary>
    /// The data component for the login attempt object
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class LoginData
    {
        [JsonProperty("contextID")]
        public string ContextID { get; set; }
    }
}
