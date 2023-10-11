using Application.Core.Features.Promotion.Commands.CreatePromotion;
using Application.Core.Features.Promotion.Commands.DeletePromotion;
using Application.Core.Features.Promotion.Commands.UpdatePromotion;
using Application.Core.Features.Promotion.Queries.GetPromotion;
using Application.Core.Features.Promotion.Queries.GetPromotionsByStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class PromotionEndpoints
    {
        public static RouteGroupBuilder MapPromotionEndpoints(this RouteGroupBuilder group)
        {
            group.MapPost("", Add)
                .RequireAuthorization("RequireUserMercadona")
                .Produces<Guid>(201, contentType: "text/plain")
                .Produces(400)
                .Produces(401);

            group.MapDelete("/{id:guid}", Delete)
                .RequireAuthorization("RequireUserMercadona")
                .Produces(204)
                .Produces(400)
                .Produces(401)
                .Produces(404);

            group.MapPut("", Update)
                .RequireAuthorization("RequireUserMercadona")
                .Produces(204)
                .Produces(400)
                .Produces(401)
                .Produces(404);

            group.MapGet("/{isActive:bool}", GetPromotionsByStatus)
                .AllowAnonymous()
                .Produces<IEnumerable<GetPromotionsByStatusQueryResponse>>(200, "application/json")
                .Produces(204)
                .Produces(400)
                .Produces(401);

            group.MapGet("/{id:guid}", GetById)
                .AllowAnonymous()
                .WithName("GetPromotionById")
                .Produces<GetPromotionsByStatusQueryResponse>(200, "application/json")
                .Produces(401)
                .Produces(404);

            return group;
        }
        private static async Task<IResult> Add([FromBody] CreatePromotionCommand createPromotion, [FromServices] IMediator mediator, [FromServices] LinkGenerator linkGenerator, HttpContext httpContext)
        {
            var result = await mediator.Send(createPromotion);
            string path = linkGenerator.GetUriByName(httpContext, "GetPromotionById", new { id = result })!;

            return Results.Created(path, result);
        }

        private static async Task<IResult> GetById([FromRoute] Guid id, [FromServices] IMediator mediator)
        {
            var article = await mediator.Send(new GetPromotionQuery(id));
            return Results.Ok(article);
        }

        private static async Task<IResult> GetPromotionsByStatus([FromRoute] bool isActive, [FromServices] IMediator mediator)
        {
            var promotions = await mediator.Send(new GetPromotionsByStatusQuery(isActive));

            if (!promotions.Any())
                return Results.NoContent();

            return Results.Ok(promotions);
        }

        private static async Task<IResult> Delete([FromRoute] Guid id, [FromServices] IMediator mediator)
        {
            await mediator.Send(new DeletePromotionCommand(id));
            return Results.NoContent();
        }

        private static async Task<IResult> Update([FromBody] UpdatePromotionCommand updatePromotion, [FromServices] IMediator mediator)
        {
            await mediator.Send(updatePromotion);
            return Results.NoContent();
        }
    }
}
