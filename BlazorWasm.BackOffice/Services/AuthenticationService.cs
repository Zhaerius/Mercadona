using BlazorWasm.BackOffice.Services.Abstractions;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWasm.BackOffice.Models;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using BlazorWasm.BackOffice.Authentication;

namespace BlazorWasm.BackOffice.Services
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

            await _localStorage.SetItemAsync("authToken", loginResponse.JwtToken);

            ((TokenAuthenticationStateProvider)_authStateProvider).NotifyUserAuthentication(loginRequest.Username);
            await _authStateProvider.GetAuthenticationStateAsync();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponse.JwtToken);

            return loginResponse;
        }
    }
}
