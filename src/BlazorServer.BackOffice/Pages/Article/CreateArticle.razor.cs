
using BlazorServer.BackOffice.Models;
using Microsoft.AspNetCore.Components;


namespace BlazorServer.BackOffice.Pages.Article
{
    public class CreateArticleBase : ComponentBase
    {
        protected CreateArticleModel ArticleToCreate { get; set; } = new();
        protected CreateArticleModel FakePlaceholder => CreateFakePlaceholder();


        protected async Task OnValidSubmit()
        {

        }

        private CreateArticleModel CreateFakePlaceholder()
        {
            return new CreateArticleModel
            {
                Name = "Coco Pops",
                Description = "Pour bien commencer la journée, rien de tel qu'un petit déjeuner avec Coco Pops de Kellogg's et son ami Coco, le singe malicieux ! De délicieuses céréales de riz soufflé au bon goût de chocolat de la jungle",
                BasePrice = 2.49,
                Publish = true,
            };
        }

    }
}
