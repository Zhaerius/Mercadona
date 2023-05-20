using System.Text.Json;

namespace WebApi.Models
{
    public class Error
    {
        public string? StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Detail { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
