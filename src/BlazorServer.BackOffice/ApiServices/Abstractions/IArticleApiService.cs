using BlazorServer.BackOffice.Models;

namespace BlazorServer.BackOffice.ApiServices.Abstractions
{
    public interface IArticleApiService
    {
        Task<IEnumerable<SearchArticlesResponse>?> SearchArticles(string? name);
    }
}