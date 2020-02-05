using System.IO;
using Asv.GoPro.Shell.Protocol;
using ManyConsole;
using GoProProtocolParser = Asv.GoPro.Shell.Protocol.GoProProtocolParser;

namespace Asv.GoPro.Shell
{
    public class CodeGenFromJsonSchema : ConsoleCommand
    {
        public CodeGenFromJsonSchema()
        {
            IsCommand("cg", "Generate code from JSON schema");
            HasAdditionalArguments(4, "[JSON schema file name] [JSON response example file] [Liquid template file] [output file name]");
        }

        public override int Run(string[] remainingArguments)
        {
            var schema = File.ReadAllText(remainingArguments[0]);
            var responseExample = File.ReadAllText(remainingArguments[1]);
            var template = File.ReadAllText(remainingArguments[2]);
            var fileName = remainingArguments[3];

            var model = GoProProtocolParser.Parse(schema, responseExample);
            var result = GoProProtocolGenerator.Generate(model, template);
            File.WriteAllText(fileName,result);
            return 0;
        }
    }
}