using System.Text.Json;

namespace BlazorWasm.Services.Abstractions
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
