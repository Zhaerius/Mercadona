using BlazorWasm.Models.Article;
using BlazorWasm.Models.Promotion;
using BlazorWasm.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWasm.Pages.Article
{
    public class HandlerArticlePromotionBase : ComponentBase
    {
        protected HashSet<PromotionModel> _selectedItems = new();
        protected bool _selectOnRowClick = true;
        protected MudTable<PromotionModel>? _mudTable;

        [Parameter] public Guid Id { get; set; }
        [Inject] private ArticleService ArticleService { get; set; } = null!;
        [Inject] private PromotionService PromotionService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private NavigationManager NavManager { get; set; } = null!;

        protected ArticleModel Articles { get; set; } = new ArticleModel();
        protected IEnumerable<PromotionModel> PromotionsAvailable { get; set; } = new List<PromotionModel>();

        protected override async Task OnInitializedAsync()
        {
            Articles = await ArticleService.GetArticleById(Id);
            PromotionsAvailable = await PromotionService.GetPromotionByStatus(true);

            var idsToAdd = Articles.Promotions!.Select(p => p.Id);
            var promotionsToAddSelected = PromotionsAvailable.Where(p => idsToAdd.Any(i => p.Id == i)).ToList();

            foreach (var promotion in promotionsToAddSelected)
            {
                _selectedItems.Add(promotion);
            }
        }

        protected async Task OnValidSubmit()
        {
            var articleToUpdate = new UpdateArticleRequest()
            {
                Id = Articles.Id,
                BasePrice = Articles.BasePrice,
                Description = Articles.Description,
                CategoryId = Articles.CategoryId,
                Image = Articles.Image,
                Name = Articles.Name,
                Publish = Articles.Publish,
                PromotionsIds = _selectedItems.Select(p => p.Id)
            };

            var result = await ArticleService.UpdateArticle(articleToUpdate);
            DisplayResultSubmit(result);

            if (result)
                NavManager.NavigateTo($"/article/{Id}");
        }

        private void DisplayResultSubmit(bool result)
        {
            if (result)
                Snackbar.Add("Promotions à jour", Severity.Success);
            else
                Snackbar.Add("Action impossible", Severity.Error);
        }
    }
}
