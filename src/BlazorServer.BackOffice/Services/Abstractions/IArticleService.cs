using BlazorServer.BackOffice.Models.Article;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface IArticleService
    {
        Task<Guid?> CreateArticle(CreateArticleRequest createArticle);
        Task<ArticleModel> GetArticleById(Guid id);
        Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name);
        Task<bool> UpdateArticle(UpdateArticleRequest updateArticleRequest);
        Task<bool> DeleteArticle(Guid id);
        Task<HttpResponseMessage> UploadImage(MultipartFormDataContent content);


    }
}