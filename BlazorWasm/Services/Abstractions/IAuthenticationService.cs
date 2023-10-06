using BlazorWasm.Models.Auth;

namespace BlazorWasm.Services.Abstractions
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> Login(LoginRequest loginRequest);
        public Task Logout();
    }
}