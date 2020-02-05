using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Dm734.Core;
using DotLiquid;
using DotLiquid.NamingConventions;

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
                Status = m.Status.OrderBy(_ => _.Name).Select(group => new
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
                }),
                Settings = m.Settings.OrderBy(_=>_.DisplayName).Select(sett=> new
                {
                    Id = sett.Id,
                    DisplayName = sett.DisplayName,
                    Group = sett.Group,
                    NotUnique = sett.NotUnique,
                    Name = RemoveWhiteSpaceConverter(sett.UniqueDisplayName),
                    Options = sett.Options.OrderBy(_ => _.DisplayName).Select(opt=>new
                    {
                        Id = opt.Id,
                        Name = RemoveWhiteSpaceConverter(opt.UniqueDisplayName),
                        DisplayName = opt.DisplayName,
                        Value = opt.Value,

                    })
                }),
            });
            var result = Template.Parse(template);
            return result.Render(args);
        }

        private static string RemoveWhiteSpaceConverter(string name)
        {
            var res = name.ToLower();
            res = Regex.Replace(res, "[\\.]", "Dot");
            res = Regex.Replace(res, "[-]", "Minus");
            res = Regex.Replace(res, "[%]", "Percent");
            res = Regex.Replace(res, "[+]", "Plus");
            return NameConverter(Regex.Replace(res, "[^0-9a-zA-Z]","_"));
        }

        private static string NameConverter(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            var a = Regex.Replace(name.ToLower(), "_([a-z0-9])", _ => _.Value.Substring(1).ToUpper(), RegexOptions.Compiled);
            a = a.Substring(0, 1).ToUpper() + a.Substring(1);
            return a;
        }
    }
}