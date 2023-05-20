using Application.Core.Features.Article.Commands.CreateArticle;
using Application.Core.Features.Article.Queries.GetArticle;
using Application.Core.Features.Article.Queries.GetArticles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class ArticleEndpoints
    {
        public static RouteGroupBuilder MapArticleEndpoints(this RouteGroupBuilder group) 
        {
            group.MapGet("", async ([FromServices] IMediator mediator) =>
            {
                var query = new GetArticlesQuery();
                return await mediator.Send(query);
            });

            group.MapGet("/{id:guid}", async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
            {
                var query = new GetArticleQuery(id);
                return await mediator.Send(query);
            });

            group.MapPost("", async (CreateArticleCommand request, [FromServices] IMediator mediator) =>
            {
                return await mediator.Send(request);
            });

            return group;
        }
    }
}
