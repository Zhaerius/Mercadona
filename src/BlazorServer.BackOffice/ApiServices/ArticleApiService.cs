using BlazorServer.BackOffice.Models;
using System.Text.Json;

namespace BlazorServer.BackOffice.ApiServices
{
    public class ArticleApiService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ArticleApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<SearchArticlesModel>> SearchArticles(string name)
        {
            var client = _clientFactory.CreateClient("MercaApi");
            var response = await client.GetAsync($"article/search?name={name}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var jsonOptions = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<SearchArticlesModel>>(jsonData, jsonOptions);
        }
    }
}
