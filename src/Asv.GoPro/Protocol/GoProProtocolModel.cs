using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asv.GoPro.Shell.ProtocolModel
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

    public class GoProProtocolStatusField
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GoProProtocolParser
    {
        public static GoProProtocolModel Parse(string jsonSchema)
        {
            var root = JsonConvert.DeserializeObject<JObject>(jsonSchema);
            
            return new GoProProtocolModel
            {
                Version = root["version"].ToObject<int>(),
                SchemaVersion = root["schema_version"].ToObject<int>(),
                Status = root["status"]["groups"].Values().Select(ToGroup).ToArray()
            };
        }

        private static GoProProtocolStatusGroup ToGroup(JToken gr)
        {
            return new GoProProtocolStatusGroup
            {
                Name = gr["group"].ToObject<string>(),
                Fields = gr["fields"].Values().Select(_=> 
                    new GoProProtocolStatusField
                    {
                        Id = _["id"].ToObject<int>(),
                        Name = _["name"].ToObject<string>(),
                    }).ToArray(),
            };
        }

    }

    
}