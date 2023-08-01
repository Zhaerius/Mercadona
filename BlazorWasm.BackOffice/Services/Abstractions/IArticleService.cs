using BlazorWasm.BackOffice.Models;

namespace BlazorWasm.BackOffice.Services.Abstractions
{
    public interface IArticleService
    {
        Task<IEnumerable<SearchArticlesResponse>> SearchArticles(string name);
        Task<ArticleResponse> GetDetailsArticle(Guid id);
    }
}