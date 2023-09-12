using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using System.Text.Json;
using BlazorServer.BackOffice.Models.Promotion;

namespace BlazorServer.BackOffice.Services
{
    public class PromotionService : HttpService
    {
        private readonly HttpClient _httpClient;

        public PromotionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreatePromotion(CreatePromotionRequest createPromotion)
        {
            var response = await _httpClient.PostAsJsonAsync("promotion", createPromotion);
            return response.IsSuccessStatusCode;

        }

        //public async Task<ArticleModel> GetArticleById(Guid id)
        //{
        //    var article = await _httpClient.GetFromJsonAsync<ArticleModel>($"article/{id}");
        //    return article;
        //}

        //public async Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name)
        //{
        //    var articles = await _httpClient.GetFromJsonAsync<IEnumerable<SearchArticlesResponse>>($"article/search?name={name}");
        //    return articles;
        //}

        //public async Task<bool> UpdateArticle(UpdateArticleRequest updateArticleRequest)
        //{
        //    var response = await _httpClient.PutAsJsonAsync($"article/", updateArticleRequest);
        //    return response.IsSuccessStatusCode;
        //}

        //public async Task<bool> DeleteArticle(Guid id)
        //{
        //    var response = await _httpClient.DeleteAsync($"article/{id}");
        //    return response.IsSuccessStatusCode;
        //}

        //public async Task<HttpResponseMessage> UploadImage(MultipartFormDataContent content)
        //{
        //    return await _httpClient.PostAsync($"article/img", content);
        //}
    }
}
