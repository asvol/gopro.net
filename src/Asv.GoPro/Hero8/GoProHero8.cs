using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asv.GoPro
{
    public class GoProHero8 : IGoProCamera
    {
        private readonly Uri _baseUri;

        public GoProHero8(string host, int port)
        {
            _baseUri = new Uri($"http://{host}:{port}");
        }

        private HttpClient CreateHttpClient()
        {
            return new HttpClient();
        }

        private async Task<string> GetString(string relativeUrl,CancellationToken cancel)
        {
            using (var client = CreateHttpClient())
            {
                using (var result = await client.GetAsync($"{_baseUri}{relativeUrl}", cancel))
                {
                    result.EnsureSuccessStatusCode();
                    return await result.Content.ReadAsStringAsync();
                }
            }
        }

        private static DateTime ConvertUnixTime(int unixTime)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0) + TimeSpan.FromSeconds(unixTime);
        }

        public async Task<GoproCameraInfo> GetStatus(CancellationToken cancel)
        {
            var str = await GetString("/gp/gpControl/status", cancel);


            var json = JsonConvert.DeserializeObject<JObject>(str);
            var status = (JObject) json["status"];
            var settings = (JObject) json["settings"];
            return new GoproCameraInfo
            {
                Settings = new CameraSettings
                {
//                    SubVideoMode = (SubVideoMode)settings["68"].Value<int>(),
//                    VideoResolution = (VideoResolution)settings["2"].Value<int>(),
//                    FrameRate = GetEnum<FrameRate?>(settings,"3"),
                },
                Status = new CameraStatus
                {
//                    IsBatteryAvailable = status["1"].Value<int>() != 0,
//                    BatteryLevel = (BatteryLevel) status["2"].Value<int>(),
//                    Mode = (CameraMode) status["43"].Value<int>(),
//                    SubMode = (CameraSubMode) status["44"].Value<int>(),
//                    RecordDuration = status["13"].Value<int>(),
//                    MultiShotPicturesTaken = status["39"].Value<int>(),
//                    NumberOfClients = status["39"].Value<int>(),
//                    IsStreaming = status["32"].Value<int>() != 0,
//                    IsSdCard = status["33"].Value<int>() != 0,
//                    RemainingPhotos = status["34"].Value<int>(),
//                    RemainingVideoTime = status["35"].Value<int>(),
//                    BatchPhotosTaken = status["36"].Value<int>(),
//                    NumberOfVideosShot = status["37"].Value<int>(),
//                    NumberOfAllPhotos = status["38"].Value<int>(),
//                    NumberOfAllVideos = status["39"].Value<int>(),
//                    IsRecording = status["8"].Value<int>() != 0,
//                    SdFreeSpace = status["54"].Value<int>(),
                }
            };

        }

        public Task SetMode(GoProMode mode,CancellationToken cancel)
        {
            // Primary modes:
            // Video: http://10.5.5.9/gp/gpControl/command/mode?p=0
            // Photo: http://10.5.5.9/gp/gpControl/command/mode?p=1
            // MultiShot: http://10.5.5.9/gp/gpControl/command/mode?p=2
            var modeCode = 0;
            switch (mode)
            {
                case GoProMode.Video:
                    modeCode = 0;
                    break;
                case GoProMode.Photo:
                    modeCode = 1;
                    break;
                case GoProMode.MultiShot:
                    modeCode = 2;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
            return GetString($"/gp/gpControl/command/mode?p={modeCode}",cancel);
        }

        public Task Start(CancellationToken cancel)
        {
            // Shutter
            // Trigger: http://10.5.5.9/gp/gpControl/command/shutter?p=1
            // Stop(Video / Timelapse): http://10.5.5.9/gp/gpControl/command/shutter?p=0
            return GetString($"/gp/gpControl/command/shutter?p=1", cancel);
        }

        public Task Stop(CancellationToken cancel)
        {
            // Shutter
            // Trigger: http://10.5.5.9/gp/gpControl/command/shutter?p=1
            // Stop(Video / Timelapse): http://10.5.5.9/gp/gpControl/command/shutter?p=0
            return GetString($"/gp/gpControl/command/shutter?p=0", cancel);
        }

        
        public async Task<MediaList> GetMediaList(CancellationToken cancel)
        {
            //A JSON list of the contents of the SD card: http://10.5.5.9:8080/gp/gpMediaList
            var str = await GetString("/gp/gpMediaList", cancel);
            var list = new MediaList();

            var result = JsonConvert.DeserializeObject<dynamic>(str);
            foreach (var medium in result.media)
            {
                foreach (var item in medium.fs)
                {
                    list.Items.Add(new MediaItem
                    {
                        Type = ParseTypeByExt((string)item.n),
                        Directory = medium.d,
                        Name = item.n,
                        Created = ConvertUnixTime(int.Parse((string)item.cre)),
                        Modified = ConvertUnixTime(int.Parse((string) item.mod))
                    });
                }
            }
            return list;

        }

        private GoProFileType ParseTypeByExt(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return GoProFileType.Unknown;
            var ext = Path.GetExtension(fileName);
            if (string.IsNullOrWhiteSpace(ext)) return GoProFileType.Unknown;

            if (ext.Equals(".jpeg", StringComparison.InvariantCultureIgnoreCase)
             || ext.Equals(".jpg", StringComparison.InvariantCultureIgnoreCase))
            {
                return GoProFileType.Photo;
            }
            if (ext.Equals(".mp4", StringComparison.InvariantCultureIgnoreCase))
            {
                return GoProFileType.Video;
            }

            return GoProFileType.Unknown;

        }

        public async Task DownloadFile(string sourceDirName, string sourceFileName, string destFileName, CancellationToken cancel)
        {
            using (var client = CreateHttpClient())
            {
                using (var result =
                    await client.GetAsync($"{_baseUri}/videos/DCIM/{sourceDirName}/{sourceFileName}", cancel))
                {
                    result.EnsureSuccessStatusCode();
                    using (var httpStream = await result.Content.ReadAsStreamAsync())
                    {
                        using (var file = File.OpenWrite(destFileName))
                        {
                            await httpStream.CopyToAsync(file); 
                        }
                    }

                    
                }
                    
            }
        }

        public async Task DownloadThumbnail(string sourceDirName, string sourceFileName, string destFileName, CancellationToken cancel)
        {
            using (var client = CreateHttpClient())
            {
                using (var result =
                    await client.GetAsync($"{_baseUri}/gp/gpMediaMetadata?p={sourceDirName}/{sourceFileName}", cancel))
                {
                    result.EnsureSuccessStatusCode();
                    using (var httpStream = await result.Content.ReadAsStreamAsync())
                    {
                        using (var file = File.OpenWrite(destFileName))
                        {
                            await httpStream.CopyToAsync(file);
                        }
                    }
                }
            }
        }


        public void Dispose()
        {

        }
    }

    
}