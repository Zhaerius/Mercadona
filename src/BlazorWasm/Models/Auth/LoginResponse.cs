namespace BlazorWasm.Models.Auth
{
    public class LoginResponse
    {
        public bool Success { get; set; } = false;
        public string? JwtToken { get; set; }
    }
}
