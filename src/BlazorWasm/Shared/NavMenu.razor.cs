﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace BlazorWasm.Shared
{
    public class NavMenuBase : ComponentBase
    {
        private bool collapseNavMenu = true;
        protected char nameLetter;
        protected string? shortName;
        protected string? roles;

        protected string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
        [CascadingParameter] private Task<AuthenticationState> AuthenticationState { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationState!;
            if (authState.User.Identity.IsAuthenticated)
            {
                nameLetter = authState.User.Identity.Name[0];
                shortName = authState.User.Identity.Name.Replace("@mercadona.com", "");
                var rolesFromClaims = authState.User.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();

                if (rolesFromClaims.Count > 1)
                    roles = string.Join("/", rolesFromClaims);
                else
                    roles = rolesFromClaims[0];
            }
        }
    }
}
