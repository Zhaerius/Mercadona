using BlazorServer.BackOffice.Services.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Components;
using BlazorServer.BackOffice.Models.Article;
using System.IO;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class DetailsBase : ComponentBase
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] private IArticleService ArticleService { get; set; } = null!;
        [Inject] IConfiguration Configuration { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] protected NavigationManager NavManager { get; set; } = null!;
        protected ArticleModel ArticleModel { get; set; } = new();


        protected async override Task OnInitializedAsync()
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
                Snackbar.Add("Article correctement supprimé", Severity.Success);
            else
                Snackbar.Add("Action impossible", Severity.Error);
        }
    }
}
