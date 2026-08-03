using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CommonLibraryB.Manager.WebApiClient
{
    public enum EHttp
    {
        http,
        https
    }

    public class WebApiClientConfig
    {
        [Required]
        public EHttp Http { get; set; } = EHttp.http;

        [Required]
        [RegularExpression(@"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)")]
        public string Ip { get; set; } = "127.0.0.1";

        [Required]
        [Range(0, 65535)]
        public int Port { get; set; } = 1443;

        public string device { get; set; }

        public bool Enable { get; set; } = false;

        [JsonIgnore]
        public HttpClient httpClient { get; set; }

        [JsonIgnore]
        public string baseUrl => $"{Http}://{Ip}:{Port}/";

        public void Init()
        {
            httpClient = new HttpClient();
        }

        public bool Connect(out string msg)
        {
            msg = string.Empty;

            if (!Enable)
                return true;
            try
            {

                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.Timeout = TimeSpan.FromSeconds(30);

                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }

        public bool Disconnect()
        {
            if (!Enable)
                return true;

            try
            {
                httpClient?.Dispose();
                httpClient = null;

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
