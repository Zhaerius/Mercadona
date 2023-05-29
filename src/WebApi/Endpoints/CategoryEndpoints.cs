using Application.Core.Features.Category.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class CategoryEndpoints
    {
        public static RouteGroupBuilder MapCategoryEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("", async ([FromServices] IMediator mediator) =>
            {
                var categories = await mediator.Send(new GetCategoriesQuery());

                if (!categories.Any()) 
                    return Results.NoContent();

                return Results.Ok(categories);
            });

            return group;
        }
    }
}
