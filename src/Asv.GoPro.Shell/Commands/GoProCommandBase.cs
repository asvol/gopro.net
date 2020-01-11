using System.Threading;
using System.Threading.Tasks;
using ManyConsole;

namespace Asv.GoPro.Shell
{
    public abstract class GoProCommandBase : ConsoleCommand
    {
        private string _host = "10.5.5.9";
        private int _port = 8080;
        private int _timeoutMs = 30000;

        public GoProCommandBase()
        {
            HasOption("h|host=", $"IP address or URL of camera (default={_host})", _ => _host = _);
            HasOption("p|port=", $"port number of camera (default={_port})", (int _) => _port = _);
            HasOption("t|timeout=", $"Request timeout ms (default={_timeoutMs})", (int _) => _timeoutMs = _);
        }

        public override int Run(string[] remainingArguments)
        {
            using (var camera = new GoProHero8(_host,_port))
            {
                var cancel = new CancellationTokenSource(_timeoutMs);
                RunAsync(camera, cancel.Token).Wait();
            }

            return 0;
        }

        protected abstract Task RunAsync(IGoProCamera camera, CancellationToken cancel);

    }
}