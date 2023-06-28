using Application.Core.Abstractions;
using Application.Core.Exceptions;
using MediatR;

namespace Application.Core.Features.Authentication.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(IIdentityService identityService, IJwtService jwtService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var result = await _identityService.SignInAsync(request.Username, request.Password);

            if (!result) throw new AuthException();

            var roles = await _identityService.GetRolesByUserNameAsync(request.Username);

            return _jwtService.GenerateJwtToken(request.Username, roles);
        }
    }
}
