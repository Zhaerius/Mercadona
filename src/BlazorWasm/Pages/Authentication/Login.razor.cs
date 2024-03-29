﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWasm.Models.Auth;
using BlazorWasm.Services.Abstractions;

namespace BlazorWasm.Pages.Authentication
{
    public class LoginBase : ComponentBase
    {
        protected bool _error;
        protected bool _loader;
        [Inject] private IAuthenticationService AuthenticationService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; } = null!;
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();
        public LoginResponse LoginResponse { get; set; } = new LoginResponse();

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationState;
            if (authState.User.Identity!.IsAuthenticated)
                NavigationManager.NavigateTo("/article");
        }

        protected async Task Login()
        {
            _loader = true;
            StateHasChanged();

            var result = await AuthenticationService.Login(LoginRequest);
            LoginResponse = result;

            _loader = false;

            if (result.Success)
                NavigationManager.NavigateTo("/article");
            else
                _error = true;
        }
    }
}
