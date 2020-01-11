using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asv.GoPro.Shell
{
    public class GetLastMediaFile : GoProCommandBase
    {
        private string _destFileName;

        public GetLastMediaFile()
        {
            IsCommand("last", "download and save last created media file");
            HasOption("f|file=", "dest file name. Default file name as camera file name", _ => _destFileName = _);
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel)
        {
            Console.WriteLine("Try to find last file");
            var list = await camera.GetMediaList(cancel);
            var fileInfo = list.Items.OrderByDescending(_ => _.Created).FirstOrDefault();
            if (fileInfo == null)
            {
                Console.WriteLine($"Files not found");
                return;
            }
            Console.WriteLine($"Found {fileInfo.ToString()}. Start downloading...");
            _destFileName = _destFileName ?? fileInfo.Name; 
            await camera.DownloadFile(fileInfo.Directory, fileInfo.Name, fileInfo.Name, cancel);
            Console.WriteLine($"File saved success '{_destFileName}'");
        }
    }
}