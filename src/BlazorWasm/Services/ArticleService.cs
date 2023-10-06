using BlazorWasm.Models.Article;
using BlazorWasm.Services.Abstractions;
using System.Net.Http.Json;

namespace BlazorWasm.Services
{
    public class ArticleService : HttpService
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

            return await DeserializeFromHttpResponse<Guid>(response);

        }

        public async Task<ArticleModel> GetArticleById(Guid id)
        {
            var response = await _httpClient.GetAsync($"article/{id}");

            if (!response.IsSuccessStatusCode)
                return null!;

            return await DeserializeFromHttpResponse<ArticleModel>(response);
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

        public async Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name)
        {
            var response = await _httpClient.GetAsync($"article/search/{name}");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return Enumerable.Empty<SearchArticlesResponse>();

            return await DeserializeFromHttpResponse<IEnumerable<SearchArticlesResponse>>(response);
        }

        public async Task<HttpResponseMessage> UploadImage(MultipartFormDataContent content)
        {
            return await _httpClient.PostAsync($"article/img", content);
        }
    }
}
