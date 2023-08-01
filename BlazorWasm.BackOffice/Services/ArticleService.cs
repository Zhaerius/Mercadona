using BlazorWasm.BackOffice.Services.Abstractions;
using BlazorWasm.BackOffice.Models;
using System.Text.Json;

namespace BlazorWasm.BackOffice.Services
{
    public class ArticleService : IArticleService
    {
        //private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public ArticleService(/*IHttpClientFactory clientFactory, */HttpClient httpClient)
        {
            //_clientFactory = clientFactory;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name)
        {
            //var client = _clientFactory.CreateClient("MercaApi");
            var response = await _httpClient.GetAsync($"article/search?name={name}");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return Enumerable.Empty<SearchArticlesResponse>();

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<SearchArticlesResponse>>(jsonData, jsonOptions)!;
        }

        public async Task<ArticleResponse> GetDetailsArticle(Guid id)
        {
            //var client = _clientFactory.CreateClient("MercaApi");
            var response = await _httpClient.GetAsync($"article/{id}");

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
