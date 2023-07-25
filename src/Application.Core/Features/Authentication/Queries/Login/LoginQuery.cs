using MediatR;

namespace Application.Core.Features.Authentication.Queries.Login
{
    public record LoginQuery(string Username, string Password) : IRequest<string>
    {
    }
}
