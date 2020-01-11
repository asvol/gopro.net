using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Asv.GoPro
{
    public class GoProCameraBase:IGoProCamera
    {
        private readonly Uri _baseUri;

        public GoProCameraBase(string host,int port)
        {
            _baseUri = new Uri($"http://{host}:{port}");
        }

        public async Task<string> GetStatus()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync($"{_baseUri}/gp/gpControl/status");
                return result;
            }
        }


        public void Dispose()
        {
            
        }
    }
}
