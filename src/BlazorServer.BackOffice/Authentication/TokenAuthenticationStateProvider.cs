using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace BlazorServer.BackOffice.Authentication
{
    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationState _anonymous;

        public TokenAuthenticationStateProvider(ProtectedSessionStorage sessionStorage, HttpClient httpClient)
        {
            _sessionStorage = sessionStorage;
            _httpClient = httpClient;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var tokenResult = await _sessionStorage.GetAsync<string>("authToken");
                var token = tokenResult.Value;

                var identity = string.IsNullOrWhiteSpace(token)
                    ? new ClaimsIdentity()
                    : new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType");

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                return _anonymous;
            }

        }

        public void NotifyUserAuthentication(string token)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));

            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(_anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
