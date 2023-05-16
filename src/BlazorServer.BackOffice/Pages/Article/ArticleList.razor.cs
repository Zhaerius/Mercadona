using Application.Core.Dtos;
using Application.Core.Features.Article.Queries.GetArticles;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Article
{
    public class ArticleListBase : ComponentBase
    {
        [Inject]
        private IMediator mediator { get; set; }
        protected IEnumerable<ArticleDto> Articles { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var query = new GetArticlesQuery();
            var articles = await mediator.Send(query);

            Articles = articles;
        }
    }
}
