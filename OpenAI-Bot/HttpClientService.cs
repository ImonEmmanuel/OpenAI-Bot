using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAI_Bot
{
    public  class HttpClientService 
    {
        private readonly HttpClient _httpClient;
        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(HttpMethod method, string url, IDictionary<string, string> headers = null, object content = null)
        {
            var request = new HttpRequestMessage(method, url);

            // Add headers to the request
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            if (content != null)
            {
                request.Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);

            // Ensure we have a Success Status Code
            response.EnsureSuccessStatusCode();

            // Deserialize the returned data
            var data = await response.Content.ReadFromJsonAsync<T>();

            return data;
        }
    }
}
