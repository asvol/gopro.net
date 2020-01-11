using System.Threading.Tasks;
using ManyConsole;

namespace Asv.GoPro.Shell
{
    public abstract class GoProCommandBase : ConsoleCommand
    {
        private string _host = "10.5.5.9";
        private int _port = 8080;

        public GoProCommandBase()
        {
            HasOption("h|host=", $"IP address or URL of camera (default={_host})", _ => _host = _);
            HasOption("p|port=", $"port number of camera (default={_port})", (int _) => _port = _);
        }

        public override int Run(string[] remainingArguments)
        {
            using (var camera = new GoProCameraBase(_host,_port))
            {
                RunAsync(camera).Wait();
            }

            return 0;
        }

        protected abstract Task RunAsync(GoProCameraBase camera);

    }
}