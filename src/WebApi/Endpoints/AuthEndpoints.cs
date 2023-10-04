using Application.Core.Features.Authentication.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class AuthEndpoints
    {
        public static RouteGroupBuilder MapAuthEndpoints(this RouteGroupBuilder group)
        {
            group.MapPost("", Login)
                .Accepts<LoginQuery>(contentType: "application/json")
                .Produces<string>(200, contentType: "text/plain")
                .Produces(400)
                .Produces(401);

            return group;
        }

        private static async Task<IResult> Login([FromBody] LoginQuery request, IMediator mediator)
        {
            string? jwtToken = await mediator.Send(request);

            if (jwtToken is null)
                return Results.Unauthorized();

            return Results.Ok(jwtToken);
        }
    }
}
