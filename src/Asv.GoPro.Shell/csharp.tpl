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

// This code was generate by tool {{Tool}} version {{ToolVersion}}
// 
// GoPro info 
// Protocol version : {{ProtocolVersion}}
// Protocol schema version : {{ProtocolSchemaVersion}}

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

        public GoProStatus(string json):this(JsonConvert.DeserializeObject<JObject>(json))
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

	

{%- for group in Status -%}
	public class Status{{group.CamelName}}
	{
		private readonly JObject _status;
		public Status{{group.CamelName}}(JObject status)
		{
			_status = status;
		}
    {%- for field in group.Fields -%}
        {%- case field.Type -%}
        {%- when 'Unknown' -%}
        public JToken {{field.CamelName}} => _status["{{field.Id}}"];
        {%- when 'Integer' -%}
        public int {{field.CamelName}} => _status["{{field.Id}}"].ToObject<int>();
        {%- when 'String' -%}
        public string {{field.CamelName}} => _status["{{field.Id}}"].ToObject<string>();
        {%-endcase -%}
    {%- endfor -%}
    }
{%- endfor -%}

    public class Status
    {
        private readonly JObject _status;

        public Status(JObject status)
        {
            _status = status;
        }

{%- for group in Status -%}
		private static Status{{group.CamelName}} _status{{group.CamelName}};
        public Status{{group.CamelName}} {{group.CamelName}}  => _status{{group.CamelName}} ?? (_status{{group.CamelName}} = new Status{{group.CamelName}}(_status));
{%- endfor -%}

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

{%- for set in Settings -%}
    public enum {{set.Name}}SettingsEnum:int
    {
    {%- for opt in set.Options -%}
        /// <summary>
        /// {{opt.DisplayName}}
        /// </summary>
        [SettingsId({{opt.Id}})]
        Opt{{opt.Name}} = {{opt.Value}},
    {%- endfor -%}            
    }
{%- endfor -%}

	public class Settings
	{
		private readonly JObject _settings;

        public Settings(JObject settings)
        {
            _settings = settings;
        }
{%- for set in Settings -%}
		public {{set.Name}}SettingsEnum {{set.Name}} => ({{set.Name}}SettingsEnum)_settings["{{set.Id}}"].ToObject<int>();
{%- endfor -%}

	}

	#endregion


}
