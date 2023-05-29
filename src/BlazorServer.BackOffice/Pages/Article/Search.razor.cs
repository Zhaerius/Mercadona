using BlazorServer.BackOffice.ApiServices;
using BlazorServer.BackOffice.ApiServices.Abstractions;
using BlazorServer.BackOffice.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class SearchBase : ComponentBase
    {
        [Inject] private IArticleApiService ApiService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        protected SearchArticlesRequest SearchArticlesRequest = new();
        protected IEnumerable<SearchArticlesResponse>? Articles;

        protected async Task SearchArticles()
        {
            Articles = await ApiService.SearchArticles(SearchArticlesRequest.Name);

            if (Articles != null && Articles.Count() == 1)
                NavigationManager.NavigateTo($"/article/{Articles.First().Id}");
        }
    }
}
