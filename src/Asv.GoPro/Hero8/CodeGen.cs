// MIT License
//
// Copyright (c) Asvol 2020 https://github.com/asvol
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// This code was generate by tool Asv.GoPro version v1.0.0-10-g25f6c43
// 
// GoPro info 
// Protocol version : 4
// Protocol schema version : 5

using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asv.GoPro
{
    public class GoProStatus
    {
        private readonly JObject _json;
        private Status _status;

        public GoProStatus(string json) : this(JsonConvert.DeserializeObject<JObject>(json))
        {

        }

        private GoProStatus(JObject json)
        {
            _json = json;
        }

        public Status Status => _status ?? (_status = new Status(_json["status"].ToObject<JObject>()));
    }

    public class StatusApp
    {
        private readonly JObject _status;
        public StatusApp(JObject status)
        {
            _status = status;
        }
        public int VideoSelectedFlatmode => _status["71"].ToObject<int>();
        public int PhotoSelectedFlatmode => _status["72"].ToObject<int>();
        public int TimelapseSelectedFlatmode => _status["73"].ToObject<int>();
        public int DigitalZoom => _status["75"].ToObject<int>();
        public int CurrentMode => _status["89"].ToObject<int>();
        public int ProtuneDefault => _status["90"].ToObject<int>();
        public int ActiveVideoPresets => _status["93"].ToObject<int>();
        public int ActivePhotoPresets => _status["94"].ToObject<int>();
        public int ActiveTimelapsePresets => _status["95"].ToObject<int>();
        public int ActivePresetsGroup => _status["96"].ToObject<int>();
        public int ActivePreset => _status["97"].ToObject<int>();
        public int PresetModified => _status["98"].ToObject<int>();
        public int CaptureDelayActive => _status["101"].ToObject<int>();
    }
    public class StatusBroadcast
    {
        private readonly JObject _status;
        public StatusBroadcast(JObject status)
        {
            _status = status;
        }
        public int BroadcastProgressCounter => _status["14"].ToObject<int>();
        public int BroadcastViewersCount => _status["15"].ToObject<int>();
        public int BroadcastBstatus => _status["16"].ToObject<int>();
    }
    public class StatusFwupdate
    {
        private readonly JObject _status;
        public StatusFwupdate(JObject status)
        {
            _status = status;
        }
        public int OtaStatus => _status["41"].ToObject<int>();
        public int DownloadCancelRequestPending => _status["42"].ToObject<int>();
    }
    public class StatusLiveview
    {
        private readonly JObject _status;
        public StatusLiveview(JObject status)
        {
            _status = status;
        }
        public int ExposureSelectType => _status["65"].ToObject<int>();
        public int ExposureSelectX => _status["66"].ToObject<int>();
        public int ExposureSelectY => _status["67"].ToObject<int>();
    }
    public class StatusMultiShot
    {
        private readonly JObject _status;
        public StatusMultiShot(JObject status)
        {
            _status = status;
        }
        public int MultiShotCountDown => _status["49"].ToObject<int>();
    }
    public class StatusPhoto
    {
        private readonly JObject _status;
        public StatusPhoto(JObject status)
        {
            _status = status;
        }
    }
    public class StatusSetup
    {
        private readonly JObject _status;
        public StatusSetup(JObject status)
        {
            _status = status;
        }
        public string DateTime => _status["40"].ToObject<string>();
    }
    public class StatusStorage
    {
        private readonly JObject _status;
        public StatusStorage(JObject status)
        {
            _status = status;
        }
        public int SdStatus => _status["33"].ToObject<int>();
        public int RemainingPhotos => _status["34"].ToObject<int>();
        public int RemainingVideoTime => _status["35"].ToObject<int>();
        public int NumGroupPhotos => _status["36"].ToObject<int>();
        public int NumGroupVideos => _status["37"].ToObject<int>();
        public int NumTotalPhotos => _status["38"].ToObject<int>();
        public int NumTotalVideos => _status["39"].ToObject<int>();
        public int RemainingSpace => _status["54"].ToObject<int>();
        public int NumHilights => _status["58"].ToObject<int>();
        public int LastHilightTimeMsec => _status["59"].ToObject<int>();
        public int RemainingTimelapseTime => _status["64"].ToObject<int>();
        public int RemainingLiveBursts => _status["99"].ToObject<int>();
        public int NumTotalLiveBursts => _status["100"].ToObject<int>();
    }
    public class StatusStream
    {
        private readonly JObject _status;
        public StatusStream(JObject status)
        {
            _status = status;
        }
        public int Enable => _status["32"].ToObject<int>();
        public int Supported => _status["55"].ToObject<int>();
    }
    public class StatusSystem
    {
        private readonly JObject _status;
        public StatusSystem(JObject status)
        {
            _status = status;
        }
        public int InternalBatteryPresent => _status["1"].ToObject<int>();
        public int InternalBatteryLevel => _status["2"].ToObject<int>();
        public int ExternalBatteryPresent => _status["3"].ToObject<int>();
        public int ExternalBatteryLevel => _status["4"].ToObject<int>();
        public int SystemHot => _status["6"].ToObject<int>();
        public int SystemBusy => _status["8"].ToObject<int>();
        public int QuickCaptureActive => _status["9"].ToObject<int>();
        public int EncodingActive => _status["10"].ToObject<int>();
        public int LcdLockActive => _status["11"].ToObject<int>();
        public int CameraLocateActive => _status["45"].ToObject<int>();
        public int CurrentTimeMsec => _status["57"].ToObject<int>();
        public int NextPollMsec => _status["60"].ToObject<int>();
        public int AnalyticsReady => _status["61"].ToObject<int>();
        public int AnalyticsSize => _status["62"].ToObject<int>();
        public int InContextualMenu => _status["63"].ToObject<int>();
        public int GpsStatus => _status["68"].ToObject<int>();
        public int InternalBatteryPercentage => _status["70"].ToObject<int>();
        public int AccMicStatus => _status["74"].ToObject<int>();
        public int DigitalZoomActive => _status["77"].ToObject<int>();
        public int MobileFriendlyVideo => _status["78"].ToObject<int>();
        public int FirstTimeUse => _status["79"].ToObject<int>();
        public int SystemReady => _status["82"].ToObject<int>();
        public int BattOkayForOta => _status["83"].ToObject<int>();
        public int VideoLowTempAlert => _status["85"].ToObject<int>();
        public int ActualOrientation => _status["86"].ToObject<int>();
        public int LogsReady => _status["91"].ToObject<int>();
        public int Timewarp1xActive => _status["92"].ToObject<int>();
        public int BorgMicStatus => _status["102"].ToObject<int>();
    }
    public class StatusVideo
    {
        private readonly JObject _status;
        public StatusVideo(JObject status)
        {
            _status = status;
        }
        public int VideoProgressCounter => _status["13"].ToObject<int>();
        public int ZoomWhileEncoding => _status["88"].ToObject<int>();
    }
    public class StatusWireless
    {
        private readonly JObject _status;
        public StatusWireless(JObject status)
        {
            _status = status;
        }
        public int Enable => _status["17"].ToObject<int>();
        public int State => _status["19"].ToObject<int>();
        public int Type => _status["20"].ToObject<int>();
        public int PairTime => _status["21"].ToObject<int>();
        public int State1 => _status["22"].ToObject<int>();
        public int ScanTimeMsec => _status["23"].ToObject<int>();
        public int ProvisionStatus => _status["24"].ToObject<int>();
        public int RemoteControlVersion => _status["26"].ToObject<int>();
        public int RemoteControlConnected => _status["27"].ToObject<int>();
        public int Pairing => _status["28"].ToObject<int>();
        public string WlanSsid => _status["29"].ToObject<string>();
        public string ApSsid => _status["30"].ToObject<string>();
        public int AppCount => _status["31"].ToObject<int>();
        public int WifiBars => _status["56"].ToObject<int>();
        public int ApState => _status["69"].ToObject<int>();
        public int WirelessBand => _status["76"].ToObject<int>();
        public int Band5ghzAvail => _status["81"].ToObject<int>();
    }

    public class Status
    {
        private readonly JObject _status;

        public Status(JObject status)
        {
            _status = status;
        }

        private static StatusApp _statusApp;
        public StatusApp App => _statusApp ?? (_statusApp = new StatusApp(_status));
        private static StatusBroadcast _statusBroadcast;
        public StatusBroadcast Broadcast => _statusBroadcast ?? (_statusBroadcast = new StatusBroadcast(_status));
        private static StatusFwupdate _statusFwupdate;
        public StatusFwupdate Fwupdate => _statusFwupdate ?? (_statusFwupdate = new StatusFwupdate(_status));
        private static StatusLiveview _statusLiveview;
        public StatusLiveview Liveview => _statusLiveview ?? (_statusLiveview = new StatusLiveview(_status));
        private static StatusMultiShot _statusMultiShot;
        public StatusMultiShot MultiShot => _statusMultiShot ?? (_statusMultiShot = new StatusMultiShot(_status));
        private static StatusPhoto _statusPhoto;
        public StatusPhoto Photo => _statusPhoto ?? (_statusPhoto = new StatusPhoto(_status));
        private static StatusSetup _statusSetup;
        public StatusSetup Setup => _statusSetup ?? (_statusSetup = new StatusSetup(_status));
        private static StatusStorage _statusStorage;
        public StatusStorage Storage => _statusStorage ?? (_statusStorage = new StatusStorage(_status));
        private static StatusStream _statusStream;
        public StatusStream Stream => _statusStream ?? (_statusStream = new StatusStream(_status));
        private static StatusSystem _statusSystem;
        public StatusSystem System => _statusSystem ?? (_statusSystem = new StatusSystem(_status));
        private static StatusVideo _statusVideo;
        public StatusVideo Video => _statusVideo ?? (_statusVideo = new StatusVideo(_status));
        private static StatusWireless _statusWireless;
        public StatusWireless Wireless => _statusWireless ?? (_statusWireless = new StatusWireless(_status));

    }
}
