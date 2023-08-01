using BlazorWasm.BackOffice.Models;

namespace BlazorWasm.BackOffice.Services.Abstractions
{
    public interface IAuthenticationService
    {
        public Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}