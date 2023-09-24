using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Promotion;
using BlazorServer.BackOffice.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class HandlerArticlePromotionBase : ComponentBase
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] private ArticleService ArticleService { get; set; } = null!;
        [Inject] private PromotionService PromotionService { get; set; } = null!;

        protected ArticleModel ArticleWithPromotions { get; set; } = new ArticleModel();
        protected IEnumerable<PromotionModel> PromotionsAvailable { get; set; } = new List<PromotionModel>();

        protected override async Task OnInitializedAsync()
        {
            ArticleWithPromotions = await ArticleService.GetArticleByIdWithPromotions(Id);
            var idToExclude = ArticleWithPromotions.Promotions!.Select(p => p.Id);

            var promotions = await PromotionService.GetPromotionByStatus(true);
            PromotionsAvailable = promotions.Where(p => !idToExclude.Any(b => p.Id == b)).ToList();
        }


    }
}
