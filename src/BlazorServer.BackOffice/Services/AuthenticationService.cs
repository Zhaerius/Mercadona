using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;

namespace BlazorServer.BackOffice.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        //////////private readonly IHttpClientFactory _clientFactory;
        private readonly IStorageService _storageService;

        public AuthenticationService(/*IHttpClientFactory clientFactory*/HttpClient httpClient, IStorageService storageService)
        {
            _httpClient = httpClient;
            //_clientFactory = clientFactory;
            _storageService = storageService;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            //var client = _clientFactory.CreateClient("MercaApi

            var requestJson = JsonContent.Create(loginRequest);
            var response = await _httpClient.PostAsync($"auth/", requestJson);

            var loginResponse = new LoginResponse();

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return loginResponse;

            loginResponse.Success = true;
            loginResponse.JwtToken = await response.Content.ReadAsStringAsync();

            await _storageService.SetToken(loginResponse.JwtToken);

            return loginResponse;
        }
    }
}
