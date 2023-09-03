using Application.Core.Features.Article.Commands.CreateArticle;
using Application.Core.Features.Article.Commands.DeleteArticle;
using Application.Core.Features.Article.Commands.UpdateArticle;
using Application.Core.Features.Article.Queries.GetArticle;
using Application.Core.Features.Article.Queries.SearchArticles;
using Application.Core.Features.Upload.Commands.SaveFiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class ArticleEndpoints
    {
        public static RouteGroupBuilder MapArticleEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/search", Search);

            group.MapGet("/{id:guid}", GetById);

            group.MapPost("", Add);

            group.MapPut("", Update);

            group.MapDelete("/{id:guid}", Delete);

            group.MapPost("/img", Upload);

            return group;
        }


        private static async Task<IResult> Search([FromQuery] string name, [FromServices] IMediator mediator)
        {
            var articles = await mediator.Send(new SearchArticlesQuery(name));

            if (!articles.Any()) return Results.NoContent();
            return Results.Ok(articles);
        }

        private static async Task<IResult> GetById([FromRoute] Guid id, [FromServices] IMediator mediator)
        {
            var article = await mediator.Send(new GetArticleQuery(id));
            return Results.Ok(article);
        }

        private static async Task<IResult> Upload(IFormFileCollection files, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(new SaveFilesCommand(files));
            return Results.Ok(result);
        }

        private static async Task<IResult> Update([FromBody] UpdateArticleCommand request, [FromServices] IMediator mediator)
        {
            await mediator.Send(request);
            return Results.NoContent();
        }

        private static async Task<IResult> Add([FromBody] CreateArticleCommand request, [FromServices] IMediator mediator)
        {
            await mediator.Send(request);
            return Results.NoContent();
        }

        private static async Task<IResult> Delete([FromRoute] Guid Id, [FromServices] IMediator mediator)
        {
            await mediator.Send(new DeleteArticleCommand(Id));
            return Results.NoContent();
        }
    }
}
