using BlazorServer.BackOffice.Models;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Category
{
    public class CategoriesBase : ComponentBase
    {
        [Inject] ICategoryService CategoryService { get; set; } = null!;
        public IEnumerable<CategoryModel> Categories { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetCategories();
        }
    }
}
