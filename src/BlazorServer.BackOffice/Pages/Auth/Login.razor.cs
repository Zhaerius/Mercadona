using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Auth
{
    public class LoginBase : ComponentBase
    {
        [Inject] private IAuthenticationService AuthenticationService { get; set; } = null!;
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();
        public LoginResponse LoginResponse { get; set; } = new LoginResponse();

        protected async Task Login()
        {
            var result = await AuthenticationService.Login(LoginRequest);
            LoginResponse = result;
        }
    }
}
