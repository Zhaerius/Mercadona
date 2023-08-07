using BlazorServer.BackOffice.Services;
using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class SearchArticleBase : ComponentBase
    {
        protected int rowPerPage = 10;
        protected bool displayRowNavigation = false;
        protected int articleCount = 0;
        [Inject] private IArticleService ArticleService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        protected SearchArticlesRequest SearchArticlesRequest = new();
        protected IEnumerable<SearchArticlesResponse>? Articles;

        protected async Task SearchArticles()
        {
            displayRowNavigation = false;

            Articles = await ArticleService.SearchArticles(SearchArticlesRequest.Name);
            articleCount = Articles.Count();

            if (Articles != null && articleCount == 1)
                NavigationManager.NavigateTo($"/article/{Articles.First().Id}");

            if (articleCount > rowPerPage)
                displayRowNavigation = true;
        }
    }
}
