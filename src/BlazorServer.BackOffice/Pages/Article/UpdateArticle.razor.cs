using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class UpdateArticleBase : ComponentBase
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] private IArticleService ArticleService { get; set; } = null!;
        protected Models.Article.Article? ArticleToUpdate { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            ArticleToUpdate = await ArticleService.GetArticleById(Id);
        }

        protected void OnValidSubmit()
        {

        }

    }
}
