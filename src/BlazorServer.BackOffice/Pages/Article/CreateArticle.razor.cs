using BlazorServer.BackOffice.Components.Upload;
using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services.Abstractions;
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
        
        protected CreateArticleRequest ArticleToCreate { get; set; } = new();
        protected IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        protected FakePlaceholderArticle FakePlaceholder => CreateFakePlaceholder();

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
