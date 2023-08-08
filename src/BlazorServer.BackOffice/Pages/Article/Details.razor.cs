using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;
using MediatR;
using Microsoft.AspNetCore.Components;

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
