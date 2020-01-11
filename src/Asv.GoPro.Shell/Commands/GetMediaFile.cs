using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asv.GoPro.Shell
{
    public class GetMediaFile : GoProCommandBase
    {
        private string _destFileName;
        private string _sourceFileName;
        private string _sourceDirName;

        public GetMediaFile()
        {
            IsCommand("file", "download and save media file");
            HasRequiredOption("n|name=", "source file name",_=>_sourceFileName = _);
            HasRequiredOption("d|dir=", "source directory name", _ => _sourceDirName = _);
            HasOption("f|file=", "dest file name. Default file name as camera file name", _ => _destFileName = _);
        }

        protected override async Task RunAsync(IGoProCamera camera, CancellationToken cancel)
        {
            Console.WriteLine("Try download media file");
            _destFileName = _destFileName ?? _sourceFileName;
            await camera.DownloadFile(_sourceDirName,_sourceFileName,_destFileName ,cancel);
            Console.WriteLine($"File saved success '{_destFileName}'");
        }
    }
}