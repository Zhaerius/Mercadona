using Microsoft.AspNetCore.Components;
using MudBlazor;
using BlazorWasm.Models.Article;
using BlazorWasm.Services;

namespace BlazorWasm.Pages.Article
{
    public class SearchArticleBase : ComponentBase
    {
        protected int _rowPerPage = 10;
        protected bool _displayRowNavigation = false;
        protected int _articleCount = 0;
        protected string _linkAdd = "/article/create";
        protected bool _loader;

        [Inject] private ArticleService ArticleService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        protected SearchArticlesRequest SearchArticlesRequest { get; set; } = new();
        protected IEnumerable<SearchArticlesResponse>? Articles { get; set; }
        protected event Action<Guid> OnUpdateList = null!;

        protected override void OnInitialized()
        {
            OnUpdateList += UpdateArticles;
            base.OnInitialized();
        }

        protected async Task SearchArticles()
        {
            Articles = null;
            _displayRowNavigation = false;
            _loader = true;
            StateHasChanged();

            Articles = await ArticleService.SearchArticles(SearchArticlesRequest.Name);
            _articleCount = Articles.Count();

            _loader = false;
            StateHasChanged();

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
                OnUpdateList(id);
                Snackbar.Add("Article supprimé", Severity.Success);
            }
            else
            {
                Snackbar.Add("Action impossible", Severity.Error);
            }
        }
        protected void RedirectToDetails(Guid id) => NavigationManager.NavigateTo($"/article/{id}");

        protected void RedirectToUpdate(Guid id) => NavigationManager.NavigateTo($"/article/update/{id}");

        private void UpdateArticles(Guid id)
        {
            Articles = Articles!.Where(a => a.Id != id).ToList();
            _articleCount = Articles.Count();
        }
    }
}
