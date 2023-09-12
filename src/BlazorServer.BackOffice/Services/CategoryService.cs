using BlazorServer.BackOffice.Models.Article;
using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Pages.Article;
using BlazorServer.BackOffice.Services.Abstractions;
using System.Text.Json;

namespace BlazorServer.BackOffice.Services
{
    public class CategoryService : HttpService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateCategories(CreateCategoriesRequest createCategoriesRequest)
        {
            var response = await _httpClient.PostAsJsonAsync($"category/multimode", createCategoriesRequest);
            return response.IsSuccessStatusCode;
        }

        public async Task<CategoryModel> GetCategoryById(Guid id)
        {
            var category = await _httpClient.GetFromJsonAsync<CategoryModel>($"category/{id}");
            return category;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var categories = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryModel>>("category/");
            return categories;
        }

        public async Task<bool> UpdateCategory(UpdateCategoryRequest updateCategoryRequest)
        {
            var response = await _httpClient.PutAsJsonAsync($"category/", updateCategoryRequest);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"category/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
