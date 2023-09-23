using Application.Core.Abstractions;
using Application.Core.Common.Exceptions;
using MediatR;

namespace Application.Core.Features.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;

        public LoginQueryHandler(IIdentityService identityService, IJwtService jwtService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
        }

        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {

            var result = await _identityService.SignInAsync(request.Username, request.Password);

            if (!result) throw new AuthException();

            var roles = await _identityService.GetRolesByUserNameAsync(request.Username);

            return _jwtService.GenerateJwtToken(request.Username, roles);
        }
    }
}
