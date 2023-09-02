using BlazorServer.BackOffice.Services.Abstractions;
using System.Text.Json;
using BlazorServer.BackOffice.Models.Article;

namespace BlazorServer.BackOffice.Services
{
    public class ArticleService : IArticleService
    {
        private readonly HttpClient _httpClient;

        public ArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateArticle(CreateArticleModel createArticle)
        {
            var jsonContent = JsonContent.Create(createArticle);
            var response = await _httpClient.PostAsync($"article", jsonContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name)
        {
            var response = await _httpClient.GetAsync($"article/search?name={name}");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return Enumerable.Empty<SearchArticlesResponse>();

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<SearchArticlesResponse>>(jsonData, jsonOptions)!;
        }

        public async Task<bool> DeleteArticle(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"article/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<ArticleModel> GetDetailsArticle(Guid id)
        {
            var response = await _httpClient.GetAsync($"article/{id}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("dsds");
                return null!;
            }

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ArticleModel>(jsonData, jsonOptions)!;
        }

        public async Task<HttpResponseMessage> UploadImage(MultipartFormDataContent content)
        {
            return await _httpClient.PostAsync($"article/img", content);
        }


    }
}
