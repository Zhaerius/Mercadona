using Application.Core.Features.Promotion.Commands.CreatePromotion;
using Application.Core.Features.Promotion.Commands.DeletePromotion;
using Application.Core.Features.Promotion.Commands.UpdatePromotion;
using Application.Core.Features.Promotion.Queries.GetPromotionsByStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class PromotionEndpoints
    {
        public static RouteGroupBuilder MapPromotionEndpoints(this RouteGroupBuilder group)
        {
            group.MapPost("", Add);

            group.MapDelete("/{id:guid}", Delete);

            group.MapPut("", Update);

            group.MapGet("/{isActive:bool}", GetPromotionsByStatus);

            return group;
        }
        private static async Task<IResult> Add([FromBody] CreatePromotionCommand createPromotion, [FromServices] IMediator mediator)
        {
            await mediator.Send(createPromotion);
            return Results.NoContent();
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
