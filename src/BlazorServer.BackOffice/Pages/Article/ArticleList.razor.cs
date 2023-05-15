using Application.Core.Dtos;
using Application.Core.Features.Article.Queries;
using Application.Core.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class ArticleListBase : ComponentBase
    {
        //[Inject]
        //private IArticleService ArticleService { get; set; }

        [Inject]
        private IMediator mediator { get; set; }
        protected IEnumerable<ArticleDto> Articles { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //Articles = ArticleService.GetArticles();
            var query = new GetArticlesQuery();
            var articles = await mediator.Send(query);

            Articles = articles;
        }
    }
}
