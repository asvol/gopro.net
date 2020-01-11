using System;
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

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel)
        {
            Console.WriteLine("Send stop command");
            await camera.Stop(cancel);
            Console.WriteLine($"Stop success");
        }
    }
}