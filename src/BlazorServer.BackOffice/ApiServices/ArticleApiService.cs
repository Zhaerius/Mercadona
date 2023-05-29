using BlazorServer.BackOffice.ApiServices.Abstractions;
using BlazorServer.BackOffice.Models;
using Bogus.DataSets;
using System.Text.Json;
using System.Xml.Linq;

namespace BlazorServer.BackOffice.ApiServices
{
    public class ArticleApiService : IArticleApiService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ArticleApiService(IHttpClientFactory clientFactory)
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
