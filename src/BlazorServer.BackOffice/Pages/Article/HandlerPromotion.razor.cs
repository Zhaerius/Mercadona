using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Promotion;
using BlazorServer.BackOffice.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class HandlerArticlePromotionBase : ComponentBase
    {
        protected HashSet<PromotionModel> selectedItems = new HashSet<PromotionModel>();
        protected bool selectOnRowClick = true;
        protected MudTable<PromotionModel> mudTable;

        [Parameter] public Guid Id { get; set; }
        [Inject] private ArticleService ArticleService { get; set; } = null!;
        [Inject] private PromotionService PromotionService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private NavigationManager NavManager { get; set; } = null!;

        protected ArticleModel ArticleWithPromotions { get; set; } = new ArticleModel();
        protected IEnumerable<PromotionModel> PromotionsAvailable { get; set; } = new List<PromotionModel>();

        protected override async Task OnInitializedAsync()
        {
            ArticleWithPromotions = await ArticleService.GetArticleByIdWithPromotions(Id);
            PromotionsAvailable = await PromotionService.GetPromotionByStatus(true);

            var idToAdd = ArticleWithPromotions.Promotions!.Select(p => p.Id);
            var promotionsToAddSelected = PromotionsAvailable.Where(p => idToAdd.Any(i => p.Id == i)).ToList();

            foreach (var promotion in promotionsToAddSelected)
            {
                selectedItems.Add(promotion);
            }
        }

        protected async Task OnValidSubmit()
        {
            var articleToUpdate = new UpdateArticleRequest()
            {
                Id = ArticleWithPromotions.Id,
                BasePrice = ArticleWithPromotions.BasePrice,
                Description = ArticleWithPromotions.Description,
                CategoryId = ArticleWithPromotions.CategoryId,
                Image = ArticleWithPromotions.Image,
                Name = ArticleWithPromotions.Name,
                Publish = ArticleWithPromotions.Publish,
                PromotionsIds = selectedItems.Select(p => p.Id)
            };

            var result = await ArticleService.UpdateArticle(articleToUpdate);
            DisplayResultSubmit(result);

            if (result)
                NavManager.NavigateTo($"/article/{Id}");
        }

        private void DisplayResultSubmit(bool result)
        {
            if (result)
                Snackbar.Add("Promotion à jour", Severity.Success);
            else
                Snackbar.Add("Maj impossible", Severity.Error);
        }
    }
}
