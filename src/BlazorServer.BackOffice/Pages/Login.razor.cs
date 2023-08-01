using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorServer.BackOffice.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject] private IAuthenticationService AuthenticationService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [CascadingParameter] Task<AuthenticationState>? AuthenticationState { get; set; } = null!;
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();
        public LoginResponse LoginResponse { get; set; } = new LoginResponse();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var authState = await AuthenticationState;
                if (authState.User.Identity.IsAuthenticated)
                    NavigationManager.NavigateTo("/");

                StateHasChanged();
            }
        }

        protected async Task Login()
        {
            var result = await AuthenticationService.Login(LoginRequest);
            LoginResponse = result;

            if (result.Success)
                NavigationManager.NavigateTo("/");
        }
    }
}
