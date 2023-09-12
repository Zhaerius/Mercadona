using System.Text.Json;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public abstract class HttpService
    {
        protected async Task<T> DeserializeFromHttpResponse<T>(HttpResponseMessage result)
        {
            return JsonSerializer.Deserialize<T>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }
    }
}
