using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NTNU.WebAppTemplate.Tests
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ContentAs<T>(this HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(data) ?
                            default :
                            JsonConvert.DeserializeObject<T>(data);
        }
    }
}