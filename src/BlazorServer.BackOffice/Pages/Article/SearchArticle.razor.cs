using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static MudBlazor.Defaults.Classes;
using BlazorServer.BackOffice.Models.Article;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class SearchArticleBase : ComponentBase
    {
        protected int _rowPerPage = 10;
        protected bool _displayRowNavigation = false;
        protected int _articleCount = 0;
        protected string _linkAdd = "/article/create";

        [Inject] private IArticleService ArticleService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        protected SearchArticlesRequest SearchArticlesRequest { get; set; } = new();
        protected IEnumerable<SearchArticlesResponse>? Articles { get; set; }


        protected async Task SearchArticles()
        {
            _displayRowNavigation = false;

            Articles = await ArticleService.SearchArticles(SearchArticlesRequest.Name);
            _articleCount = Articles.Count();

            if (_articleCount == 1)
                NavigationManager.NavigateTo($"/article/{Articles.First().Id}");

            if (_articleCount > _rowPerPage)
                _displayRowNavigation = true;
        }

        protected async Task DeleteArticle(Guid id)
        {
            bool isSucces = await ArticleService.DeleteArticle(id);

            if (isSucces)
            {
                Articles = Articles!.Where(a => a.Id != id).ToList();
                _articleCount = Articles.Count();
                Snackbar.Add("Article correctement supprimé", Severity.Success);
            }
            else
            {
                Snackbar.Add("Impossible de supprimer cet article", Severity.Error);
            }
        }
        protected void RedirectToDetails(Guid id) => NavigationManager.NavigateTo($"/article/{id}");

        protected void RedirectToUpdate(Guid id) => NavigationManager.NavigateTo($"/article/update/{id}");
    }
}
