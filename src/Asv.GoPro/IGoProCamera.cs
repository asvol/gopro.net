﻿using System;
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

    public enum GoProFileType
    {
        Unknown,
        Video,
        Photo,
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
        public GoProFileType Type { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

  

    public interface IGoProCamera:IDisposable
    {
        Task<GoProStatus> GetStatus(CancellationToken cancel);
        Task SetMode(GoProMode mode,CancellationToken cancel);
        Task Start(CancellationToken cancel);
        Task Stop(CancellationToken cancel);
        Task<MediaList> GetMediaList(CancellationToken cancel);
        Task DownloadFile(string sourceDirName, string sourceFileName, string destFileName, CancellationToken cancel);
        Task DownloadThumbnail(string sourceDirName, string sourceFileName, string destFileName, CancellationToken cancel);
        Task<string> GetJsonSchema(CancellationToken cancel);
        Task<string> GetJsonStatus(CancellationToken cancel);
    }
}