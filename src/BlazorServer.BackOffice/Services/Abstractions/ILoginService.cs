using BlazorServer.BackOffice.Models;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface ILoginService
    {
        public Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}