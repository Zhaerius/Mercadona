using BlazorServer.BackOffice.Models;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface IArticleService
    {
        Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name);
        Task<ArticleResponse> GetDetailsArticle(Guid id);
        Task<bool> DeleteArticle(Guid id);
    }
}