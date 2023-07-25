using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Models;

namespace BlazorServer.BackOffice.Services
{
    public class LoginService : ILoginService
    {
        private readonly IHttpClientFactory _clientFactory;

        public LoginService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var client = _clientFactory.CreateClient("MercaApi");

            var requestJson = JsonContent.Create(loginRequest);
            var response = await client.PostAsync($"auth/", requestJson);

            var loginResponse = new LoginResponse();

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return loginResponse;

            loginResponse.Success = true;
            loginResponse.JwtToken = await response.Content.ReadAsStringAsync();

            return loginResponse;
        }
    }
}
