using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Dm734.Core;
using DotLiquid;
using DotLiquid.NamingConventions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asv.GoPro.Shell.Protocol
{
    public static class GoProProtocolGenerator
    {
        public static string Generate(GoProProtocolModel m, string template)
        {
            Template.NamingConvention = new CSharpNamingConvention();
            var args = Hash.FromAnonymousObject(new
            {
                Tool = Assembly.GetCallingAssembly().GetTitle(),
                ToolVersion = Assembly.GetCallingAssembly().GetInformationalVersion(),
                ProtocolVersion = m.Version,
                ProtocolSchemaVersion = m.SchemaVersion,
                Status = m.Status.Select(group => new
                {
                    Name = group.Name,
                    CamelName = NameConverter(group.Name),
                    Fields = group.Fields.Select(f => new
                    {
                        Name = f.Name,
                        CamelName = NameConverter(f.Name),
                        Id = f.Id,
                        Type = f.Type.ToString("G"),
                    })
                })
            });
            var result = Template.Parse(template);
            return result.Render(args);
        }

        private static string NameConverter(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            var a = Regex.Replace(name.ToLower(), "_([a-z0-9])", _ => _.Value.Substring(1).ToUpper(), RegexOptions.Compiled);
            a = a.Substring(0, 1).ToUpper() + a.Substring(1);
            return a;
        }
    }

    public class GoProProtocolParser
    {
        public static GoProProtocolModel Parse(string schema, string responseExample)
        {
            var root = JsonConvert.DeserializeObject<JObject>(schema);
            var example = JsonConvert.DeserializeObject<JObject>(responseExample);
            
            // parse schema
            var result = new GoProProtocolModel
            {
                Version = root["version"].ToObject<int>(),
                SchemaVersion = root["schema_version"].ToObject<int>(),
                Status = root["status"]["groups"].Children().Select(ParseGroup).ToArray()
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