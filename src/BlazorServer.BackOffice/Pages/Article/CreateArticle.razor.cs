using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services.Abstractions;
using Bogus.DataSets;
using Microsoft.AspNetCore.Components;


namespace BlazorServer.BackOffice.Pages.Article
{
    public class CreateArticleBase : ComponentBase
    {
        [Inject] private ICategoryService CategoryService { get; set; } = null!;
        protected CreateArticleModel ArticleToCreate { get; set; } = new();
        protected FakePlaceholderArticle FakePlaceholder => CreateFakePlaceholder();
        protected IEnumerable<CategoryModel>? Categories { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetCategories();
        }


        protected async Task OnValidSubmit()
        {

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
