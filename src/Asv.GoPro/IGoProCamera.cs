using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Asv.GoPro
{
    public enum GoProMode
    {
        Video,
        Photo,
        MultiShot
    }

    public class MediaList
    {
        public List<MediaItem> Items { get; set; } = new List<MediaItem>();
    }

    public class MediaItem
    {
        public DateTime Created { get; set; }
        public string Directory { get; set; }
        public string Name { get; set; }
        public DateTime Modified { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public enum FrameRate
    {
        R240 = 0,
        R120 = 1,
        R100 = 2,
        R90 = 3,
        R80 = 4,
        R60 = 5,
        R50 = 6,
        R48 = 7,
        R30 = 8,
        R25 = 9,
        R24 = 10,
        R15 = 11,
        R12_5 = 12,
    }


    public enum VideoResolution
    {
        R_4KSuperView = 2,
        R_4K = 1,
        R2_7KSuperView = 5,
        R2_7K = 4,
        R2_7K43 = 6,
        R1440 = 7,
        R1080SuperView = 8,
        R1080 = 9,
        R960 = 10,
        R720SuperView = 11,
        R720 = 12,
        RWvga = 13,
    }


    public enum SubVideoMode
    {
        Video = 0,
        TimeLapseVideo = 1,
        VideoPhoto = 2,
        Looping = 3,
    }

    public enum CameraSubMode
    {
        VideoSinglePicBurst = 0,
        TlVideoContinuesTimeLapse = 1,
        VideoPhotoNightPhotoNightLapse = 2,
    }

    public enum CameraMode
    {
        Video = 0,
        Photo = 1,
        MultiShot = 2,
    }

    public enum BatteryLevel
    {
        Charging = 4,
        Full = 3,
        Halfway = 2,
        Low = 1,
        Empty = 0,
    }

    public class GoproCameraInfo
    {
        public CameraStatus Status { get; set; }
        public CameraSettings Settings { get; set; }
    }

    public class CameraSettings
    {
        public SubVideoMode? SubVideoMode { get; set; }
        public VideoResolution? VideoResolution { get; set; }
        public FrameRate? FrameRate { get; set; }
    }

    public class CameraStatus
    {
        public bool IsBatteryAvailable { get; set; }
        public BatteryLevel BatteryLevel { get; set; }
        public CameraMode Mode { get; set; }
        public CameraSubMode SubMode { get; set; }
        public int RecordDuration { get; set; }
        public int MultiShotPicturesTaken { get; set; }
        public int NumberOfClients { get; set; }
        public bool IsStreaming { get; set; }
        public bool IsSdCard { get; set; }
        public int RemainingPhotos { get; set; }
        public int RemainingVideoTime { get; set; }
        public int BatchPhotosTaken { get; set; }
        public int NumberOfVideosShot { get; set; }
        public int NumberOfAllPhotos { get; set; }
        public int NumberOfAllVideos { get; set; }
        public bool IsRecording { get; set; }
        public int SdFreeSpace { get; set; }
    }

    public interface IGoProCamera:IDisposable
    {
        Task<GoproCameraInfo> GetStatus(CancellationToken cancel);
        Task SetMode(GoProMode mode,CancellationToken cancel);
        Task Start(CancellationToken cancel);
        Task Stop(CancellationToken cancel);
        Task<MediaList> GetMediaList(CancellationToken cancel);
        Task DownloadFile(string sourceDirName, string sourceFileName, string destFileName, CancellationToken cancel);
        Task DownloadThumbnail(string sourceDirName, string sourceFileName, string destFileName, CancellationToken cancel);
    }
}