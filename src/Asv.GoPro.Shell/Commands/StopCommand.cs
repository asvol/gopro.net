using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Asv.GoPro.Shell
{
    public class StopCommand : GoProCommandBase
    {
        public StopCommand()
        {
            IsCommand("stop","Stop capture video");
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel,
            string[] remainingArguments)
        {
            Console.WriteLine("Send stop command");
            var sw = new Stopwatch();
            sw.Start();
            await camera.Stop(cancel);
            sw.Stop();
            Console.WriteLine($"Stop success by {sw.Elapsed:g}");
        }
    }
}