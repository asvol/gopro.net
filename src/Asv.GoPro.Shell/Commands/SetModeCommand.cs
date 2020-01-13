using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Asv.GoPro.Shell
{
    public class SetModeCommand: GoProCommandBase
    {
        private GoProMode _mode;

        public SetModeCommand()
        {
            IsCommand("mode",$"Set camera mode");
            HasRequiredOption("m|mode=",$"Available values {string.Join(",", Enum.GetNames(typeof(GoProMode)))}",_=>_mode = (GoProMode) Enum.Parse(typeof(GoProMode),_, true) );
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel)
        {
            Console.WriteLine($"Send change mode '{_mode:G}' command");
            Console.WriteLine("Begin resize image to ");
            var sw = new Stopwatch();
            sw.Start();
            await camera.SetMode(_mode,cancel);
            Console.WriteLine($"Set mode '{_mode:G}' success by {sw.Elapsed:g}");
        }
    }
}