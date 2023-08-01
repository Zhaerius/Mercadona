﻿using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorServer.BackOffice.Authentication;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace BlazorServer.BackOffice.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient httpClient, ProtectedSessionStorage sessionStorage, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _sessionStorage = sessionStorage;
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

            await _sessionStorage.SetAsync("authToken", loginResponse.JwtToken);

            ((TokenAuthenticationStateProvider)_authStateProvider).NotifyUserAuthentication(loginRequest.Username);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResponse.JwtToken);

            return loginResponse;
        }
    }
}
