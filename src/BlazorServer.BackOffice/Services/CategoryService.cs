using BlazorServer.BackOffice.Models;
using BlazorServer.BackOffice.Services.Abstractions;
using Bogus.DataSets;
using System.Text.Json;

namespace BlazorServer.BackOffice.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var response = await _httpClient.GetAsync("category/");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return Enumerable.Empty<CategoryModel>();

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<CategoryModel>>(jsonData, jsonOptions)!;
        }

    }
}
