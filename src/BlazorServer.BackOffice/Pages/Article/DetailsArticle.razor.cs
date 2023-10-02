using Microsoft.AspNetCore.Components;
using BlazorServer.BackOffice.Models.Article;
using MudBlazor;
using BlazorServer.BackOffice.Services;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class DetailsBase : ComponentBase
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] private ArticleService ArticleService { get; set; } = null!;
        [Inject] private IConfiguration Configuration { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] protected NavigationManager NavManager { get; set; } = null!;
        protected ArticleModel ArticleModel { get; set; } = new();


        protected override async Task OnInitializedAsync()
        {
            ArticleModel = await ArticleService.GetArticleById(Id);
            if (ArticleModel != null)
                ArticleModel.Image = Configuration.GetValue<string>("PathFileImg") + ArticleModel.Image;
        }

        protected async Task DeleteArticle()
        {
            var result = await ArticleService.DeleteArticle(ArticleModel.Id);
            DisplayResultSubmit(result);
            NavManager.NavigateTo("/article");
        }

        private void DisplayResultSubmit(bool result)
        {
            if (result)
                Snackbar.Add("Article supprimé", Severity.Success);
            else
                Snackbar.Add("Action impossible", Severity.Error);
        }
    }
}
