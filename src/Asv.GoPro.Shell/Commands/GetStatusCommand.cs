using System;
using System.Threading.Tasks;

namespace Asv.GoPro.Shell
{
    public class GetStatusCommand: GoProCommandBase
    {
        public GetStatusCommand()
        {
            IsCommand("status");
        }

        protected override async Task RunAsync(GoProCameraBase camera)
        {
            var status = await camera.GetStatus();
            Console.WriteLine(status);
        }
    }
}