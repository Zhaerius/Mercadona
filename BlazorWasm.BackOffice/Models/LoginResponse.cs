namespace BlazorWasm.BackOffice.Models
{
    public class LoginResponse
    {
        public bool Success { get; set; } = false;
        public string? JwtToken { get; set; }
    }
}
