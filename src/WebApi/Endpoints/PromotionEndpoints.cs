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
            group.MapPost("", Add);

            group.MapPost("/{Id:guid}", Delete);

            group.MapPut("", Update);

            return group;
        }
        private static async Task<IResult> Add([FromBody] CreatePromotionCommand createPromotion, [FromServices] IMediator mediator)
        {
            await mediator.Send(createPromotion);
            return Results.NoContent();
        }
        private static async Task<IResult> Delete([FromRoute] Guid Id, [FromServices] IMediator mediator)
        {
            await mediator.Send(new DeletePromotionCommand(Id));
            return Results.NoContent();
        }
        private static async Task<IResult> Update([FromBody] UpdatePromotionCommand updatePromotion, [FromServices] IMediator mediator)
        {
            await mediator.Send(updatePromotion);
            return Results.NoContent();
        }
    }
}
