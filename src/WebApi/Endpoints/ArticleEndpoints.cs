using Application.Core.Features.Article.Commands.CreateArticle;
using Application.Core.Features.Article.Commands.DeleteArticle;
using Application.Core.Features.Article.Commands.UpdateArticle;
using Application.Core.Features.Article.Queries.GetArticle;
using Application.Core.Features.Article.Queries.SearchArticles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class ArticleEndpoints
    {
        public static RouteGroupBuilder MapArticleEndpoints(this RouteGroupBuilder group)
        {
            // Rechercher d'un article par son nom
            group.MapGet("/search", async ([FromQuery] string name, [FromServices] IMediator mediator) =>
            {
                var articles = await mediator.Send(new SearchArticlesQuery(name));

                if (!articles.Any()) return Results.NoContent();
                return Results.Ok(articles);
            }); 

            // Get d'un article par son ID
            group.MapGet("/{id:guid}", async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
            {
                var article = await mediator.Send(new GetArticleQuery(id));
                return Results.Ok(article);
            }).RequireAuthorization();

            // Create d'un nouvel article
            group.MapPost("", async ([FromBody] CreateArticleCommand request, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(request);
                return Results.NoContent();
            });

            // Modification d'un article
            group.MapPut("", async ([FromBody] UpdateArticleCommand request, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(request);
                return Results.NoContent();
            });

            // Supression d'un article
            group.MapPost("/{id:guid}", async ([FromRoute] Guid Id, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(new DeleteArticleCommand(Id));
                return Results.NoContent();
            });

            return group;
        }
    }
}
