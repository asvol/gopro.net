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

    #region Info

    public class CameraInfo
    {
        private readonly JToken _jToken;

        public CameraInfo(JToken jToken)
        {
            _jToken = jToken;
        }

        public int ModelNumber => _jToken["model_number"].ToObject<int>();
        public string ModelName => _jToken["model_name"].ToObject<string>();
        public string FirmwareVersion => _jToken["firmware_version"].ToObject<string>();
        public string SerialNumber => _jToken["serial_number"].ToObject<string>();
        public string BoardType => _jToken["board_type"].ToObject<string>();
        public string ApMac => _jToken["ap_mac"].ToObject<string>();
        public string ApSsid => _jToken["ap_ssid"].ToObject<string>();
        public string ApHasDefaultCredentials => _jToken["ap_has_default_credentials"].ToObject<string>();
        public string GitSha1 => _jToken["git_sha1"].ToObject<string>();
        public int Capabilities => _jToken["capabilities"].ToObject<int>();
        public int LensCount => _jToken["lens_count"].ToObject<int>();
        public int UpdateRequired => _jToken["update_required"].ToObject<int>();
    }

    #endregion

    public class GoProStatus
    {
        private readonly JObject _json;
        private Status _status;
        private Settings _settings;

        public GoProStatus(string json) : this(JsonConvert.DeserializeObject<JObject>(json))
        {

        }

        private GoProStatus(JObject json)
        {
            _json = json;
        }

        public Status Status => _status ?? (_status = new Status(_json["status"].ToObject<JObject>()));
        public Settings Settings => _settings ?? (_settings = new Settings(_json["settings"].ToObject<JObject>()));
    }

    #region Status



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

    #endregion

    #region Settings

    public class SettingsIdAttribute : Attribute
    {
        public int ID { get; }

        public SettingsIdAttribute(int id)
        {
            ID = id;
        }
    }

    public enum AntiminusflickerSettingsEnum : int
    {
        /// <summary>
        /// 50Hz
        /// </summary>
        [SettingsId(3)]
        Opt50hz = 1,
        /// <summary>
        /// 60Hz
        /// </summary>
        [SettingsId(2)]
        Opt60hz = 0,

    }
    public enum AudioInputSettingsEnum : int
    {
        /// <summary>
        /// Line In
        /// </summary>
        [SettingsId(5)]
        OptLineIn = 5,
        /// <summary>
        /// Powered Mic
        /// </summary>
        [SettingsId(3)]
        OptPoweredMic = 3,
        /// <summary>
        /// Powered Mic+
        /// </summary>
        [SettingsId(4)]
        OptPoweredMicplus = 4,
        /// <summary>
        /// Standard Mic
        /// </summary>
        [SettingsId(1)]
        OptStandardMic = 1,
        /// <summary>
        /// Standard Mic+
        /// </summary>
        [SettingsId(2)]
        OptStandardMicplus = 2,

    }
    public enum AudioProtuneSettingsEnum : int
    {
        /// <summary>
        /// OFF
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// ON
        /// </summary>
        [SettingsId(1)]
        OptOn = 1,

    }
    public enum AutoLockSettingsEnum : int
    {
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(3)]
        OptOff = 3,
        /// <summary>
        /// On
        /// </summary>
        [SettingsId(6)]
        OptOn = 6,

    }
    public enum AutoOffSettingsEnum : int
    {
        /// <summary>
        /// 15 MIN
        /// </summary>
        [SettingsId(6)]
        Opt15Min = 6,
        /// <summary>
        /// 30 MIN
        /// </summary>
        [SettingsId(7)]
        Opt30Min = 7,
        /// <summary>
        /// 5 MIN
        /// </summary>
        [SettingsId(4)]
        Opt5Min = 4,
        /// <summary>
        /// NEVER
        /// </summary>
        [SettingsId(0)]
        OptNever = 0,

    }
    public enum BeepsSettingsEnum : int
    {
        /// <summary>
        /// High
        /// </summary>
        [SettingsId(100)]
        OptHigh = 100,
        /// <summary>
        /// Low
        /// </summary>
        [SettingsId(40)]
        OptLow = 40,
        /// <summary>
        /// Medium
        /// </summary>
        [SettingsId(70)]
        OptMedium = 70,
        /// <summary>
        /// Mute
        /// </summary>
        [SettingsId(0)]
        OptMute = 0,

    }
    public enum BitRate67SettingsEnum : int
    {
        /// <summary>
        /// 1 Mbps
        /// </summary>
        [SettingsId(1000000)]
        Opt1Mbps = 1000000,
        /// <summary>
        /// 1.2 Mbps
        /// </summary>
        [SettingsId(1200000)]
        Opt1dot2Mbps = 1200000,
        /// <summary>
        /// 1.6 Mbps
        /// </summary>
        [SettingsId(1600000)]
        Opt1dot6Mbps = 1600000,
        /// <summary>
        /// 2 Mbps
        /// </summary>
        [SettingsId(2000000)]
        Opt2Mbps = 2000000,
        /// <summary>
        /// 2.4 Mbps
        /// </summary>
        [SettingsId(2400000)]
        Opt2dot4Mbps = 2400000,
        /// <summary>
        /// 2.5 Mbps
        /// </summary>
        [SettingsId(2500000)]
        Opt2dot5Mbps = 2500000,
        /// <summary>
        /// 250 Kbps
        /// </summary>
        [SettingsId(250000)]
        Opt250Kbps = 250000,
        /// <summary>
        /// 4 Mbps
        /// </summary>
        [SettingsId(4000000)]
        Opt4Mbps = 4000000,
        /// <summary>
        /// 400 Kbps
        /// </summary>
        [SettingsId(400000)]
        Opt400Kbps = 400000,
        /// <summary>
        /// 600 Kbps
        /// </summary>
        [SettingsId(600000)]
        Opt600Kbps = 600000,
        /// <summary>
        /// 700 Kbps
        /// </summary>
        [SettingsId(700000)]
        Opt700Kbps = 700000,
        /// <summary>
        /// 800 Kbps
        /// </summary>
        [SettingsId(800000)]
        Opt800Kbps = 800000,

    }
    public enum BitRate124SettingsEnum : int
    {
        /// <summary>
        /// High
        /// </summary>
        [SettingsId(1)]
        OptHigh = 1,
        /// <summary>
        /// Standard
        /// </summary>
        [SettingsId(100)]
        OptStandard = 0,

    }
    public enum BnrFramePerSecondSettingsEnum : int
    {
        /// <summary>
        /// 30
        /// </summary>
        [SettingsId(8)]
        Opt30 = 8,

    }
    public enum BnrResolutionSettingsEnum : int
    {
        /// <summary>
        /// 1080
        /// </summary>
        [SettingsId(9)]
        Opt1080 = 9,

    }
    public enum BurstRateSettingsEnum : int
    {
        /// <summary>
        /// 10 Photos / 1 Second
        /// </summary>
        [SettingsId(2)]
        Opt10Photos__1Second = 2,
        /// <summary>
        /// 10 Photos / 3 Seconds
        /// </summary>
        [SettingsId(4)]
        Opt10Photos__3Seconds = 4,
        /// <summary>
        /// 3 Photos / 1 Second
        /// </summary>
        [SettingsId(0)]
        Opt3Photos__1Second = 0,
        /// <summary>
        /// 30 Photos / 1 Second
        /// </summary>
        [SettingsId(5)]
        Opt30Photos__1Second = 5,
        /// <summary>
        /// 30 Photos / 10 Seconds
        /// </summary>
        [SettingsId(11)]
        Opt30Photos__10Seconds = 11,
        /// <summary>
        /// 30 Photos / 3 Seconds
        /// </summary>
        [SettingsId(7)]
        Opt30Photos__3Seconds = 7,
        /// <summary>
        /// 30 Photos / 6 Seconds
        /// </summary>
        [SettingsId(8)]
        Opt30Photos__6Seconds = 8,
        /// <summary>
        /// 5 Photos / 1 Second
        /// </summary>
        [SettingsId(1)]
        Opt5Photos__1Second = 1,
        /// <summary>
        /// 60 Photos / 10 Seconds
        /// </summary>
        [SettingsId(13)]
        Opt60Photos__10Seconds = 13,
        /// <summary>
        /// 60 Photos / 6 Seconds
        /// </summary>
        [SettingsId(12)]
        Opt60Photos__6Seconds = 12,
        /// <summary>
        /// Auto
        /// </summary>
        [SettingsId(9)]
        OptAuto = 9,

    }
    public enum ClipsSettingsEnum : int
    {
        /// <summary>
        /// 15 Seconds
        /// </summary>
        [SettingsId(1)]
        Opt15Seconds = 1,
        /// <summary>
        /// 30 Seconds
        /// </summary>
        [SettingsId(2)]
        Opt30Seconds = 2,
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,

    }
    public enum ColorSettingsEnum : int
    {
        /// <summary>
        /// Flat
        /// </summary>
        [SettingsId(1)]
        OptFlat = 1,
        /// <summary>
        /// GoPro
        /// </summary>
        [SettingsId(0)]
        OptGopro = 0,

    }
    public enum DefaultPresetSettingsEnum : int
    {
        /// <summary>
        /// Activity
        /// </summary>
        [SettingsId(1)]
        OptActivity = 1,
        /// <summary>
        /// Burst
        /// </summary>
        [SettingsId(6)]
        OptBurst = 65538,
        /// <summary>
        /// Cinematic
        /// </summary>
        [SettingsId(2)]
        OptCinematic = 2,
        /// <summary>
        /// Last Used
        /// </summary>
        [SettingsId(15)]
        OptLastUsed = 65535,
        /// <summary>
        /// Live Burst
        /// </summary>
        [SettingsId(5)]
        OptLiveBurst = 65537,
        /// <summary>
        /// Night
        /// </summary>
        [SettingsId(7)]
        OptNight = 65539,
        /// <summary>
        /// Night Lapse
        /// </summary>
        [SettingsId(9)]
        OptNightLapse = 131074,
        /// <summary>
        /// Photo
        /// </summary>
        [SettingsId(4)]
        OptPhoto = 65536,
        /// <summary>
        /// Slo-Mo
        /// </summary>
        [SettingsId(3)]
        OptSlominusmo = 3,
        /// <summary>
        /// Standard
        /// </summary>
        [SettingsId(0)]
        OptStandard = 0,
        /// <summary>
        /// Time Lapse
        /// </summary>
        [SettingsId(8)]
        OptTimeLapse = 131073,
        /// <summary>
        /// Time Warp
        /// </summary>
        [SettingsId(10)]
        OptTimeWarp = 131072,

    }
    public enum EvCompSettingsEnum : int
    {
        /// <summary>
        /// 0.0
        /// </summary>
        [SettingsId(4)]
        Opt0dot0 = 4,
        /// <summary>
        /// 0.5
        /// </summary>
        [SettingsId(3)]
        Opt0dot5 = 3,
        /// <summary>
        /// -0.5
        /// </summary>
        [SettingsId(5)]
        OptMinus0dot5 = 5,
        /// <summary>
        /// 1.0
        /// </summary>
        [SettingsId(2)]
        Opt1dot0 = 2,
        /// <summary>
        /// -1.0
        /// </summary>
        [SettingsId(6)]
        OptMinus1dot0 = 6,
        /// <summary>
        /// 1.5
        /// </summary>
        [SettingsId(1)]
        Opt1dot5 = 1,
        /// <summary>
        /// -1.5
        /// </summary>
        [SettingsId(7)]
        OptMinus1dot5 = 7,
        /// <summary>
        /// 2.0
        /// </summary>
        [SettingsId(0)]
        Opt2dot0 = 0,
        /// <summary>
        /// -2.0
        /// </summary>
        [SettingsId(8)]
        OptMinus2dot0 = 8,

    }
    public enum FormatSettingsEnum : int
    {
        /// <summary>
        /// Photo
        /// </summary>
        [SettingsId(20)]
        OptPhoto20 = 20,
        /// <summary>
        /// Photo
        /// </summary>
        [SettingsId(21)]
        OptPhoto21 = 21,
        /// <summary>
        /// Video
        /// </summary>
        [SettingsId(13)]
        OptVideo13 = 13,
        /// <summary>
        /// Video
        /// </summary>
        [SettingsId(26)]
        OptVideo26 = 26,

    }
    public enum FramePerSecondSettingsEnum : int
    {
        /// <summary>
        /// 30
        /// </summary>
        [SettingsId(8)]
        Opt30 = 8,

    }
    public enum FramesPerSecondSettingsEnum : int
    {
        /// <summary>
        /// 100
        /// </summary>
        [SettingsId(2)]
        Opt100 = 2,
        /// <summary>
        /// 120
        /// </summary>
        [SettingsId(1)]
        Opt120 = 1,
        /// <summary>
        /// 200
        /// </summary>
        [SettingsId(13)]
        Opt200 = 13,
        /// <summary>
        /// 24
        /// </summary>
        [SettingsId(10)]
        Opt24 = 10,
        /// <summary>
        /// 240
        /// </summary>
        [SettingsId(0)]
        Opt240 = 0,
        /// <summary>
        /// 25
        /// </summary>
        [SettingsId(9)]
        Opt25 = 9,
        /// <summary>
        /// 30
        /// </summary>
        [SettingsId(8)]
        Opt30 = 8,
        /// <summary>
        /// 50
        /// </summary>
        [SettingsId(6)]
        Opt50 = 6,
        /// <summary>
        /// 60
        /// </summary>
        [SettingsId(5)]
        Opt60 = 5,

    }
    public enum GopSizeSettingsEnum : int
    {
        /// <summary>
        /// 15
        /// </summary>
        [SettingsId(15)]
        Opt15 = 15,
        /// <summary>
        /// 3
        /// </summary>
        [SettingsId(3)]
        Opt3 = 3,
        /// <summary>
        /// 30
        /// </summary>
        [SettingsId(30)]
        Opt30 = 30,
        /// <summary>
        /// 4
        /// </summary>
        [SettingsId(4)]
        Opt4 = 4,
        /// <summary>
        /// 8
        /// </summary>
        [SettingsId(8)]
        Opt8 = 8,
        /// <summary>
        /// Default
        /// </summary>
        [SettingsId(0)]
        OptDefault = 0,

    }
    public enum GpsSettingsEnum : int
    {
        /// <summary>
        /// OFF
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// ON
        /// </summary>
        [SettingsId(1)]
        OptOn = 1,

    }
    public enum HypersmoothSettingsEnum : int
    {
        /// <summary>
        /// Boost
        /// </summary>
        [SettingsId(3)]
        OptBoost = 3,
        /// <summary>
        /// High
        /// </summary>
        [SettingsId(2)]
        OptHigh = 2,
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// On
        /// </summary>
        [SettingsId(1)]
        OptOn = 1,

    }
    public enum IdrIntervalSettingsEnum : int
    {
        /// <summary>
        /// 1
        /// </summary>
        [SettingsId(1)]
        Opt1 = 1,
        /// <summary>
        /// 2
        /// </summary>
        [SettingsId(2)]
        Opt2 = 2,
        /// <summary>
        /// 4
        /// </summary>
        [SettingsId(4)]
        Opt4 = 4,
        /// <summary>
        /// Default
        /// </summary>
        [SettingsId(0)]
        OptDefault = 0,

    }
    public enum Interval5SettingsEnum : int
    {
        /// <summary>
        /// 0.5 Seconds
        /// </summary>
        [SettingsId(0)]
        Opt0dot5Seconds = 0,
        /// <summary>
        /// 1 Minute
        /// </summary>
        [SettingsId(100)]
        Opt1Minute = 6,
        /// <summary>
        /// 1 Second
        /// </summary>
        [SettingsId(1)]
        Opt1Second = 1,
        /// <summary>
        /// 10 Seconds
        /// </summary>
        [SettingsId(4)]
        Opt10Seconds = 4,
        /// <summary>
        /// 2 Minutes
        /// </summary>
        [SettingsId(7)]
        Opt2Minutes = 7,
        /// <summary>
        /// 2 Seconds
        /// </summary>
        [SettingsId(2)]
        Opt2Seconds = 2,
        /// <summary>
        /// 30 Minutes
        /// </summary>
        [SettingsId(9)]
        Opt30Minutes = 9,
        /// <summary>
        /// 30 Seconds
        /// </summary>
        [SettingsId(5)]
        Opt30Seconds = 5,
        /// <summary>
        /// 5 Minutes
        /// </summary>
        [SettingsId(8)]
        Opt5Minutes = 8,
        /// <summary>
        /// 5 Seconds
        /// </summary>
        [SettingsId(3)]
        Opt5Seconds = 3,
        /// <summary>
        /// 60 Minutes
        /// </summary>
        [SettingsId(10)]
        Opt60Minutes = 10,

    }
    public enum Interval6SettingsEnum : int
    {
        /// <summary>
        /// 120 Minutes
        /// </summary>
        [SettingsId(4)]
        Opt120Minutes = 4,
        /// <summary>
        /// 20 Minutes
        /// </summary>
        [SettingsId(2)]
        Opt20Minutes = 2,
        /// <summary>
        /// 5 Minutes
        /// </summary>
        [SettingsId(1)]
        Opt5Minutes = 1,
        /// <summary>
        /// 60 Minutes
        /// </summary>
        [SettingsId(3)]
        Opt60Minutes = 3,
        /// <summary>
        /// Max
        /// </summary>
        [SettingsId(0)]
        OptMax = 0,

    }
    public enum Interval30SettingsEnum : int
    {
        /// <summary>
        /// 0.5 Seconds
        /// </summary>
        [SettingsId(110)]
        Opt0dot5Seconds = 0,
        /// <summary>
        /// 1 Minute
        /// </summary>
        [SettingsId(111)]
        Opt1Minute = 60,
        /// <summary>
        /// 1 Second
        /// </summary>
        [SettingsId(109)]
        Opt1Second = 1,
        /// <summary>
        /// 10 Seconds
        /// </summary>
        [SettingsId(106)]
        Opt10Seconds = 10,
        /// <summary>
        /// 2 Minutes
        /// </summary>
        [SettingsId(103)]
        Opt2Minutes = 120,
        /// <summary>
        /// 2 Seconds
        /// </summary>
        [SettingsId(108)]
        Opt2Seconds = 2,
        /// <summary>
        /// 30 Minutes
        /// </summary>
        [SettingsId(101)]
        Opt30Minutes = 1800,
        /// <summary>
        /// 30 Seconds
        /// </summary>
        [SettingsId(105)]
        Opt30Seconds = 30,
        /// <summary>
        /// 5 Minutes
        /// </summary>
        [SettingsId(102)]
        Opt5Minutes = 300,
        /// <summary>
        /// 5 Seconds
        /// </summary>
        [SettingsId(107)]
        Opt5Seconds = 5,
        /// <summary>
        /// 60 Minutes
        /// </summary>
        [SettingsId(100)]
        Opt60Minutes = 3600,

    }
    public enum Interval32SettingsEnum : int
    {
        /// <summary>
        /// 1 Minute
        /// </summary>
        [SettingsId(60)]
        Opt1Minute = 60,
        /// <summary>
        /// 10 Seconds
        /// </summary>
        [SettingsId(10)]
        Opt10Seconds = 10,
        /// <summary>
        /// 15 Seconds
        /// </summary>
        [SettingsId(15)]
        Opt15Seconds = 15,
        /// <summary>
        /// 2 Minutes
        /// </summary>
        [SettingsId(120)]
        Opt2Minutes = 120,
        /// <summary>
        /// 20 Seconds
        /// </summary>
        [SettingsId(20)]
        Opt20Seconds = 20,
        /// <summary>
        /// 30 Minutes
        /// </summary>
        [SettingsId(1800)]
        Opt30Minutes = 1800,
        /// <summary>
        /// 30 Seconds
        /// </summary>
        [SettingsId(30)]
        Opt30Seconds = 30,
        /// <summary>
        /// 4 Seconds
        /// </summary>
        [SettingsId(4)]
        Opt4Seconds = 4,
        /// <summary>
        /// 5 Minutes
        /// </summary>
        [SettingsId(300)]
        Opt5Minutes = 300,
        /// <summary>
        /// 5 Seconds
        /// </summary>
        [SettingsId(5)]
        Opt5Seconds = 5,
        /// <summary>
        /// 60 Minutes
        /// </summary>
        [SettingsId(3600)]
        Opt60Minutes = 3600,
        /// <summary>
        /// Auto
        /// </summary>
        [SettingsId(3601)]
        OptAuto = 3601,

    }
    public enum IsoMax13SettingsEnum : int
    {
        /// <summary>
        /// 100
        /// </summary>
        [SettingsId(8)]
        Opt100 = 8,
        /// <summary>
        /// 1600
        /// </summary>
        [SettingsId(1)]
        Opt1600 = 1,
        /// <summary>
        /// 200
        /// </summary>
        [SettingsId(7)]
        Opt200 = 7,
        /// <summary>
        /// 3200
        /// </summary>
        [SettingsId(3)]
        Opt3200 = 3,
        /// <summary>
        /// 400
        /// </summary>
        [SettingsId(2)]
        Opt400 = 2,
        /// <summary>
        /// 6400
        /// </summary>
        [SettingsId(0)]
        Opt6400 = 0,
        /// <summary>
        /// 800
        /// </summary>
        [SettingsId(4)]
        Opt800 = 4,

    }
    public enum IsoMax24SettingsEnum : int
    {
        /// <summary>
        /// 100
        /// </summary>
        [SettingsId(3)]
        Opt100 = 3,
        /// <summary>
        /// 1600
        /// </summary>
        [SettingsId(4)]
        Opt1600 = 4,
        /// <summary>
        /// 200
        /// </summary>
        [SettingsId(2)]
        Opt200 = 2,
        /// <summary>
        /// 3200
        /// </summary>
        [SettingsId(5)]
        Opt3200 = 5,
        /// <summary>
        /// 400
        /// </summary>
        [SettingsId(1)]
        Opt400 = 1,
        /// <summary>
        /// 800
        /// </summary>
        [SettingsId(0)]
        Opt800 = 0,

    }
    public enum IsoMax37SettingsEnum : int
    {
        /// <summary>
        /// 100
        /// </summary>
        [SettingsId(3)]
        Opt100 = 3,
        /// <summary>
        /// 1600
        /// </summary>
        [SettingsId(4)]
        Opt1600 = 4,
        /// <summary>
        /// 200
        /// </summary>
        [SettingsId(2)]
        Opt200 = 2,
        /// <summary>
        /// 3200
        /// </summary>
        [SettingsId(5)]
        Opt3200 = 5,
        /// <summary>
        /// 400
        /// </summary>
        [SettingsId(1)]
        Opt400 = 1,
        /// <summary>
        /// 800
        /// </summary>
        [SettingsId(0)]
        Opt800 = 0,

    }
    public enum IsoMin75SettingsEnum : int
    {
        /// <summary>
        /// 100
        /// </summary>
        [SettingsId(3)]
        Opt100 = 3,
        /// <summary>
        /// 1600
        /// </summary>
        [SettingsId(4)]
        Opt1600 = 4,
        /// <summary>
        /// 200
        /// </summary>
        [SettingsId(2)]
        Opt200 = 2,
        /// <summary>
        /// 3200
        /// </summary>
        [SettingsId(5)]
        Opt3200 = 5,
        /// <summary>
        /// 400
        /// </summary>
        [SettingsId(1)]
        Opt400 = 1,
        /// <summary>
        /// 800
        /// </summary>
        [SettingsId(0)]
        Opt800 = 0,

    }
    public enum IsoMin76SettingsEnum : int
    {
        /// <summary>
        /// 100
        /// </summary>
        [SettingsId(3)]
        Opt100 = 3,
        /// <summary>
        /// 1600
        /// </summary>
        [SettingsId(4)]
        Opt1600 = 4,
        /// <summary>
        /// 200
        /// </summary>
        [SettingsId(2)]
        Opt200 = 2,
        /// <summary>
        /// 3200
        /// </summary>
        [SettingsId(5)]
        Opt3200 = 5,
        /// <summary>
        /// 400
        /// </summary>
        [SettingsId(1)]
        Opt400 = 1,
        /// <summary>
        /// 800
        /// </summary>
        [SettingsId(0)]
        Opt800 = 0,

    }
    public enum IsoMin102SettingsEnum : int
    {
        /// <summary>
        /// 100
        /// </summary>
        [SettingsId(8)]
        Opt100 = 8,
        /// <summary>
        /// 1600
        /// </summary>
        [SettingsId(1)]
        Opt1600 = 1,
        /// <summary>
        /// 200
        /// </summary>
        [SettingsId(7)]
        Opt200 = 7,
        /// <summary>
        /// 3200
        /// </summary>
        [SettingsId(3)]
        Opt3200 = 3,
        /// <summary>
        /// 400
        /// </summary>
        [SettingsId(2)]
        Opt400 = 2,
        /// <summary>
        /// 6400
        /// </summary>
        [SettingsId(0)]
        Opt6400 = 0,
        /// <summary>
        /// 800
        /// </summary>
        [SettingsId(4)]
        Opt800 = 4,

    }
    public enum LandscapeLockSettingsEnum : int
    {
        /// <summary>
        /// All
        /// </summary>
        [SettingsId(100)]
        OptAll = 0,
        /// <summary>
        /// Landscape
        /// </summary>
        [SettingsId(5)]
        OptLandscape = 5,
        /// <summary>
        /// Locked
        /// </summary>
        [SettingsId(255)]
        OptLocked = 255,

    }
    public enum LanguageSettingsEnum : int
    {
        /// <summary>
        /// Chinese
        /// </summary>
        [SettingsId(1)]
        OptChinese = 1,
        /// <summary>
        /// Chinese(Traditional)
        /// </summary>
        [SettingsId(11)]
        OptChineseTraditional_ = 11,
        /// <summary>
        /// English
        /// </summary>
        [SettingsId(0)]
        OptEnglish = 0,
        /// <summary>
        /// French
        /// </summary>
        [SettingsId(6)]
        OptFrench = 6,
        /// <summary>
        /// German
        /// </summary>
        [SettingsId(2)]
        OptGerman = 2,
        /// <summary>
        /// Italian
        /// </summary>
        [SettingsId(3)]
        OptItalian = 3,
        /// <summary>
        /// Japanese
        /// </summary>
        [SettingsId(5)]
        OptJapanese = 5,
        /// <summary>
        /// Korean
        /// </summary>
        [SettingsId(7)]
        OptKorean = 7,
        /// <summary>
        /// Portuguese
        /// </summary>
        [SettingsId(8)]
        OptPortuguese = 8,
        /// <summary>
        /// Russian
        /// </summary>
        [SettingsId(9)]
        OptRussian = 9,
        /// <summary>
        /// Spanish
        /// </summary>
        [SettingsId(4)]
        OptSpanish = 4,
        /// <summary>
        /// Swedish
        /// </summary>
        [SettingsId(10)]
        OptSwedish = 10,

    }
    public enum LcdBrightnessSettingsEnum : int
    {
        /// <summary>
        /// 10%
        /// </summary>
        [SettingsId(10)]
        Opt10percent = 10,
        /// <summary>
        /// 100%
        /// </summary>
        [SettingsId(100)]
        Opt100percent = 100,
        /// <summary>
        /// 20%
        /// </summary>
        [SettingsId(20)]
        Opt20percent = 20,
        /// <summary>
        /// 30%
        /// </summary>
        [SettingsId(30)]
        Opt30percent = 30,
        /// <summary>
        /// 40%
        /// </summary>
        [SettingsId(40)]
        Opt40percent = 40,
        /// <summary>
        /// 50%
        /// </summary>
        [SettingsId(50)]
        Opt50percent = 50,
        /// <summary>
        /// 60%
        /// </summary>
        [SettingsId(60)]
        Opt60percent = 60,
        /// <summary>
        /// 70%
        /// </summary>
        [SettingsId(70)]
        Opt70percent = 70,
        /// <summary>
        /// 80%
        /// </summary>
        [SettingsId(80)]
        Opt80percent = 80,
        /// <summary>
        /// 90%
        /// </summary>
        [SettingsId(90)]
        Opt90percent = 90,

    }
    public enum LedSettingsEnum : int
    {
        /// <summary>
        /// All Off
        /// </summary>
        [SettingsId(4)]
        OptAllOff = 0,
        /// <summary>
        /// All On
        /// </summary>
        [SettingsId(3)]
        OptAllOn = 2,
        /// <summary>
        /// Front Off Only
        /// </summary>
        [SettingsId(5)]
        OptFrontOffOnly = 1,

    }
    public enum Lens121SettingsEnum : int
    {
        /// <summary>
        /// Linear
        /// </summary>
        [SettingsId(4)]
        OptLinear = 4,
        /// <summary>
        /// Narrow
        /// </summary>
        [SettingsId(2)]
        OptNarrow = 6,
        /// <summary>
        /// Superview
        /// </summary>
        [SettingsId(3)]
        OptSuperview = 3,
        /// <summary>
        /// Wide
        /// </summary>
        [SettingsId(0)]
        OptWide = 0,

    }
    public enum Lens122SettingsEnum : int
    {
        /// <summary>
        /// Linear
        /// </summary>
        [SettingsId(10)]
        OptLinear = 10,
        /// <summary>
        /// Narrow
        /// </summary>
        [SettingsId(19)]
        OptNarrow = 17,
        /// <summary>
        /// Wide
        /// </summary>
        [SettingsId(101)]
        OptWide = 0,

    }
    public enum Lens123SettingsEnum : int
    {
        /// <summary>
        /// Linear
        /// </summary>
        [SettingsId(10)]
        OptLinear = 10,
        /// <summary>
        /// Narrow
        /// </summary>
        [SettingsId(19)]
        OptNarrow = 17,
        /// <summary>
        /// Wide
        /// </summary>
        [SettingsId(101)]
        OptWide = 0,

    }
    public enum LowLightSettingsEnum : int
    {
        /// <summary>
        /// OFF
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// ON
        /// </summary>
        [SettingsId(1)]
        OptOn = 1,

    }
    public enum LowerLeftSettingsEnum : int
    {
        /// <summary>
        /// Bit Rate
        /// </summary>
        [SettingsId(7)]
        OptBitRate = 7,
        /// <summary>
        /// Burst Rate
        /// </summary>
        [SettingsId(8)]
        OptBurstRate = 8,
        /// <summary>
        /// Clips
        /// </summary>
        [SettingsId(9)]
        OptClips = 9,
        /// <summary>
        /// Color
        /// </summary>
        [SettingsId(10)]
        OptColor = 10,
        /// <summary>
        /// EV Comp
        /// </summary>
        [SettingsId(11)]
        OptEvComp = 11,
        /// <summary>
        /// HyperSmooth
        /// </summary>
        [SettingsId(12)]
        OptHypersmooth = 12,
        /// <summary>
        /// Interval
        /// </summary>
        [SettingsId(13)]
        OptInterval = 13,
        /// <summary>
        /// ISO Max
        /// </summary>
        [SettingsId(15)]
        OptIsoMax = 15,
        /// <summary>
        /// ISO Min
        /// </summary>
        [SettingsId(14)]
        OptIsoMin = 14,
        /// <summary>
        /// Lens
        /// </summary>
        [SettingsId(2)]
        OptLens = 2,
        /// <summary>
        /// Low Light
        /// </summary>
        [SettingsId(4)]
        OptLowLight = 4,
        /// <summary>
        /// Mics
        /// </summary>
        [SettingsId(16)]
        OptMics = 16,
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// Output
        /// </summary>
        [SettingsId(17)]
        OptOutput = 17,
        /// <summary>
        /// Raw Audio
        /// </summary>
        [SettingsId(18)]
        OptRawAudio = 18,
        /// <summary>
        /// Sharpness
        /// </summary>
        [SettingsId(19)]
        OptSharpness = 19,
        /// <summary>
        /// Shutter
        /// </summary>
        [SettingsId(6)]
        OptShutter = 6,
        /// <summary>
        /// SloMo
        /// </summary>
        [SettingsId(3)]
        OptSlomo = 3,
        /// <summary>
        /// Speed
        /// </summary>
        [SettingsId(21)]
        OptSpeed = 21,
        /// <summary>
        /// Timer
        /// </summary>
        [SettingsId(20)]
        OptTimer = 20,
        /// <summary>
        /// White Balance
        /// </summary>
        [SettingsId(5)]
        OptWhiteBalance = 5,
        /// <summary>
        /// Wind
        /// </summary>
        [SettingsId(100)]
        OptWind = 23,
        /// <summary>
        /// Zoom
        /// </summary>
        [SettingsId(1)]
        OptZoom = 1,

    }
    public enum LowerRightSettingsEnum : int
    {
        /// <summary>
        /// Bit Rate
        /// </summary>
        [SettingsId(7)]
        OptBitRate = 7,
        /// <summary>
        /// Burst Rate
        /// </summary>
        [SettingsId(8)]
        OptBurstRate = 8,
        /// <summary>
        /// Clips
        /// </summary>
        [SettingsId(9)]
        OptClips = 9,
        /// <summary>
        /// Color
        /// </summary>
        [SettingsId(10)]
        OptColor = 10,
        /// <summary>
        /// EV Comp
        /// </summary>
        [SettingsId(11)]
        OptEvComp = 11,
        /// <summary>
        /// HyperSmooth
        /// </summary>
        [SettingsId(12)]
        OptHypersmooth = 12,
        /// <summary>
        /// Interval
        /// </summary>
        [SettingsId(13)]
        OptInterval = 13,
        /// <summary>
        /// ISO Max
        /// </summary>
        [SettingsId(15)]
        OptIsoMax = 15,
        /// <summary>
        /// ISO Min
        /// </summary>
        [SettingsId(14)]
        OptIsoMin = 14,
        /// <summary>
        /// Lens
        /// </summary>
        [SettingsId(2)]
        OptLens = 2,
        /// <summary>
        /// Low Light
        /// </summary>
        [SettingsId(4)]
        OptLowLight = 4,
        /// <summary>
        /// Mics
        /// </summary>
        [SettingsId(16)]
        OptMics = 16,
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// Output
        /// </summary>
        [SettingsId(17)]
        OptOutput = 17,
        /// <summary>
        /// Raw Audio
        /// </summary>
        [SettingsId(18)]
        OptRawAudio = 18,
        /// <summary>
        /// Sharpness
        /// </summary>
        [SettingsId(19)]
        OptSharpness = 19,
        /// <summary>
        /// Shutter
        /// </summary>
        [SettingsId(6)]
        OptShutter = 6,
        /// <summary>
        /// SloMo
        /// </summary>
        [SettingsId(3)]
        OptSlomo = 3,
        /// <summary>
        /// Speed
        /// </summary>
        [SettingsId(21)]
        OptSpeed = 21,
        /// <summary>
        /// Timer
        /// </summary>
        [SettingsId(20)]
        OptTimer = 20,
        /// <summary>
        /// White Balance
        /// </summary>
        [SettingsId(5)]
        OptWhiteBalance = 5,
        /// <summary>
        /// Wind
        /// </summary>
        [SettingsId(100)]
        OptWind = 23,
        /// <summary>
        /// Zoom
        /// </summary>
        [SettingsId(1)]
        OptZoom = 1,

    }
    public enum MegapixelsSettingsEnum : int
    {
        /// <summary>
        /// 12MP
        /// </summary>
        [SettingsId(1)]
        Opt12mp = 18,
        /// <summary>
        /// 8MP
        /// </summary>
        [SettingsId(0)]
        Opt8mp = 23,

    }
    public enum MicsSettingsEnum : int
    {
        /// <summary>
        /// Back
        /// </summary>
        [SettingsId(2)]
        OptBack = 2,
        /// <summary>
        /// Front
        /// </summary>
        [SettingsId(1)]
        OptFront = 1,
        /// <summary>
        /// Stereo
        /// </summary>
        [SettingsId(0)]
        OptStereo = 0,

    }
    public enum ModeSettingsEnum : int
    {
        /// <summary>
        /// Burst Photo
        /// </summary>
        [SettingsId(19)]
        OptBurstPhoto = 19,
        /// <summary>
        /// Live Burst
        /// </summary>
        [SettingsId(25)]
        OptLiveBurst = 25,
        /// <summary>
        /// Looping
        /// </summary>
        [SettingsId(15)]
        OptLooping = 15,
        /// <summary>
        /// Night Lapse Photo
        /// </summary>
        [SettingsId(21)]
        OptNightLapsePhoto = 21,
        /// <summary>
        /// Night Lapse Video
        /// </summary>
        [SettingsId(26)]
        OptNightLapseVideo = 26,
        /// <summary>
        /// Night Photo
        /// </summary>
        [SettingsId(18)]
        OptNightPhoto = 18,
        /// <summary>
        /// Photo
        /// </summary>
        [SettingsId(17)]
        OptPhoto = 17,
        /// <summary>
        /// Slo-Mo
        /// </summary>
        [SettingsId(27)]
        OptSlominusmo = 27,
        /// <summary>
        /// Time Lapse Photo
        /// </summary>
        [SettingsId(20)]
        OptTimeLapsePhoto = 20,
        /// <summary>
        /// Time Lapse Video
        /// </summary>
        [SettingsId(13)]
        OptTimeLapseVideo = 13,
        /// <summary>
        /// Time Warp Video
        /// </summary>
        [SettingsId(24)]
        OptTimeWarpVideo = 24,
        /// <summary>
        /// Video
        /// </summary>
        [SettingsId(12)]
        OptVideo = 12,

    }
    public enum ModeButtonSettingsEnum : int
    {
        /// <summary>
        /// HiLight
        /// </summary>
        [SettingsId(1)]
        OptHilight = 1,
        /// <summary>
        /// RealTime
        /// </summary>
        [SettingsId(0)]
        OptRealtime = 0,

    }
    public enum NoAudioTrackSettingsEnum : int
    {
        /// <summary>
        /// OFF
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// ON
        /// </summary>
        [SettingsId(1)]
        OptOn = 1,

    }
    public enum Output125SettingsEnum : int
    {
        /// <summary>
        /// HDR
        /// </summary>
        [SettingsId(2)]
        OptHdr = 2,
        /// <summary>
        /// Raw
        /// </summary>
        [SettingsId(1)]
        OptRaw = 1,
        /// <summary>
        /// Standard
        /// </summary>
        [SettingsId(0)]
        OptStandard = 0,
        /// <summary>
        /// SuperPhoto
        /// </summary>
        [SettingsId(3)]
        OptSuperphoto = 3,

    }
    public enum Output126SettingsEnum : int
    {
        /// <summary>
        /// Raw
        /// </summary>
        [SettingsId(1)]
        OptRaw = 1,
        /// <summary>
        /// Standard
        /// </summary>
        [SettingsId(0)]
        OptStandard = 0,

    }
    public enum PrivacySettingsEnum : int
    {
        /// <summary>
        /// Ask
        /// </summary>
        [SettingsId(0)]
        OptAsk = 0,
        /// <summary>
        /// Hidden
        /// </summary>
        [SettingsId(2)]
        OptHidden = 2,
        /// <summary>
        /// Public
        /// </summary>
        [SettingsId(1)]
        OptPublic = 1,

    }
    public enum ProtuneSettingsEnum : int
    {
        /// <summary>
        /// OFF
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// ON
        /// </summary>
        [SettingsId(1)]
        OptOn = 1,

    }
    public enum QuickCaptureSettingsEnum : int
    {
        /// <summary>
        /// OFF
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// ON
        /// </summary>
        [SettingsId(1)]
        OptOn = 1,

    }
    public enum RawAudioSettingsEnum : int
    {
        /// <summary>
        /// High
        /// </summary>
        [SettingsId(2)]
        OptHigh = 2,
        /// <summary>
        /// Low
        /// </summary>
        [SettingsId(0)]
        OptLow = 0,
        /// <summary>
        /// Medium
        /// </summary>
        [SettingsId(1)]
        OptMedium = 1,
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(3)]
        OptOff = 3,

    }
    public enum Resolution2SettingsEnum : int
    {
        /// <summary>
        /// 1080
        /// </summary>
        [SettingsId(9)]
        Opt1080 = 9,
        /// <summary>
        /// 1440
        /// </summary>
        [SettingsId(7)]
        Opt1440 = 7,
        /// <summary>
        /// 2.7K
        /// </summary>
        [SettingsId(4)]
        Opt2dot7k = 4,
        /// <summary>
        /// 2.7K 4:3
        /// </summary>
        [SettingsId(6)]
        Opt2dot7k43 = 6,
        /// <summary>
        /// 4K
        /// </summary>
        [SettingsId(1)]
        Opt4k = 1,
        /// <summary>
        /// 4K 4:3
        /// </summary>
        [SettingsId(18)]
        Opt4k43 = 18,

    }
    public enum Resolution41SettingsEnum : int
    {
        /// <summary>
        /// 1080
        /// </summary>
        [SettingsId(9)]
        Opt1080 = 9,
        /// <summary>
        /// 480
        /// </summary>
        [SettingsId(17)]
        Opt480 = 17,
        /// <summary>
        /// 720
        /// </summary>
        [SettingsId(12)]
        Opt720 = 12,

    }
    public enum ScreensaverSettingsEnum : int
    {
        /// <summary>
        /// 1 MIN
        /// </summary>
        [SettingsId(1)]
        Opt1Min = 1,
        /// <summary>
        /// 2 MIN
        /// </summary>
        [SettingsId(2)]
        Opt2Min = 2,
        /// <summary>
        /// 3 MIN
        /// </summary>
        [SettingsId(3)]
        Opt3Min = 3,
        /// <summary>
        /// NEVER
        /// </summary>
        [SettingsId(0)]
        OptNever = 0,

    }
    public enum SecondaryStreamBitRateSettingsEnum : int
    {
        /// <summary>
        /// 1 Mbps
        /// </summary>
        [SettingsId(1000000)]
        Opt1Mbps = 1000000,
        /// <summary>
        /// 1.2 Mbps
        /// </summary>
        [SettingsId(1200000)]
        Opt1dot2Mbps = 1200000,
        /// <summary>
        /// 1.6 Mbps
        /// </summary>
        [SettingsId(1600000)]
        Opt1dot6Mbps = 1600000,
        /// <summary>
        /// 2 Mbps
        /// </summary>
        [SettingsId(2000000)]
        Opt2Mbps = 2000000,
        /// <summary>
        /// 2.4 Mbps
        /// </summary>
        [SettingsId(2400000)]
        Opt2dot4Mbps = 2400000,
        /// <summary>
        /// 2.5 Mbps
        /// </summary>
        [SettingsId(2500000)]
        Opt2dot5Mbps = 2500000,
        /// <summary>
        /// 250 Kbps
        /// </summary>
        [SettingsId(250000)]
        Opt250Kbps = 250000,
        /// <summary>
        /// 4 Mbps
        /// </summary>
        [SettingsId(4000000)]
        Opt4Mbps = 4000000,
        /// <summary>
        /// 400 Kbps
        /// </summary>
        [SettingsId(400000)]
        Opt400Kbps = 400000,
        /// <summary>
        /// 600 Kbps
        /// </summary>
        [SettingsId(600000)]
        Opt600Kbps = 600000,
        /// <summary>
        /// 700 Kbps
        /// </summary>
        [SettingsId(700000)]
        Opt700Kbps = 700000,
        /// <summary>
        /// 800 Kbps
        /// </summary>
        [SettingsId(800000)]
        Opt800Kbps = 800000,

    }
    public enum SecondaryStreamGopSizeSettingsEnum : int
    {
        /// <summary>
        /// 15
        /// </summary>
        [SettingsId(15)]
        Opt15 = 15,
        /// <summary>
        /// 3
        /// </summary>
        [SettingsId(3)]
        Opt3 = 3,
        /// <summary>
        /// 30
        /// </summary>
        [SettingsId(30)]
        Opt30 = 30,
        /// <summary>
        /// 4
        /// </summary>
        [SettingsId(4)]
        Opt4 = 4,
        /// <summary>
        /// 8
        /// </summary>
        [SettingsId(8)]
        Opt8 = 8,
        /// <summary>
        /// Default
        /// </summary>
        [SettingsId(0)]
        OptDefault = 0,

    }
    public enum SecondaryStreamIdrIntervalSettingsEnum : int
    {
        /// <summary>
        /// 1
        /// </summary>
        [SettingsId(1)]
        Opt1 = 1,
        /// <summary>
        /// 2
        /// </summary>
        [SettingsId(2)]
        Opt2 = 2,
        /// <summary>
        /// 4
        /// </summary>
        [SettingsId(4)]
        Opt4 = 4,
        /// <summary>
        /// Default
        /// </summary>
        [SettingsId(0)]
        OptDefault = 0,

    }
    public enum SecondaryStreamWindowSizeSettingsEnum : int
    {
        /// <summary>
        /// 1080
        /// </summary>
        [SettingsId(12)]
        Opt1080 = 12,
        /// <summary>
        /// 240
        /// </summary>
        [SettingsId(1)]
        Opt240 = 1,
        /// <summary>
        /// 240 1:2 Subsample
        /// </summary>
        [SettingsId(3)]
        Opt24012Subsample = 3,
        /// <summary>
        /// 240 3:4 Subsample
        /// </summary>
        [SettingsId(2)]
        Opt24034Subsample = 2,
        /// <summary>
        /// 480
        /// </summary>
        [SettingsId(4)]
        Opt480 = 4,
        /// <summary>
        /// 480 1:2 Subsample
        /// </summary>
        [SettingsId(6)]
        Opt48012Subsample = 6,
        /// <summary>
        /// 480 3:4 Subsample
        /// </summary>
        [SettingsId(5)]
        Opt48034Subsample = 5,
        /// <summary>
        /// 480 Square
        /// </summary>
        [SettingsId(11)]
        Opt480Square = 11,
        /// <summary>
        /// 720
        /// </summary>
        [SettingsId(7)]
        Opt720 = 7,
        /// <summary>
        /// 720 1:2 Subsample
        /// </summary>
        [SettingsId(9)]
        Opt72012Subsample = 9,
        /// <summary>
        /// 720 3:4 Subsample
        /// </summary>
        [SettingsId(8)]
        Opt72034Subsample = 8,
        /// <summary>
        /// 720 Square
        /// </summary>
        [SettingsId(10)]
        Opt720Square = 10,
        /// <summary>
        /// Default
        /// </summary>
        [SettingsId(0)]
        OptDefault = 0,

    }
    public enum SharpnessSettingsEnum : int
    {
        /// <summary>
        /// High
        /// </summary>
        [SettingsId(0)]
        OptHigh = 0,
        /// <summary>
        /// Low
        /// </summary>
        [SettingsId(2)]
        OptLow = 2,
        /// <summary>
        /// Medium
        /// </summary>
        [SettingsId(1)]
        OptMedium = 1,

    }
    public enum Shutter19SettingsEnum : int
    {
        /// <summary>
        /// 10 Seconds
        /// </summary>
        [SettingsId(3)]
        Opt10Seconds = 3,
        /// <summary>
        /// 15 Seconds
        /// </summary>
        [SettingsId(4)]
        Opt15Seconds = 4,
        /// <summary>
        /// 2 Seconds
        /// </summary>
        [SettingsId(1)]
        Opt2Seconds = 1,
        /// <summary>
        /// 20 Seconds
        /// </summary>
        [SettingsId(5)]
        Opt20Seconds = 5,
        /// <summary>
        /// 30 Seconds
        /// </summary>
        [SettingsId(6)]
        Opt30Seconds = 6,
        /// <summary>
        /// 5 Seconds
        /// </summary>
        [SettingsId(2)]
        Opt5Seconds = 2,
        /// <summary>
        /// Auto
        /// </summary>
        [SettingsId(0)]
        OptAuto = 0,

    }
    public enum Shutter31SettingsEnum : int
    {
        /// <summary>
        /// 10 Seconds
        /// </summary>
        [SettingsId(3)]
        Opt10Seconds = 3,
        /// <summary>
        /// 15 Seconds
        /// </summary>
        [SettingsId(4)]
        Opt15Seconds = 4,
        /// <summary>
        /// 2 Seconds
        /// </summary>
        [SettingsId(1)]
        Opt2Seconds = 1,
        /// <summary>
        /// 20 Seconds
        /// </summary>
        [SettingsId(5)]
        Opt20Seconds = 5,
        /// <summary>
        /// 30 Seconds
        /// </summary>
        [SettingsId(6)]
        Opt30Seconds = 6,
        /// <summary>
        /// 5 Seconds
        /// </summary>
        [SettingsId(2)]
        Opt5Seconds = 2,
        /// <summary>
        /// Auto
        /// </summary>
        [SettingsId(0)]
        OptAuto = 0,

    }
    public enum Shutter145SettingsEnum : int
    {
        /// <summary>
        /// 1/100
        /// </summary>
        [SettingsId(12)]
        Opt1100 = 12,
        /// <summary>
        /// 1/120
        /// </summary>
        [SettingsId(13)]
        Opt1120 = 13,
        /// <summary>
        /// 1/1600
        /// </summary>
        [SettingsId(29)]
        Opt11600 = 29,
        /// <summary>
        /// 1/192
        /// </summary>
        [SettingsId(16)]
        Opt1192 = 16,
        /// <summary>
        /// 1/1920
        /// </summary>
        [SettingsId(24)]
        Opt11920 = 24,
        /// <summary>
        /// 1/200
        /// </summary>
        [SettingsId(17)]
        Opt1200 = 17,
        /// <summary>
        /// 1/24
        /// </summary>
        [SettingsId(3)]
        Opt124 = 3,
        /// <summary>
        /// 1/240
        /// </summary>
        [SettingsId(18)]
        Opt1240 = 18,
        /// <summary>
        /// 1/25
        /// </summary>
        [SettingsId(4)]
        Opt125 = 4,
        /// <summary>
        /// 1/30
        /// </summary>
        [SettingsId(5)]
        Opt130 = 5,
        /// <summary>
        /// 1/3200
        /// </summary>
        [SettingsId(30)]
        Opt13200 = 30,
        /// <summary>
        /// 1/384
        /// </summary>
        [SettingsId(25)]
        Opt1384 = 25,
        /// <summary>
        /// 1/3840
        /// </summary>
        [SettingsId(31)]
        Opt13840 = 31,
        /// <summary>
        /// 1/400
        /// </summary>
        [SettingsId(21)]
        Opt1400 = 21,
        /// <summary>
        /// 1/48
        /// </summary>
        [SettingsId(6)]
        Opt148 = 6,
        /// <summary>
        /// 1/480
        /// </summary>
        [SettingsId(22)]
        Opt1480 = 22,
        /// <summary>
        /// 1/50
        /// </summary>
        [SettingsId(7)]
        Opt150 = 7,
        /// <summary>
        /// 1/60
        /// </summary>
        [SettingsId(8)]
        Opt160 = 8,
        /// <summary>
        /// 1/800
        /// </summary>
        [SettingsId(28)]
        Opt1800 = 28,
        /// <summary>
        /// 1/96
        /// </summary>
        [SettingsId(11)]
        Opt196 = 11,
        /// <summary>
        /// 1/960
        /// </summary>
        [SettingsId(23)]
        Opt1960 = 23,
        /// <summary>
        /// Auto
        /// </summary>
        [SettingsId(0)]
        OptAuto = 0,

    }
    public enum Shutter146SettingsEnum : int
    {
        /// <summary>
        /// 1/1000
        /// </summary>
        [SettingsId(4)]
        Opt11000 = 4,
        /// <summary>
        /// 1/125
        /// </summary>
        [SettingsId(1)]
        Opt1125 = 1,
        /// <summary>
        /// 1/2000
        /// </summary>
        [SettingsId(5)]
        Opt12000 = 5,
        /// <summary>
        /// 1/250
        /// </summary>
        [SettingsId(2)]
        Opt1250 = 2,
        /// <summary>
        /// 1/500
        /// </summary>
        [SettingsId(3)]
        Opt1500 = 3,
        /// <summary>
        /// Auto
        /// </summary>
        [SettingsId(0)]
        OptAuto = 0,

    }
    public enum SpeedSettingsEnum : int
    {
        /// <summary>
        /// 10X
        /// </summary>
        [SettingsId(9)]
        Opt10x = 9,
        /// <summary>
        /// 15X
        /// </summary>
        [SettingsId(0)]
        Opt15x = 0,
        /// <summary>
        /// 2X
        /// </summary>
        [SettingsId(7)]
        Opt2x = 7,
        /// <summary>
        /// 30X
        /// </summary>
        [SettingsId(1)]
        Opt30x = 1,
        /// <summary>
        /// 5X
        /// </summary>
        [SettingsId(8)]
        Opt5x = 8,
        /// <summary>
        /// Auto
        /// </summary>
        [SettingsId(10)]
        OptAuto = 10,

    }
    public enum TimerSettingsEnum : int
    {
        /// <summary>
        /// 10 Seconds
        /// </summary>
        [SettingsId(2)]
        Opt10Seconds = 2,
        /// <summary>
        /// 3 Seconds
        /// </summary>
        [SettingsId(1)]
        Opt3Seconds = 1,
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,

    }
    public enum UpperLeftSettingsEnum : int
    {
        /// <summary>
        /// Bit Rate
        /// </summary>
        [SettingsId(7)]
        OptBitRate = 7,
        /// <summary>
        /// Burst Rate
        /// </summary>
        [SettingsId(8)]
        OptBurstRate = 8,
        /// <summary>
        /// Clips
        /// </summary>
        [SettingsId(9)]
        OptClips = 9,
        /// <summary>
        /// Color
        /// </summary>
        [SettingsId(10)]
        OptColor = 10,
        /// <summary>
        /// EV Comp
        /// </summary>
        [SettingsId(11)]
        OptEvComp = 11,
        /// <summary>
        /// HyperSmooth
        /// </summary>
        [SettingsId(12)]
        OptHypersmooth = 12,
        /// <summary>
        /// Interval
        /// </summary>
        [SettingsId(13)]
        OptInterval = 13,
        /// <summary>
        /// ISO Max
        /// </summary>
        [SettingsId(15)]
        OptIsoMax = 15,
        /// <summary>
        /// ISO Min
        /// </summary>
        [SettingsId(14)]
        OptIsoMin = 14,
        /// <summary>
        /// Lens
        /// </summary>
        [SettingsId(2)]
        OptLens = 2,
        /// <summary>
        /// Low Light
        /// </summary>
        [SettingsId(4)]
        OptLowLight = 4,
        /// <summary>
        /// Mics
        /// </summary>
        [SettingsId(16)]
        OptMics = 16,
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// Output
        /// </summary>
        [SettingsId(17)]
        OptOutput = 17,
        /// <summary>
        /// Raw Audio
        /// </summary>
        [SettingsId(18)]
        OptRawAudio = 18,
        /// <summary>
        /// Sharpness
        /// </summary>
        [SettingsId(19)]
        OptSharpness = 19,
        /// <summary>
        /// Shutter
        /// </summary>
        [SettingsId(6)]
        OptShutter = 6,
        /// <summary>
        /// SloMo
        /// </summary>
        [SettingsId(3)]
        OptSlomo = 3,
        /// <summary>
        /// Speed
        /// </summary>
        [SettingsId(21)]
        OptSpeed = 21,
        /// <summary>
        /// Timer
        /// </summary>
        [SettingsId(20)]
        OptTimer = 20,
        /// <summary>
        /// White Balance
        /// </summary>
        [SettingsId(5)]
        OptWhiteBalance = 5,
        /// <summary>
        /// Wind
        /// </summary>
        [SettingsId(100)]
        OptWind = 23,
        /// <summary>
        /// Zoom
        /// </summary>
        [SettingsId(1)]
        OptZoom = 1,

    }
    public enum UpperRightSettingsEnum : int
    {
        /// <summary>
        /// Bit Rate
        /// </summary>
        [SettingsId(7)]
        OptBitRate = 7,
        /// <summary>
        /// Burst Rate
        /// </summary>
        [SettingsId(8)]
        OptBurstRate = 8,
        /// <summary>
        /// Clips
        /// </summary>
        [SettingsId(9)]
        OptClips = 9,
        /// <summary>
        /// Color
        /// </summary>
        [SettingsId(10)]
        OptColor = 10,
        /// <summary>
        /// EV Comp
        /// </summary>
        [SettingsId(11)]
        OptEvComp = 11,
        /// <summary>
        /// HyperSmooth
        /// </summary>
        [SettingsId(12)]
        OptHypersmooth = 12,
        /// <summary>
        /// Interval
        /// </summary>
        [SettingsId(13)]
        OptInterval = 13,
        /// <summary>
        /// ISO Max
        /// </summary>
        [SettingsId(15)]
        OptIsoMax = 15,
        /// <summary>
        /// ISO Min
        /// </summary>
        [SettingsId(14)]
        OptIsoMin = 14,
        /// <summary>
        /// Lens
        /// </summary>
        [SettingsId(2)]
        OptLens = 2,
        /// <summary>
        /// Low Light
        /// </summary>
        [SettingsId(4)]
        OptLowLight = 4,
        /// <summary>
        /// Mics
        /// </summary>
        [SettingsId(16)]
        OptMics = 16,
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// Output
        /// </summary>
        [SettingsId(17)]
        OptOutput = 17,
        /// <summary>
        /// Raw Audio
        /// </summary>
        [SettingsId(18)]
        OptRawAudio = 18,
        /// <summary>
        /// Sharpness
        /// </summary>
        [SettingsId(19)]
        OptSharpness = 19,
        /// <summary>
        /// Shutter
        /// </summary>
        [SettingsId(6)]
        OptShutter = 6,
        /// <summary>
        /// SloMo
        /// </summary>
        [SettingsId(3)]
        OptSlomo = 3,
        /// <summary>
        /// Speed
        /// </summary>
        [SettingsId(21)]
        OptSpeed = 21,
        /// <summary>
        /// Timer
        /// </summary>
        [SettingsId(20)]
        OptTimer = 20,
        /// <summary>
        /// White Balance
        /// </summary>
        [SettingsId(5)]
        OptWhiteBalance = 5,
        /// <summary>
        /// Wind
        /// </summary>
        [SettingsId(100)]
        OptWind = 23,
        /// <summary>
        /// Zoom
        /// </summary>
        [SettingsId(1)]
        OptZoom = 1,

    }
    public enum VideoCompressionSettingsEnum : int
    {
        /// <summary>
        /// H.264 + HEVC
        /// </summary>
        [SettingsId(2)]
        OptHdot264PlusHevc = 0,
        /// <summary>
        /// HEVC
        /// </summary>
        [SettingsId(1)]
        OptHevc = 1,

    }
    public enum VoiceControlEnableSettingsEnum : int
    {
        /// <summary>
        /// OFF
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// ON
        /// </summary>
        [SettingsId(1)]
        OptOn = 1,

    }
    public enum VoiceControlLanguageSettingsEnum : int
    {
        /// <summary>
        /// Chinese
        /// </summary>
        [SettingsId(8)]
        OptChinese = 8,
        /// <summary>
        /// English - AUS
        /// </summary>
        [SettingsId(2)]
        OptEnglishMinusAus = 2,
        /// <summary>
        /// English - IND
        /// </summary>
        [SettingsId(13)]
        OptEnglishMinusInd = 13,
        /// <summary>
        /// English - UK
        /// </summary>
        [SettingsId(1)]
        OptEnglishMinusUk = 1,
        /// <summary>
        /// English - US
        /// </summary>
        [SettingsId(0)]
        OptEnglishMinusUs = 0,
        /// <summary>
        /// French
        /// </summary>
        [SettingsId(4)]
        OptFrench = 4,
        /// <summary>
        /// German
        /// </summary>
        [SettingsId(3)]
        OptGerman = 3,
        /// <summary>
        /// Italian
        /// </summary>
        [SettingsId(5)]
        OptItalian = 5,
        /// <summary>
        /// Japanese
        /// </summary>
        [SettingsId(9)]
        OptJapanese = 9,
        /// <summary>
        /// Korean
        /// </summary>
        [SettingsId(10)]
        OptKorean = 10,
        /// <summary>
        /// Portuguese
        /// </summary>
        [SettingsId(11)]
        OptPortuguese = 11,
        /// <summary>
        /// Russian
        /// </summary>
        [SettingsId(12)]
        OptRussian = 12,
        /// <summary>
        /// Spanish
        /// </summary>
        [SettingsId(6)]
        OptSpanish = 6,
        /// <summary>
        /// Spanish - NA
        /// </summary>
        [SettingsId(7)]
        OptSpanishMinusNa = 7,
        /// <summary>
        /// Swedish
        /// </summary>
        [SettingsId(14)]
        OptSwedish = 14,

    }
    public enum WakeOnVoiceSettingsEnum : int
    {
        /// <summary>
        /// OFF
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// ON
        /// </summary>
        [SettingsId(1)]
        OptOn = 1,

    }
    public enum WhiteBalanceSettingsEnum : int
    {
        /// <summary>
        /// 2300K
        /// </summary>
        [SettingsId(8)]
        Opt2300k = 8,
        /// <summary>
        /// 2800K
        /// </summary>
        [SettingsId(9)]
        Opt2800k = 9,
        /// <summary>
        /// 3200K
        /// </summary>
        [SettingsId(10)]
        Opt3200k = 10,
        /// <summary>
        /// 4000K
        /// </summary>
        [SettingsId(5)]
        Opt4000k = 5,
        /// <summary>
        /// 4500K
        /// </summary>
        [SettingsId(11)]
        Opt4500k = 11,
        /// <summary>
        /// 5000K
        /// </summary>
        [SettingsId(12)]
        Opt5000k = 12,
        /// <summary>
        /// 5500K
        /// </summary>
        [SettingsId(2)]
        Opt5500k = 2,
        /// <summary>
        /// 6000K
        /// </summary>
        [SettingsId(7)]
        Opt6000k = 7,
        /// <summary>
        /// 6500K
        /// </summary>
        [SettingsId(3)]
        Opt6500k = 3,
        /// <summary>
        /// Auto
        /// </summary>
        [SettingsId(0)]
        OptAuto = 0,
        /// <summary>
        /// Native
        /// </summary>
        [SettingsId(4)]
        OptNative = 4,

    }
    public enum WindSettingsEnum : int
    {
        /// <summary>
        /// Auto
        /// </summary>
        [SettingsId(2)]
        OptAuto = 2,
        /// <summary>
        /// Off
        /// </summary>
        [SettingsId(0)]
        OptOff = 0,
        /// <summary>
        /// On
        /// </summary>
        [SettingsId(4)]
        OptOn = 1,

    }
    public enum WindowSizeSettingsEnum : int
    {
        /// <summary>
        /// 240
        /// </summary>
        [SettingsId(1)]
        Opt240 = 1,
        /// <summary>
        /// 240 1:2 Subsample
        /// </summary>
        [SettingsId(3)]
        Opt24012Subsample = 3,
        /// <summary>
        /// 240 3:4 Subsample
        /// </summary>
        [SettingsId(2)]
        Opt24034Subsample = 2,
        /// <summary>
        /// 480
        /// </summary>
        [SettingsId(4)]
        Opt480 = 4,
        /// <summary>
        /// 480 1:2 Subsample
        /// </summary>
        [SettingsId(6)]
        Opt48012Subsample = 6,
        /// <summary>
        /// 480 3:4 Subsample
        /// </summary>
        [SettingsId(5)]
        Opt48034Subsample = 5,
        /// <summary>
        /// 720
        /// </summary>
        [SettingsId(7)]
        Opt720 = 7,
        /// <summary>
        /// 720 1:2 Subsample
        /// </summary>
        [SettingsId(9)]
        Opt72012Subsample = 9,
        /// <summary>
        /// 720 3:4 Subsample
        /// </summary>
        [SettingsId(8)]
        Opt72034Subsample = 8,
        /// <summary>
        /// Default
        /// </summary>
        [SettingsId(0)]
        OptDefault = 0,

    }

    public class Settings
    {
        private readonly JObject _settings;

        public Settings(JObject settings)
        {
            _settings = settings;
        }
        public AntiminusflickerSettingsEnum Antiminusflicker => (AntiminusflickerSettingsEnum)_settings["134"].ToObject<int>();
        public AudioInputSettingsEnum AudioInput => (AudioInputSettingsEnum)_settings["95"].ToObject<int>();
        public AudioProtuneSettingsEnum AudioProtune => (AudioProtuneSettingsEnum)_settings["79"].ToObject<int>();
        public AutoLockSettingsEnum AutoLock => (AutoLockSettingsEnum)_settings["103"].ToObject<int>();
        public AutoOffSettingsEnum AutoOff => (AutoOffSettingsEnum)_settings["59"].ToObject<int>();
        public BeepsSettingsEnum Beeps => (BeepsSettingsEnum)_settings["87"].ToObject<int>();
        public BitRate67SettingsEnum BitRate67 => (BitRate67SettingsEnum)_settings["67"].ToObject<int>();
        public BitRate124SettingsEnum BitRate124 => (BitRate124SettingsEnum)_settings["124"].ToObject<int>();
        public BnrFramePerSecondSettingsEnum BnrFramePerSecond => (BnrFramePerSecondSettingsEnum)_settings["45"].ToObject<int>();
        public BnrResolutionSettingsEnum BnrResolution => (BnrResolutionSettingsEnum)_settings["44"].ToObject<int>();
        public BurstRateSettingsEnum BurstRate => (BurstRateSettingsEnum)_settings["147"].ToObject<int>();
        public ClipsSettingsEnum Clips => (ClipsSettingsEnum)_settings["107"].ToObject<int>();
        public ColorSettingsEnum Color => (ColorSettingsEnum)_settings["116"].ToObject<int>();
        public DefaultPresetSettingsEnum DefaultPreset => (DefaultPresetSettingsEnum)_settings["127"].ToObject<int>();
        public EvCompSettingsEnum EvComp => (EvCompSettingsEnum)_settings["118"].ToObject<int>();
        public FormatSettingsEnum Format => (FormatSettingsEnum)_settings["128"].ToObject<int>();
        public FramePerSecondSettingsEnum FramePerSecond => (FramePerSecondSettingsEnum)_settings["42"].ToObject<int>();
        public FramesPerSecondSettingsEnum FramesPerSecond => (FramesPerSecondSettingsEnum)_settings["3"].ToObject<int>();
        public GopSizeSettingsEnum GopSize => (GopSizeSettingsEnum)_settings["65"].ToObject<int>();
        public GpsSettingsEnum Gps => (GpsSettingsEnum)_settings["83"].ToObject<int>();
        public HypersmoothSettingsEnum Hypersmooth => (HypersmoothSettingsEnum)_settings["135"].ToObject<int>();
        public IdrIntervalSettingsEnum IdrInterval => (IdrIntervalSettingsEnum)_settings["66"].ToObject<int>();
        public Interval5SettingsEnum Interval5 => (Interval5SettingsEnum)_settings["5"].ToObject<int>();
        public Interval6SettingsEnum Interval6 => (Interval6SettingsEnum)_settings["6"].ToObject<int>();
        public Interval30SettingsEnum Interval30 => (Interval30SettingsEnum)_settings["30"].ToObject<int>();
        public Interval32SettingsEnum Interval32 => (Interval32SettingsEnum)_settings["32"].ToObject<int>();
        public IsoMax13SettingsEnum IsoMax13 => (IsoMax13SettingsEnum)_settings["13"].ToObject<int>();
        public IsoMax24SettingsEnum IsoMax24 => (IsoMax24SettingsEnum)_settings["24"].ToObject<int>();
        public IsoMax37SettingsEnum IsoMax37 => (IsoMax37SettingsEnum)_settings["37"].ToObject<int>();
        public IsoMin75SettingsEnum IsoMin75 => (IsoMin75SettingsEnum)_settings["75"].ToObject<int>();
        public IsoMin76SettingsEnum IsoMin76 => (IsoMin76SettingsEnum)_settings["76"].ToObject<int>();
        public IsoMin102SettingsEnum IsoMin102 => (IsoMin102SettingsEnum)_settings["102"].ToObject<int>();
        public LandscapeLockSettingsEnum LandscapeLock => (LandscapeLockSettingsEnum)_settings["112"].ToObject<int>();
        public LanguageSettingsEnum Language => (LanguageSettingsEnum)_settings["84"].ToObject<int>();
        public LcdBrightnessSettingsEnum LcdBrightness => (LcdBrightnessSettingsEnum)_settings["88"].ToObject<int>();
        public LedSettingsEnum Led => (LedSettingsEnum)_settings["91"].ToObject<int>();
        public Lens121SettingsEnum Lens121 => (Lens121SettingsEnum)_settings["121"].ToObject<int>();
        public Lens122SettingsEnum Lens122 => (Lens122SettingsEnum)_settings["122"].ToObject<int>();
        public Lens123SettingsEnum Lens123 => (Lens123SettingsEnum)_settings["123"].ToObject<int>();
        public LowLightSettingsEnum LowLight => (LowLightSettingsEnum)_settings["8"].ToObject<int>();
        public LowerLeftSettingsEnum LowerLeft => (LowerLeftSettingsEnum)_settings["129"].ToObject<int>();
        public LowerRightSettingsEnum LowerRight => (LowerRightSettingsEnum)_settings["130"].ToObject<int>();
        public MegapixelsSettingsEnum Megapixels => (MegapixelsSettingsEnum)_settings["133"].ToObject<int>();
        public MicsSettingsEnum Mics => (MicsSettingsEnum)_settings["137"].ToObject<int>();
        public ModeSettingsEnum Mode => (ModeSettingsEnum)_settings["144"].ToObject<int>();
        public ModeButtonSettingsEnum ModeButton => (ModeButtonSettingsEnum)_settings["153"].ToObject<int>();
        public NoAudioTrackSettingsEnum NoAudioTrack => (NoAudioTrackSettingsEnum)_settings["96"].ToObject<int>();
        public Output125SettingsEnum Output125 => (Output125SettingsEnum)_settings["125"].ToObject<int>();
        public Output126SettingsEnum Output126 => (Output126SettingsEnum)_settings["126"].ToObject<int>();
        public PrivacySettingsEnum Privacy => (PrivacySettingsEnum)_settings["48"].ToObject<int>();
        public ProtuneSettingsEnum Protune => (ProtuneSettingsEnum)_settings["114"].ToObject<int>();
        public QuickCaptureSettingsEnum QuickCapture => (QuickCaptureSettingsEnum)_settings["54"].ToObject<int>();
        public RawAudioSettingsEnum RawAudio => (RawAudioSettingsEnum)_settings["139"].ToObject<int>();
        public Resolution2SettingsEnum Resolution2 => (Resolution2SettingsEnum)_settings["2"].ToObject<int>();
        public Resolution41SettingsEnum Resolution41 => (Resolution41SettingsEnum)_settings["41"].ToObject<int>();
        public ScreensaverSettingsEnum Screensaver => (ScreensaverSettingsEnum)_settings["51"].ToObject<int>();
        public SecondaryStreamBitRateSettingsEnum SecondaryStreamBitRate => (SecondaryStreamBitRateSettingsEnum)_settings["62"].ToObject<int>();
        public SecondaryStreamGopSizeSettingsEnum SecondaryStreamGopSize => (SecondaryStreamGopSizeSettingsEnum)_settings["60"].ToObject<int>();
        public SecondaryStreamIdrIntervalSettingsEnum SecondaryStreamIdrInterval => (SecondaryStreamIdrIntervalSettingsEnum)_settings["61"].ToObject<int>();
        public SecondaryStreamWindowSizeSettingsEnum SecondaryStreamWindowSize => (SecondaryStreamWindowSizeSettingsEnum)_settings["64"].ToObject<int>();
        public SharpnessSettingsEnum Sharpness => (SharpnessSettingsEnum)_settings["117"].ToObject<int>();
        public Shutter19SettingsEnum Shutter19 => (Shutter19SettingsEnum)_settings["19"].ToObject<int>();
        public Shutter31SettingsEnum Shutter31 => (Shutter31SettingsEnum)_settings["31"].ToObject<int>();
        public Shutter145SettingsEnum Shutter145 => (Shutter145SettingsEnum)_settings["145"].ToObject<int>();
        public Shutter146SettingsEnum Shutter146 => (Shutter146SettingsEnum)_settings["146"].ToObject<int>();
        public SpeedSettingsEnum Speed => (SpeedSettingsEnum)_settings["111"].ToObject<int>();
        public TimerSettingsEnum Timer => (TimerSettingsEnum)_settings["105"].ToObject<int>();
        public UpperLeftSettingsEnum UpperLeft => (UpperLeftSettingsEnum)_settings["131"].ToObject<int>();
        public UpperRightSettingsEnum UpperRight => (UpperRightSettingsEnum)_settings["132"].ToObject<int>();
        public VideoCompressionSettingsEnum VideoCompression => (VideoCompressionSettingsEnum)_settings["106"].ToObject<int>();
        public VoiceControlEnableSettingsEnum VoiceControlEnable => (VoiceControlEnableSettingsEnum)_settings["86"].ToObject<int>();
        public VoiceControlLanguageSettingsEnum VoiceControlLanguage => (VoiceControlLanguageSettingsEnum)_settings["85"].ToObject<int>();
        public WakeOnVoiceSettingsEnum WakeOnVoice => (WakeOnVoiceSettingsEnum)_settings["104"].ToObject<int>();
        public WhiteBalanceSettingsEnum WhiteBalance => (WhiteBalanceSettingsEnum)_settings["115"].ToObject<int>();
        public WindSettingsEnum Wind => (WindSettingsEnum)_settings["149"].ToObject<int>();
        public WindowSizeSettingsEnum WindowSize => (WindowSizeSettingsEnum)_settings["47"].ToObject<int>();

    }

    #endregion


}
