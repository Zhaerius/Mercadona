using Application.Core.Dtos;
using Application.Core.Interfaces.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class ArticleListBase : ComponentBase
    {
        [Inject]
        private IArticleService ArticleService { get; set; }
        protected IEnumerable<ArticleDto> Articles { get; set; }

        protected override void OnInitialized()
        {
            Articles = ArticleService.GetArticles();
            base.OnInitialized();
        }
    }
}
