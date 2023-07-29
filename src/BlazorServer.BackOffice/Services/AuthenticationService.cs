using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorServer.BackOffice.Authentication;

namespace BlazorServer.BackOffice.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly IStorageService _storageService;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient httpClient, IStorageService storageService, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _storageService = storageService;
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


            await _storageService.SetToken(loginResponse.JwtToken);
            ((TokenAuthenticationStateProvider)_authStateProvider).NotifyUserAuthentication(loginRequest.Username);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponse.JwtToken);

            return loginResponse;
        }
    }
}
