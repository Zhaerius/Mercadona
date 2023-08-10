using BlazorServer.BackOffice.Models;
using BlazorServer.BackOffice.Services;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Category
{
    public class CategoriesBase : ComponentBase
    {
        protected string searchString = "";
        protected int rowPerPage = 10;
        protected bool displayRowNavigation = false; 

        [Inject] private ICategoryService CategoryService { get; set; } = null!;
        [Inject] ISnackbar Snackbar { get; set; } = null!;
        protected IEnumerable<CategoryModel> Categories { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetCategories();

            if (Categories.Count() > rowPerPage)
                displayRowNavigation = true;
        }

        protected bool FilterFunc(CategoryModel category)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (category.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        protected async Task DeleteCategory(Guid id)
        {
            bool isSucces = await CategoryService.DeleteCategory(id);

            if (isSucces)
            {
                Snackbar.Add("Catégorie correctement supprimé", Severity.Success);
                Categories = Categories.Where(a => a.Id != id).ToList();
            }
            else
            {
                Snackbar.Add("Suppresion impossible, la catégorie ne doit pas contenir d'article", Severity.Error);
            }
        }

        protected async Task CanceledEditingItem(CategoryModel meeting)
        {
            // code needed for canceling changes
        }

        protected async Task CommittedItemChanges(CategoryModel category)
        {
            var categoryUpdated = new UpdateCategoryRequest()
            {
                Id = category.Id,
                Name = category.Name,
            };

            var result = await CategoryService.UpdateCategory(categoryUpdated);

            if (result)
            {
                Snackbar.Add("Catégorie correctement modifié", Severity.Success);
                StateHasChanged();
            }
            else
            {
                Snackbar.Add("Modification impossible", Severity.Error);
                await CanceledEditingItem(category);
            }
        }


    }
}
