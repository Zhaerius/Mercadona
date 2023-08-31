using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Shared.Upload;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class CreateArticleBase : ComponentBase, IDisposable
    {
        //[Inject] private IArticleService ArticleService { get; set; } = null!;
        protected CreateArticleModel ArticleToCreate { get; set; } = new();
        protected FakePlaceholderArticle FakePlaceholder => CreateFakePlaceholder();
        protected IEnumerable<CategoryModel>? Categories { get; set; }
        [Inject] protected UploadState UploadState { get; set; } = null!;

        protected async Task OnValidSubmit()
        {
            //await ArticleService.CreateArticle(files[0]);
        }
        protected override void OnInitialized()
        {
            UploadState.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            UploadState.OnChange -= StateHasChanged;
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
