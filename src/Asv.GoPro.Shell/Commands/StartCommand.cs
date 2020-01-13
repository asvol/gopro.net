using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Asv.GoPro.Shell
{
    public class StartCommand : GoProCommandBase
    {
        public StartCommand()
        {
            IsCommand("start", $"Start record video \\ take photo");
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel)
        {
            Console.WriteLine("Send start command");
            Console.WriteLine("Begin resize image to ");
            var sw = new Stopwatch();
            sw.Start();
            await camera.Start(cancel);
            sw.Stop();
            Console.WriteLine($"Start success by {sw.Elapsed:g}");
        }
    }
}