using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Shared.Upload;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class CreateArticleBase : ComponentBase, IDisposable
    {
        [Inject] private IArticleService ArticleService { get; set; } = null!;
        [Inject] private ICategoryService CategoryService { get; set; } = null!;
        [Inject] private UploadState UploadState { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private NavigationManager NavManager { get; set; } = null!;
        
        protected CreateArticleModel ArticleToCreate { get; set; } = new();
        protected FakePlaceholderArticle FakePlaceholder => CreateFakePlaceholder();
        protected IEnumerable<CategoryModel>? Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            UploadState.OnChange += StateHasChanged;
            Categories = await CategoryService.GetCategories();
        }

        protected async Task OnValidSubmit()
        {
            if (UploadState.UploadResults.Count > 0)
            {
                var uploadResult = UploadState.UploadResults.FirstOrDefault();
                if (uploadResult.Uploaded)
                    ArticleToCreate.Image = uploadResult.StoredFileName;
            }
            
            var result = await ArticleService.CreateArticle(ArticleToCreate);

            DisplayResultSubmit(result);

            NavManager.NavigateTo("/article");
        }

        private void DisplayResultSubmit(bool result)
        {
            if (result)
                Snackbar.Add("Article ajouté avec succès", Severity.Success);
            else
                Snackbar.Add("Impossible d'ajouter l'article", Severity.Error);
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
                2.49,
                true
                );
        }


    }
}
