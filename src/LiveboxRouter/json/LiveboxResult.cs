using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orange.Livebox.json
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class LiveboxResult<TStatus>
    {
        [JsonProperty("status")] public TStatus Success { get; set; }
        [JsonProperty("errors")] public Error[] Errors { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public abstract class LiveboxDataResult<TStatus, TData> : LiveboxResult<TStatus>
    {
        [JsonProperty("data")] public TData Data { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class Error
    {
        [JsonProperty("error")] public int Number { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("info")] public string Info { get; set; }
    }
}
