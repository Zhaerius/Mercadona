using Application.Core.Features.Article.Queries.SearchArticles;
using Application.Core.Features.Category.Commands.CreateCategories;
using Application.Core.Features.Category.Commands.CreateCategory;
using Application.Core.Features.Category.Commands.DeleteCategory;
using Application.Core.Features.Category.Commands.UpdateCategory;
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

            group.MapDelete("/{Id:guid}", Delete);

            // Ajouter une catégorie
            group.MapPost("", async ([FromBody] CreateCategoryCommand createCategory, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(createCategory);
                return Results.NoContent();
            });

            // Ajouter plusieurs catégories
            group.MapPost("/multimode", async ([FromBody] CreateCategoriesCommand createCategories, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(createCategories);
                return Results.NoContent();
            });

            // Update d'une catégorie
            group.MapPut("", async ([FromBody] UpdateCategoryCommand updateCategory, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(updateCategory);
                return Results.NoContent();
            });

            return group;
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
    }
}
