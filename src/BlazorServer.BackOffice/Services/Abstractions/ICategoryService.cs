using BlazorServer.BackOffice.Models.Category;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<bool> DeleteCategory(Guid id);
        Task<bool> UpdateCategory(UpdateCategoryRequest updateCategoryRequest);
        Task<bool> CreateCategories(CreateCategoriesRequest createCategoriesRequest);
    }
}