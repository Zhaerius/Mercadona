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
            //Rechercher d'un article par son nom
            group.MapGet("/search", async ([FromQuery] string name, [FromServices] IMediator mediator) =>
            {
                var articles = await mediator.Send(new SearchArticlesQuery(name));

                if (!articles.Any()) return Results.NoContent();
                return Results.Ok(articles);
            }); 


            group.MapGet("/{id:guid}", async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
            {
                var article = await mediator.Send(new GetArticleQuery(id));
                return Results.Ok(article);
            });



            //group.MapGet("", async ([FromServices] IMediator mediator) =>
            //{
            //    var query = new GetArticlesQuery();
            //    return await mediator.Send(query);
            //});



            //group.MapPost("", async (CreateArticleCommand request, [FromServices] IMediator mediator) =>
            //{
            //    return await mediator.Send(request);
            //});

            return group;
        }
    }
}
