using BlazorServer.BackOffice.Models;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}