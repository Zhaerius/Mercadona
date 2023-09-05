using BlazorServer.BackOffice.Services.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Components;
using BlazorServer.BackOffice.Models.Article;
using System.IO;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class DetailsBase : ComponentBase
    {
        protected ArticleModel? articleModel;

        [Parameter] public Guid Id { get; set; }
        [Inject] private IArticleService ArticleService { get; set; } = null!;
        [Inject] IConfiguration Configuration { get; set; } = null!;




        protected async override Task OnInitializedAsync()
        {
            var article = await ArticleService.GetDetailsArticle(Id);
            if (article != null)
            {
                articleModel = article;
                articleModel.Image = Configuration.GetValue<string>("PathFileImg") + article.Image;
            }
        }
    }
}
