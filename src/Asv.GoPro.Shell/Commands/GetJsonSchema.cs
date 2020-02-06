using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Asv.GoPro.Shell
{
    public class GetJsonSchema:GoProCommandBase
    {
        public GetJsonSchema()
        {
            IsCommand("schema", "Download JSON protocol schema and JSON status example from GoPro device");
            HasAdditionalArguments(1, "[JSON schema file name] [JSON status file name]");
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel,
            string[] remainingArguments)
        {
            var schema = await camera.GetJsonSchema(cancel);
            var status = await camera.GetJsonStatus(cancel);
            File.WriteAllText(remainingArguments[0], schema);
            File.WriteAllText(remainingArguments[1], schema);
        }
    }
}