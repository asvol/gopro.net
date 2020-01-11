using System;
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
            await camera.Start(cancel);
            Console.WriteLine($"Start success");
        }
    }
}