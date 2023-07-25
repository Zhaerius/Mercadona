using BlazorServer.BackOffice.Services;
using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class SearchBase : ComponentBase
    {
        [Inject] private IArticleService ArticleService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        protected SearchArticlesRequest SearchArticlesRequest = new();
        protected IEnumerable<SearchArticlesResponse>? Articles;

        protected async Task SearchArticles()
        {
            Articles = await ArticleService.SearchArticles(SearchArticlesRequest.Name);

            if (Articles != null && Articles.Count() == 1)
                NavigationManager.NavigateTo($"/article/{Articles.First().Id}");
        }
    }
}
