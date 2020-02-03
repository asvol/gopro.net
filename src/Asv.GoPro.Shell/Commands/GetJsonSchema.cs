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
            IsCommand("schema", "Download JSON protocol schema from GoPro device to file");
            HasAdditionalArguments(1, "[output file name]");
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel,
            string[] remainingArguments)
        {
            var schema = await camera.GetJsonSchema(cancel);
            File.WriteAllText(remainingArguments.First(), schema);
        }
    }
}