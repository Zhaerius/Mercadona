using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorServer.BackOffice.Models.Auth;

namespace BlazorServer.BackOffice.Pages.Authentication
{
    public class LoginBase : ComponentBase
    {
        protected bool error;
        [Inject] private IAuthenticationService AuthenticationService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; } = null!;
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();
        public LoginResponse LoginResponse { get; set; } = new LoginResponse();

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationState;
            if (authState.User.Identity!.IsAuthenticated)
                NavigationManager.NavigateTo("/");
        }

        protected async Task Login()
        {
            var result = await AuthenticationService.Login(LoginRequest);
            LoginResponse = result;

            if (result.Success)
                NavigationManager.NavigateTo("/");
            else
                error = true;
        }
    }
}
