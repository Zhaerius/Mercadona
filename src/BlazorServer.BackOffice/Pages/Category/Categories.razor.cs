using BlazorServer.BackOffice.Models;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Category
{
    public class CategoriesBase : ComponentBase
    {
        protected string searchString = "";

        [Inject] private ICategoryService CategoryService { get; set; } = null!;
        protected IEnumerable<CategoryModel> Categories { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetCategories();
        }

        protected bool FilterFunc(CategoryModel category)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (category.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}
