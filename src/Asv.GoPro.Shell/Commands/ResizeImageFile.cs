using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ManyConsole;

namespace Asv.GoPro.Shell
{
    public class ResizeImageFile : ConsoleCommand
    {
        private string _srcFilePath;
        private string _destFilePath;
        private int _size = 320;
        private int _q = 75;
        

        public ResizeImageFile()
        {
            IsCommand("resize", "resize image file");
            HasRequiredOption("i|in=", "source file name", _ => _srcFilePath = _);
            HasOption("o|out=", "dest file name. Default([source_file_name][width]x[height]x[quality])", _ => _destFilePath = _);
            HasOption("s|size=", $"Image width. Default {_size}", (int _) => _size = _);
            HasOption("q|quality=", $"Image quality. Default {_q}", (int _) => _q = _);
        }

        public override int Run(string[] remainingArguments)
        {
            Console.WriteLine("Begin resize image to ");
            var sw = new Stopwatch();
            sw.Start();
            using (var image = new Bitmap(System.Drawing.Image.FromFile(_srcFilePath)))
            {
                Console.WriteLine($"Load bitmap by {sw.Elapsed:g}");
                int width, height;
                if (image.Width > image.Height)
                {
                    width = _size;
                    height = Convert.ToInt32(image.Height * _size / (double)image.Width);
                }
                else
                {
                    width = Convert.ToInt32(image.Width * _size / (double)image.Height);
                    height = _size;
                }

                _destFilePath = _destFilePath ?? $"{Path.GetFileNameWithoutExtension(_srcFilePath)}_{width}x{height}x{_q}{Path.GetExtension(_srcFilePath)}";

                var resized = new Bitmap(width, height);
                
                using (var graphics = Graphics.FromImage(resized))
                {
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.DrawImage(image, 0, 0, width, height);
                    using (var output = File.Open(_destFilePath, FileMode.Create))
                    {
                        var qualityParamId = Encoder.Quality;
                        var encoderParameters = new EncoderParameters(1);
                        encoderParameters.Param[0] = new EncoderParameter(qualityParamId, _q);
                        var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(_ => _.FormatID == ImageFormat.Jpeg.Guid);
                        resized.Save(output, codec, encoderParameters);
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"File saved success '{_srcFilePath}' by {sw.Elapsed:g}");
            return 0;
        }
    }
}