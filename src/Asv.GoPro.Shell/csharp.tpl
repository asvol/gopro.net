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
	public class GoProStatus
    {
        private readonly JObject _json;
        private Status _status;

        public GoProStatus(string json):this(JsonConvert.DeserializeObject<JObject>(json))
        {
            
        }

        private GoProStatus(JObject json)
        {
            _json = json;
        }

        public Status Status => _status ?? (_status = new Status(_json["status"].ToObject<JObject>()));
    }

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
}
