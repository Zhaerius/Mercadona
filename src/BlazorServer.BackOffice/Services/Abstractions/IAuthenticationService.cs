using BlazorServer.BackOffice.Models.Auth;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> Login(LoginRequest loginRequest);
        public Task Logout();
    }
}