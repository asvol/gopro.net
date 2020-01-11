using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asv.GoPro.Shell
{
    public class GetMediaListCommand : GoProCommandBase
    {
        
        public GetMediaListCommand()
        {
            IsCommand("media", "Print media list");
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel)
        {
            Console.WriteLine("Try get media list");
            var result = await camera.GetMediaList(cancel);
            foreach (var item in result.Items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}