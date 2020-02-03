using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Asv.GoPro.Shell
{
    public class GetStatus : GoProCommandBase
    {
        public GetStatus()
        {
            IsCommand("status", "Get GoProStatus ");
            HasAdditionalArguments(1, "[output file name]");
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel,
            string[] remainingArguments)
        {
            var status = await camera.GetStatus(cancel);
            File.WriteAllText(remainingArguments.First(), JsonConvert.SerializeObject(status, Formatting.Indented));
        }
    }
}