using Application.Core.Features.Category.Commands.CreateCategories;
using Application.Core.Features.Category.Commands.CreateCategory;
using Application.Core.Features.Category.Commands.DeleteCategory;
using Application.Core.Features.Category.Commands.UpdateCategory;
using Application.Core.Features.Category.Queries.GetCategorie;
using Application.Core.Features.Category.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class CategoryEndpoints
    {
        public static RouteGroupBuilder MapCategoryEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("", GetAll)
                .Produces<IEnumerable<GetCategorieQueryResponse>>(200, "application/json")
                .Produces(204)
                .Produces(400)
                .Produces(401);

            group.MapGet("/{id:guid}", GetById)
                .Produces<GetCategorieQueryResponse>(200, "application/json")
                .Produces(401)
                .Produces(404);

            group.MapDelete("/{id:guid}", Delete)
                .Produces(204)
                .Produces(400)
                .Produces(401)
                .Produces(404);

            group.MapPost("", CreateOne)
                .Produces(204)
                .Produces(400)
                .Produces(401);

            group.MapPost("/multimode", CreateMulti)
                .Produces(204)
                .Produces(400)
                .Produces(401);

            group.MapPut("", Update)
                .Produces(204)
                .Produces(400)
                .Produces(401)
                .Produces(404);

            return group;
        }

        private static async Task<IResult> GetById([FromRoute] Guid id, [FromServices] IMediator mediator)
        {
            var categorie = await mediator.Send(new GetCategorieQuery(id));
            return Results.Ok(categorie);
        }

        private static async Task<IResult> GetAll([FromServices] IMediator mediator)
        {
            var categories = await mediator.Send(new GetCategoriesQuery());

            if (!categories.Any())
                return Results.NoContent();

            return Results.Ok(categories);
        }

        private static async Task<IResult> Delete([FromRoute] Guid id, [FromServices] IMediator mediator)
        {
            await mediator.Send(new DeleteCategoryCommand(id));
            return Results.NoContent();
        }

        private static async Task<IResult> CreateOne([FromBody] CreateCategoryCommand createCategory, [FromServices] IMediator mediator)
        {
            await mediator.Send(createCategory);
            return Results.NoContent();
        }

        private static async Task<IResult> CreateMulti([FromBody] CreateCategoriesCommand createCategories, [FromServices] IMediator mediator)
        {
            await mediator.Send(createCategories);
            return Results.NoContent();
        }

        private static async Task<IResult> Update([FromBody] UpdateCategoryCommand updateCategory, [FromServices] IMediator mediator)
        {
            await mediator.Send(updateCategory);
            return Results.NoContent();
        }
    }
}
