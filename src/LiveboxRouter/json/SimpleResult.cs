using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orange.Livebox.json
{
    /// <summary>
    /// Simple result object returned from the Livebox that indicates the status of an write or set operation
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SimpleResult : LiveboxResult<bool?>
    {
    }


    [JsonObject(MemberSerialization.OptIn)]
    public class StringResult : LiveboxResult<string>
    {
    }
}
