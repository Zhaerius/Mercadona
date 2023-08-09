using BlazorServer.BackOffice.Models;

namespace BlazorServer.BackOffice.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<bool> DeleteCategory(Guid id);
    }
}