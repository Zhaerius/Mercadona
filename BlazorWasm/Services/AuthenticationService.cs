using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWasm.Models.Auth;
using BlazorWasm.Authentication;
using BlazorWasm.Services.Abstractions;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BlazorWasm.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authStateProvider = authStateProvider;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var requestJson = JsonContent.Create(loginRequest);
            var response = await _httpClient.PostAsync($"auth/", requestJson);
            var loginResponse = new LoginResponse();

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return loginResponse;

            loginResponse.Success = true;
            loginResponse.JwtToken = await response.Content.ReadAsStringAsync();
            loginResponse.JwtToken = loginResponse.JwtToken.Trim('"');

            await _localStorage.SetItemAsync("authToken", loginResponse.JwtToken);

            ((TokenAuthenticationStateProvider)_authStateProvider).NotifyUserAuthentication(loginResponse.JwtToken);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponse.JwtToken);

            return loginResponse;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((TokenAuthenticationStateProvider)_authStateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
