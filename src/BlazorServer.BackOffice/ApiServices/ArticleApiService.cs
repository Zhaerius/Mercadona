using BlazorServer.BackOffice.ApiServices.Abstractions;
using BlazorServer.BackOffice.Models;
using System.Text.Json;

namespace BlazorServer.BackOffice.ApiServices
{
    public class ArticleApiService : IArticleApiService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ArticleApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<SearchArticlesResponse>?> SearchArticles(string? name)
        {
            var client = _clientFactory.CreateClient("MercaApi");
            var response = await client.GetAsync($"article/search?name={name}");

            if (!response.IsSuccessStatusCode)
                return Enumerable.Empty<SearchArticlesResponse>();
                // OU return null
                // OU return throw new Exception();
                // OU return new Result<SearchArticlesResponse>()

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<SearchArticlesResponse>>(jsonData, jsonOptions)!;
        }
    }
}
