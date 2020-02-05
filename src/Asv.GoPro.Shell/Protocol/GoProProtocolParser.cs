using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asv.GoPro.Shell.Protocol
{
    public class GoProProtocolParser
    {
        public static GoProProtocolModel Parse(string schema, string responseExample)
        {
            var root = JsonConvert.DeserializeObject<JObject>(schema);
            var example = JsonConvert.DeserializeObject<JObject>(responseExample);

            var settings = root["settings"].Children().Select(ParseSettings).ToArray();

            foreach (var set in settings)
            {
                foreach (var group in set.Options.GroupBy(_=>_.DisplayName))
                {
                    var items = group.ToArray();
                    if (items.Length <= 1) continue;
                    foreach (var notUniqueNameItems in items)
                    {
                        notUniqueNameItems.Group = @group.Key;
                        notUniqueNameItems.NotUnique = true;
                        notUniqueNameItems.UniqueDisplayName = @group.Key + notUniqueNameItems.Id;
                    }
                }
            }

            foreach (var group in settings.GroupBy(_ => _.DisplayName))
            {
                var items = group.ToArray();
                if (items.Length <= 1) continue;
                foreach (var notUniqueNameItems in items)
                {
                    notUniqueNameItems.Group = @group.Key;
                    notUniqueNameItems.NotUnique = true;
                    notUniqueNameItems.UniqueDisplayName = @group.Key + notUniqueNameItems.Id;
                }
            }

            

            // parse schema
            var result = new GoProProtocolModel
            {
                Version = root["version"].ToObject<int>(),
                SchemaVersion = root["schema_version"].ToObject<int>(),
                Status = root["status"]["groups"].Children().Select(ParseGroup).ToArray(),
                Settings = settings,
                Info = new CameraInfo(root["info"]),
            };

            // try to find types for status items
            var statusValues = (example["status"] as JObject).Properties().ToDictionary(_ => int.Parse(_.Name), _ => _.Value.Type);
            foreach (var statusField in result.Status.SelectMany(_=>_.Fields))
            {
                JTokenType type;
                if (statusValues.TryGetValue(statusField.Id,out type) == false) continue;
                statusField.Type = Convert(type);
            }

            return result;
        }

        private static GoProSettingItem ParseSettings(JToken set)
        {
            return new GoProSettingItem
            {
                Id = set["id"].ToObject<int>(),
                UniqueDisplayName = set["display_name"].ToObject<string>(),
                DisplayName = set["display_name"].ToObject<string>(),
                Options = set["options"].Children().Select(ParseSettingsOption).ToArray(),
            };
        }

        private static GoProSettingOptionItem ParseSettingsOption(JToken set)
        {
            return new GoProSettingOptionItem
            {
                Id = set["id"].ToObject<int>(),
                UniqueDisplayName = set["display_name"].ToObject<string>(),
                DisplayName = set["display_name"].ToObject<string>(),
                Value = set["value"].ToObject<int>(),
            };
        }

        private static StatusFieldType Convert(JTokenType type)
        {
            switch (type)
            {

                case JTokenType.Integer:
                    return StatusFieldType.Integer;
                case JTokenType.String:
                    return StatusFieldType.String;
                case JTokenType.Boolean:
                case JTokenType.None:
                case JTokenType.Object:
                case JTokenType.Array:
                case JTokenType.Constructor:
                case JTokenType.Property:
                case JTokenType.Comment:
                case JTokenType.Float:
                case JTokenType.Null:
                case JTokenType.Undefined:
                case JTokenType.Date:
                case JTokenType.Raw:
                case JTokenType.Bytes:
                case JTokenType.Guid:
                case JTokenType.Uri:
                case JTokenType.TimeSpan:
                default:
                    return StatusFieldType.Unknown;
            }
        }


        private static GoProProtocolStatusGroup ParseGroup(JToken gr)
        {
            return new GoProProtocolStatusGroup
            {
                Name = gr["group"].ToObject<string>(),
                Fields = gr["fields"].Children().Select(_=> 
                    new GoProProtocolStatusField
                    {
                        Id = _["id"].ToObject<int>(),
                        Name = _["name"].ToObject<string>(),
                    }).ToArray(),
            };
        }



        


    }
}