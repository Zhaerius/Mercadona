using Application.Core.Features.Promotion.Commands.CreatePromotion;
using Application.Core.Features.Promotion.Commands.DeletePromotion;
using Application.Core.Features.Promotion.Commands.UpdatePromotion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class PromotionEndpoints
    {
        public static RouteGroupBuilder MapPromotionEndpoints(this RouteGroupBuilder group)
        {
            // Creation d'une promotion
            group.MapPost("", async ([FromBody] CreatePromotionCommand createPromotion, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(createPromotion);
                return Results.NoContent();
            });

            // Supression d'une promotion
            group.MapPost("/{Id:guid}", async ([FromRoute] Guid Id, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(new DeletePromotionCommand(Id));
                return Results.NoContent();
            });

            //Update d'une promotion
            group.MapPut("", async ([FromBody] UpdatePromotionCommand updatePromotion, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(updatePromotion);
                return Results.NoContent();
            });

            return group;
        }
    }
}
