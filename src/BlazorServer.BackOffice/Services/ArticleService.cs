using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using System.Text.Json;

namespace BlazorServer.BackOffice.Services
{
    public class ArticleService : IArticleService
    {
        private readonly HttpClient _httpClient;

        public ArticleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid?> CreateArticle(CreateArticleRequest createArticle)
        {
            var response = await _httpClient.PostAsJsonAsync("article", createArticle);

            if (!response.IsSuccessStatusCode)
                return null;

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Guid>(jsonData, jsonOptions)!;

        }

        public async Task<ArticleModel> GetArticleById(Guid id)
        {
            var article = await _httpClient.GetFromJsonAsync<ArticleModel>($"article/{id}");
            return article;
        }

        public async Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name)
        {
            var articles = await _httpClient.GetFromJsonAsync<IEnumerable<SearchArticlesResponse>>($"article/search?name={name}");
            return articles;
        }

        public async Task<bool> UpdateArticle(UpdateArticleRequest updateArticleRequest)
        {
            var response = await _httpClient.PutAsJsonAsync($"article/", updateArticleRequest);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteArticle(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"article/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<HttpResponseMessage> UploadImage(MultipartFormDataContent content)
        {
            return await _httpClient.PostAsync($"article/img", content);
        }
    }
}
