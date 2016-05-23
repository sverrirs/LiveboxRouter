using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Orange.Livebox.json
{
    [JsonObject(MemberSerialization.OptIn)]
    public class DeviceInfoResult
    {
        private Dictionary<string, DeviceInfoParam> _params;

        public DeviceInfoParam Manufacturer { get { return _params["Manufacturer"]; } }
        public DeviceInfoParam ManufacturerOUI { get { return _params["ManufacturerOUI"]; } }
        public DeviceInfoParam ModelName { get { return _params["ModelName"]; } }
        public DeviceInfoParam Description { get { return _params["Description"]; } }
        public DeviceInfoParam ProductClass { get { return _params["ProductClass"]; } }
        public DeviceInfoParam SerialNumber { get { return _params["SerialNumber"]; } }
        public DeviceInfoParam HardwareVersion { get { return _params["HardwareVersion"]; } }
        public DeviceInfoParam SoftwareVersion { get { return _params["SoftwareVersion"]; } }
        public DeviceInfoParam RescueVersion { get { return _params["RescueVersion"]; } }
        public DeviceInfoParam ModemFirmwareVersion { get { return _params["ModemFirmwareVersion"]; } }
        public DeviceInfoParam EnabledOptions { get { return _params["EnabledOptions"]; } }
        public DeviceInfoParam AdditionalHardwareVersion { get { return _params["AdditionalHardwareVersion"]; } }
        public DeviceInfoParam AdditionalSoftwareVersion { get { return _params["AdditionalSoftwareVersion"]; } }
        public DeviceInfoParam SpecVersion { get { return _params["SpecVersion"]; } }
        public DeviceInfoParam ProvisioningCode { get { return _params["ProvisioningCode"]; } }
        public DeviceInfoParam UpTime { get { return _params["UpTime"]; } }
        public DeviceInfoParam FirstUseDate { get { return _params["FirstUseDate"]; } }
        public DeviceInfoParam ManufacturerURL { get { return _params["ManufacturerURL"]; } }
        public DeviceInfoParam Country { get { return _params["Country"]; } }
        public DeviceInfoParam ExternalIPAddress { get { return _params["ExternalIPAddress"]; } }
        public DeviceInfoParam DeviceStatus { get { return _params["DeviceStatus"]; } }
        public DeviceInfoParam NumberOfReboots { get { return _params["NumberOfReboots"]; } }

        [JsonProperty("parameters")] public DeviceInfoParam[] Parameters { get; set; }
        
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            // Index the parameter list for faster access after deserialization completes
            _params = new Dictionary<string, DeviceInfoParam>();

            foreach (var p in Parameters)
            {
                _params.Add(p.Name, p);
            }
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class DeviceInfoParam
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("state")] public string State { get; set; }
        [JsonProperty("value")] public string Value { get; set; }
    }
}
