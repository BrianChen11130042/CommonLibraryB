using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop.Implementation;

namespace CommonLibraryB.Manager.WebApiClient
{

    public class WebApiClientPack
    {
        public HttpClient httpClient { get; set; }

        public string path { get; set; }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest request)
        {
            using (var response = await httpClient.PostAsJsonAsync(path, request))
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                if(!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException($"HTTP {(int)response.StatusCode}: {jsonString}");
                }

                var data = JsonSerializer.Deserialize<TResponse>(jsonString);

                if(data == null)
                {
                    throw new InvalidOperationException("response deserialize failed");
                }

                return data;
            }
        }
    }
}
