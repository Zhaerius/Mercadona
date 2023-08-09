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
            // Retourne toutes les catégories
            group.MapGet("", async ([FromServices] IMediator mediator) =>
            {
                var categories = await mediator.Send(new GetCategoriesQuery());

                if (!categories.Any()) 
                    return Results.NoContent();

                return Results.Ok(categories);
            });

            // Supprimer une catégorie
            group.MapDelete("/{Id:guid}", async ([FromRoute] Guid Id, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(new DeleteCategoryCommand(Id));
                return Results.NoContent();
            });

            // Ajouter une catégorie
            group.MapPost("", async ([FromBody] CreateCategoryCommand createCategory, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(createCategory);
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
    }
}
