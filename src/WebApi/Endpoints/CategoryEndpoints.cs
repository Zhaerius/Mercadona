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
            group.MapGet("", GetAll);

            group.MapGet("/{id:guid}", GetById);

            group.MapDelete("/{Id:guid}", Delete);

            group.MapPost("", CreateOne);

            group.MapPost("/multimode", CreateMulti);

            group.MapPut("", Update);

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

        private static async Task<IResult> Delete([FromRoute] Guid Id, [FromServices] IMediator mediator)
        {
            await mediator.Send(new DeleteCategoryCommand(Id));
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
