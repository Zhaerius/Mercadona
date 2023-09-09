using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
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

        public async Task<Category> GetCategoryById(Guid id)
        {
            var response = await _httpClient.GetAsync($"category/{id}");

            if (!response.IsSuccessStatusCode)
                return null!;

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Category>(jsonData, jsonOptions)!;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var response = await _httpClient.GetAsync("category/");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return Enumerable.Empty<Category>();

            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var jsonData = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Category>>(jsonData, jsonOptions)!;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"category/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var jsonContent = JsonContent.Create(updateCategoryRequest);
            var response = await _httpClient.PutAsync($"category/", jsonContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateCategories(CreateCategoriesRequest createCategoriesRequest)
        {
            var jsonContent = JsonContent.Create(createCategoriesRequest);
            var response = await _httpClient.PostAsync($"category/multimode", jsonContent);

            return response.IsSuccessStatusCode;
        }

    }
}
