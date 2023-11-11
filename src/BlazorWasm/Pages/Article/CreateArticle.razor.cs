using BlazorWasm.Components.Upload;
using BlazorWasm.Models.Article;
using BlazorWasm.Models.Category;
using BlazorWasm.Models.Promotion;
using BlazorWasm.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWasm.Pages.Article
{
    public class CreateArticleBase : ComponentBase, IDisposable
    {
        protected bool _isVisible;

        [Inject] private ArticleService ArticleService { get; set; } = null!;
        [Inject] private CategoryService CategoryService { get; set; } = null!;
        [Inject] private PromotionService PromotionService { get; set; } = null!;
        [Inject] private UploadState UploadState { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private NavigationManager NavManager { get; set; } = null!;

        protected CreateArticleRequest ArticleToCreate { get; set; } = new();
        protected IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        protected IEnumerable<PromotionModel> Promotions { get; set; } = new List<PromotionModel>();
        protected FakePlaceholderArticle FakePlaceholder => CreateFakePlaceholder();

        protected async Task SetPromotionCreated(Guid id)
        {
            ToggleOverlay(false);
            Promotions = await PromotionService.GetPromotionByStatus(true);

            //Solution de contournement bug mudblazor
            var promotionIds = ArticleToCreate.PromotionsIds.ToList();
            promotionIds.Add(id);
            ArticleToCreate.PromotionsIds = promotionIds.ToList();
        }

        protected void ToggleOverlay(bool value)
        {
            _isVisible = value;
        }
        
        protected override async Task OnInitializedAsync()
        {
            UploadState.OnChange += StateHasChanged;
            Categories = await CategoryService.GetCategories();
            Promotions = await PromotionService.GetPromotionByStatus(true);
        }

        protected async Task OnValidSubmit()
        {
            if (UploadState.UploadResults.Count > 0)
            {
                var uploadResult = UploadState.UploadResults.FirstOrDefault();
                if (uploadResult!.Uploaded)
                    ArticleToCreate.Image = uploadResult.StoredFileName;
            }

            Guid? id = await ArticleService.CreateArticle(ArticleToCreate);

            bool valueToDisplay = id != null ? true : false;

            if (valueToDisplay)
                NavManager.NavigateTo($"/article/{id}");

            DisplayResultSubmit(valueToDisplay);
        }

        private void DisplayResultSubmit(bool result)
        {
            if (result)
                Snackbar.Add("Article ajouté", Severity.Success);
            else
                Snackbar.Add("Action impossible", Severity.Error);
        }

        public void Dispose()
        {
            UploadState.OnChange -= StateHasChanged;
            UploadState.ClearList();
        }


        private FakePlaceholderArticle CreateFakePlaceholder()
        {
            return new FakePlaceholderArticle(
                "Coco Pops",
                "Pour bien commencer la journée, rien de tel qu'un petit déjeuner avec Coco Pops de Kellogg's et son ami Coco, le singe malicieux ! De délicieuses céréales de riz soufflé au bon goût de chocolat de la jungle",
                "Céréales",
                2.49M,
                true
                );
        }


    }
}
