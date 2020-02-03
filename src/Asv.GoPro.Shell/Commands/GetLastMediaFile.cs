using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Asv.GoPro.Shell
{
    public class GetLastMediaFile : GoProCommandBase
    {
        private string _destFileName;
        private bool _isPreview;

        public GetLastMediaFile()
        {
            IsCommand("last", "download and save last created media file");
            HasOption("th|thumbnail", "download only thumbnail file", _=>_isPreview = true);
            HasOption("f|file=", "dest file name. Default file name as camera file name", _ => _destFileName = _);
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel,
            string[] remainingArguments)
        {
            Console.WriteLine("Try to find last file");
            var sw = new Stopwatch();
            sw.Start();
            var list = await camera.GetMediaList(cancel);
            var fileInfo = list.Items.OrderByDescending(_ => _.Created).FirstOrDefault();
            if (fileInfo == null)
            {
                Console.WriteLine($"Files not found");
                return;
            }
            sw.Stop();
            Console.WriteLine($"Found {fileInfo.ToString()} by {sw.Elapsed:g}. Start downloading...");
            sw.Restart();
            _destFileName = _destFileName ?? fileInfo.Name;
            if (_isPreview)
            {
                await camera.DownloadThumbnail(fileInfo.Directory, fileInfo.Name, fileInfo.Name, cancel);
            }
            else
            {
                await camera.DownloadFile(fileInfo.Directory, fileInfo.Name, fileInfo.Name, cancel);
            }
            
            Console.WriteLine($"File saved success '{_destFileName}' by {sw.Elapsed:g}");
        }
    }
}