using BlazorServer.BackOffice.Models;
using BlazorServer.BackOffice.Services.Abstractions;
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

        public async Task<bool> DeleteCategory(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"category/{id}");

            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }

        public async Task<bool> UpdateCategory(CategoryModel category)
        {
            var response = await _httpClient.PutAsync($"category/{category.Id}", );

            if (!response.IsSuccessStatusCode)
                return false;

            return true;
        }

    }
}
