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
        protected Models.Article.ArticleModel? articleModel;

        [Parameter] public Guid Id { get; set; }
        [Inject] private IArticleService ArticleService { get; set; } = null!;
        [Inject] IConfiguration Configuration { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private NavigationManager NavManager { get; set; } = null!;




        protected async override Task OnInitializedAsync()
        {
            //TODO = récupérer le nom de la catégory
            var article = await ArticleService.GetArticleById(Id);
            if (article != null)
            {
                articleModel = article;
                articleModel.Image = Configuration.GetValue<string>("PathFileImg") + article.Image;
            }
        }

        protected async Task DeleteArticle()
        {
            var result = await ArticleService.DeleteArticle(articleModel!.Id);
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
