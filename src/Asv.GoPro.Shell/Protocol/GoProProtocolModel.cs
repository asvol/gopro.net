using System;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Asv.GoPro.Shell.Protocol
{
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

    public class GoProProtocolModel
    {
        public int Version { get; set; }
        public int SchemaVersion { get; set; }
        public GoProProtocolStatusGroup[] Status { get; set; }
        public GoProSettingItem[] Settings { get; set; }
        public CameraInfo Info { get; set; }
    }

    public class GoProSettingItem
    {
        public GoProSettingOptionItem[] Options { get; set; }
        public string DisplayName { get; set; }
        public int Id { get; set; }
        public string Group { get; set; }
        public string UniqueDisplayName { get; set; }
        public bool NotUnique { get; set; }
    }

    public class GoProSettingOptionItem
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public int Value { get; set; }
        public string Group { get; set; }
        public bool NotUnique { get; set; }
        public string UniqueDisplayName { get; set; }
    }

    public class GoProProtocolStatusGroup
    {
        public string Name { get; set; }
        public GoProProtocolStatusField[] Fields { get; set; }
    }

    public enum StatusFieldType
    {
        Unknown,
        Integer,
        String,
    }

    public class GoProProtocolStatusField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusFieldType Type { get; set; }
    }

    public class SettingsIdAttribute : Attribute
    {
        public int ID { get; }

        public SettingsIdAttribute(int id)
        {
            ID = id;
        }
    }

    public enum SettingsEnum:int
    {
        /// <summary>
        /// 
        /// </summary>
        [SettingsId(1)]
        AAA = 1,
    }


    
}