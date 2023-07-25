using Application.Core.Features.Authentication.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints
{
    public static class AuthEndpoints
    {
        public static RouteGroupBuilder MapAuthEndpoints(this RouteGroupBuilder group)
        {
            group.MapPost("", async ([FromBody] LoginQuery request, IMediator mediator) =>
            {
                string jwtToken = await mediator.Send(request);
                return Results.Ok(jwtToken);
            });

            return group;
        }
    }
}
