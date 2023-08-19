using BlazorServer.BackOffice.Services.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Components;
using BlazorServer.BackOffice.Models.Article;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class DetailsBase : ComponentBase
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] private IArticleService ApiService { get; set; } = null!;

        protected CreateArticleModel? ArticleResponse;


        protected async override Task OnInitializedAsync()
        {
            var article = await ApiService.GetDetailsArticle(Id);
            if (article != null)
            {
                ArticleResponse = article;
            }
        }
    }
}
