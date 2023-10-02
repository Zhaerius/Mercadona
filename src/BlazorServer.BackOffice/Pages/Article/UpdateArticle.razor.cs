using BlazorServer.BackOffice.Components.Upload;
using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Models.Promotion;
using BlazorServer.BackOffice.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class UpdateArticleBase : ComponentBase, IDisposable
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] private ArticleService ArticleService { get; set; } = null!;
        [Inject] private CategoryService CategoryService { get; set; } = null!;
        [Inject] private PromotionService PromotionService { get; set; } = null!;
        [Inject] private UploadState UploadState { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private NavigationManager NavManager { get; set; } = null!;
        protected UpdateArticleRequest ArticleToUpdate { get; set; } = new();
        protected IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        protected IEnumerable<PromotionModel> Promotions { get; set; } = new List<PromotionModel>();

        protected override async Task OnInitializedAsync()
        {
            UploadState.OnChange += StateHasChanged;
            Categories = await CategoryService.GetCategories();
            Promotions = await PromotionService.GetPromotionByStatus(true);

            var articleDetails = await ArticleService.GetArticleById(Id);

            if (articleDetails != null)
            {
                ArticleToUpdate = new UpdateArticleRequest()
                {
                    Id = articleDetails.Id,
                    Name = articleDetails.Name,
                    Description = articleDetails.Description,
                    CategoryId = articleDetails.CategoryId,
                    Image = articleDetails.Image,
                    BasePrice = articleDetails.BasePrice,
                    Publish = articleDetails.Publish,
                    PromotionsIds = articleDetails.Promotions.Select(p => p.Id)
            };

                if (!string.IsNullOrEmpty(articleDetails.Image))
                {
                    var result = new UploadResult(true, articleDetails.Image, articleDetails.Image, 0);
                    UploadState.AddToList(result);
                }
            }           
        }

        protected async Task OnValidSubmit()
        {
            if (UploadState.UploadResults.Count > 0)
            {
                var uploadResult = UploadState.UploadResults.FirstOrDefault();
                if (uploadResult != null && uploadResult.Uploaded)
                    ArticleToUpdate.Image = uploadResult.StoredFileName;
            }

            var result = await ArticleService.UpdateArticle(ArticleToUpdate);
            DisplayResultSubmit(result);

            if (result)
                NavManager.NavigateTo($"/article/{ArticleToUpdate.Id}");
        }

        private void DisplayResultSubmit(bool result)
        {
            if (result)
                Snackbar.Add("Article mis à jour", Severity.Success);
            else
                Snackbar.Add("Action impossible", Severity.Error);
        }

        public void Dispose()
        {
            UploadState.OnChange -= StateHasChanged;
            UploadState.ClearList();
        }
    }
}
