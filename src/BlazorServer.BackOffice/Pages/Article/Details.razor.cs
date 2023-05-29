using BlazorServer.BackOffice.ApiServices.Abstractions;
using BlazorServer.BackOffice.Models;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class DetailsBase : ComponentBase
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] private IArticleApiService ApiService { get; set; } = null!;

        protected ArticleResponse? ArticleResponse;


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
