using BlazorServer.BackOffice.Components.Upload;
using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class UpdateArticleBase : ComponentBase, IDisposable
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] private IArticleService ArticleService { get; set; } = null!;
        [Inject] private ICategoryService CategoryService { get; set; } = null!;
        [Inject] private UploadState UploadState { get; set; } = null!;
        protected UpdateArticleRequest ArticleToUpdate { get; set; } = new();
        protected IEnumerable<CategoryModel>? Categories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            UploadState.OnChange += StateHasChanged;

            var articleDetails = await ArticleService.GetArticleById(Id);
            if (articleDetails == null)
            {
                //Todo Gestion Erreur
            }

            ArticleToUpdate = new UpdateArticleRequest()
            {
                Id = articleDetails.Id,
                Name = articleDetails.Name,
                Description = articleDetails.Description,
                CategoryId = articleDetails.CategoryId,
                Image = articleDetails.Image,
                BasePrice = articleDetails.BasePrice,
                Publish = articleDetails.Publish
            };

            Categories = await CategoryService.GetCategories();

            if (!string.IsNullOrEmpty(articleDetails.Image))
            {
                var result = new UploadResult()
                {
                    FileName = articleDetails.Image,
                    ErrorCode = 0,
                    StoredFileName = articleDetails.Image,
                    Uploaded = true
                };
                UploadState.AddToList(result);
            }
        }

        protected void OnValidSubmit()
        {

        }

        public void Dispose()
        {
            UploadState.OnChange -= StateHasChanged;
            UploadState.ClearList();
        }

    }
}
