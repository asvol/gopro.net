using System;
using System.Diagnostics;
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

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel,
            string[] remainingArguments)
        {
            Console.WriteLine("Try get media list");

            var sw = new Stopwatch();
            sw.Start();
            var result = await camera.GetMediaList(cancel);
            sw.Stop();
            Console.WriteLine($"Success upload media list by {sw.Elapsed:g}");
            foreach (var item in result.Items)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
    }
}