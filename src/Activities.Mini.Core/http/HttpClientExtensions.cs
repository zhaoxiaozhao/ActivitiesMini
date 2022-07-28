using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Activities.Mini.Core.http
{
    public static class HttpClientExtensions
    {
        public static async Task<T?> PostAsJsonAsync<T>(this HttpClient client, string requestUri, object param)
        {
            var response = await client.PostAsJsonAsync(requestUri, param);
            var jsonResut = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResut);
            return result;
        }

        public static async Task<T?> GetAsync<T>(this HttpClient client, string requestUri)
        {
            var response = await client.GetAsync(requestUri);
            var jsonResut = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResut);
            return result;
        }
    }
}
