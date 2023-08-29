using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Net.Http.Headers;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class CreateArticleBase : ComponentBase
    {
        [Inject] private IArticleService ArticleService { get; set; } = null!;
        protected CreateArticleModel ArticleToCreate { get; set; } = new();
        protected FakePlaceholderArticle FakePlaceholder => CreateFakePlaceholder();
        protected IEnumerable<CategoryModel>? Categories { get; set; }

        protected IList<IBrowserFile> files = new List<IBrowserFile>();

        protected async Task OnValidSubmit()
        {
            //await ArticleService.CreateArticle(files[0]);
        }


        protected void UploadFiles(IBrowserFile file)
        {
            files.Add(file);

            using var content = new MultipartFormDataContent();

            file.OpenReadStream();

            var fileContent =
                        new StreamContent(file.OpenReadStream());

            fileContent.Headers.ContentType =
                new MediaTypeHeaderValue(file.ContentType);

            content.Add(
                content: fileContent,
                name: "\"files\"",
                fileName: file.Name);

            //ArticleService.CreateArticle(content);
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
