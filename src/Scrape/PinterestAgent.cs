using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Scrape.Model;

namespace Scrape
{
    public class PinterestAgent : IPinterestAgent
    {
        private readonly HttpClient _httpClient;

        public PinterestAgent(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<string> GetData(string[] keywords)
        {
            string data = string.Join(',', keywords);
            string query = Uri.EscapeUriString(data);

            string url = $"https://tr.pinterest.com/resource/BaseSearchResource/get/?source_url=/search/pins/?q={query}&data={{\"options\":{{\"isPrefetch\":false,\"query\":\"{data}\",\"scope\":\"pins\",\"no_fetch_context_on_resource\":false}},\"context\":{{}}}}";
            ResponseModel response = await _httpClient.GetFromJsonAsync<ResponseModel>(new Uri(url, UriKind.Absolute));

            return response.ToString();
        }
    }
}
