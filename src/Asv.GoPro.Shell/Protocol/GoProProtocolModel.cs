using System;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asv.GoPro.Shell.Protocol
{
    public class GoProProtocolModel
    {
        public int Version { get; set; }
        public int SchemaVersion { get; set; }
        public GoProProtocolStatusGroup[] Status { get; set; }
    }

    public class GoProProtocolStatusGroup
    {
        public string Name { get; set; }
        public GoProProtocolStatusField[] Fields { get; set; }
    }

    public enum StatusFieldType
    {
        Unknown,
        Integer,
        String,
    }

    public class GoProProtocolStatusField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusFieldType Type { get; set; }
    }

    public class GoProStatus
    {
        private readonly JObject _json;
        private Status _status;

        public GoProStatus(string json):this(JsonConvert.DeserializeObject<JObject>(json))
        {
            
        }

        private GoProStatus(JObject json)
        {
            _json = json;
        }

        public Status Status => _status ?? (_status = new Status(_json["status"].ToObject<JObject>()));
    }


    public class Status
    {
        private readonly JObject _status;

        public Status(JObject status)
        {
            _status = status;
        }

        public void Deserialize(JObject status)
        {
          
        }
    }

    
}