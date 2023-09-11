using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Promotion;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface IPromotionService
    {
        Task<bool> CreatePromotion(CreatePromotionRequest createPromotion);
        //Task<ArticleModel> GetArticleById(Guid id);
        //Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name);
        //Task<bool> UpdateArticle(UpdateArticleRequest updateArticleRequest);
        //Task<bool> DeleteArticle(Guid id);
        //Task<HttpResponseMessage> UploadImage(MultipartFormDataContent content);
    }
}