using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;
using System.Text.Json;

namespace BlazorServer.BackOffice.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ArticleService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name)
        {
            var client = _clientFactory.CreateClient("MercaApi");
            var response = await client.GetAsync($"article/search?name={name}");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return Enumerable.Empty<SearchArticlesResponse>();

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<SearchArticlesResponse>>(jsonData, jsonOptions)!;
        }

        public async Task<ArticleResponse> GetDetailsArticle(Guid id)
        {
            var client = _clientFactory.CreateClient("MercaApi");
            var response = await client.GetAsync($"article/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return null!;
            }

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ArticleResponse>(jsonData, jsonOptions)!;
        }
    }
}
