using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.Defaults.Classes;
using BlazorServer.BackOffice.Models.Article;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class SearchArticleBase : ComponentBase
    {
        protected int rowPerPage = 10;
        protected bool displayRowNavigation = false;
        protected int articleCount = 0;
        protected string linkAdd = "/article/create";

        [Inject] private IArticleService ArticleService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        protected SearchArticlesRequest SearchArticlesRequest { get; set; } = new();
        protected IEnumerable<SearchArticlesResponse> Articles { get; set; } = null!;


        protected async Task SearchArticles()
        {
            displayRowNavigation = false;

            Articles = await ArticleService.SearchArticles(SearchArticlesRequest.Name);
            articleCount = Articles.Count();

            if (articleCount == 1)
                NavigationManager.NavigateTo($"/article/{Articles.First().Id}");

            if (articleCount > rowPerPage)
                displayRowNavigation = true;
        }

        protected void RedirectToDetails(Guid id)
        {
            NavigationManager.NavigateTo($"/article/{id}");
        }

        protected async Task DeleteArticle(Guid id)
        {
            bool isSucces = await ArticleService.DeleteArticle(id);

            if (isSucces)
            {
                Articles = Articles.Where(a => a.Id != id).ToList();
                articleCount = Articles.Count();
                Snackbar.Add("Article correctement supprimé", Severity.Success);
            }
            else
            {
                Snackbar.Add("Impossible de supprimer cet article", Severity.Error);
            }
        }
    }
}
