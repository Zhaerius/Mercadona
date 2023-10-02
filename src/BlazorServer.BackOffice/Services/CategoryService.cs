using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services.Abstractions;

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
            var response = await _httpClient.GetAsync($"category/{id}");

            if (!response.IsSuccessStatusCode)
                return null!;

            return await DeserializeFromHttpResponse<CategoryModel>(response);
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            var response = await _httpClient.GetAsync("category/");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return Enumerable.Empty<CategoryModel>();

            return await DeserializeFromHttpResponse<IEnumerable<CategoryModel>>(response);
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
