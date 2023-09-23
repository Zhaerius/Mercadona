using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class HandlerArticlePromotionBase : ComponentBase
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] private ArticleService ArticleService { get; set; } = null!;

        protected HandlerArticlePromotionResponse ArticleWithPromotions { get; set; } = new HandlerArticlePromotionResponse();

        protected override async Task OnInitializedAsync()
        {
            ArticleWithPromotions = await ArticleService.GetArticleByIdWithPromotions(Id);
        }


    }
}
