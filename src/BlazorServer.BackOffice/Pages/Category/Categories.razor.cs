using BlazorServer.BackOffice.Models;
using BlazorServer.BackOffice.Services;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using MudBlazor;
using MudBlazor.Utilities;

namespace BlazorServer.BackOffice.Pages.Category
{
    public class CategoriesBase : ComponentBase
    {
        protected string searchString = "";
        protected int rowPerPage = 10;
        protected bool displayRowNavigation = false; 

        [Inject] private ICategoryService CategoryService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        protected IEnumerable<CategoryModel> Categories { get; set; } = null!;
        [Inject] protected IJSRuntime JSRuntime { get; set; } = null!;


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

            return category.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase);
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
            }
            else
            {
                Snackbar.Add("Modification impossible", Severity.Error);
                Categories = await CategoryService.GetCategories();
            }
        }

        protected async Task FormFieldChanged(FormFieldChangedEventArgs eventArgs)
        {
            var categoryUpdated = eventArgs.NewValue.ToString();
            await ChangeStatusButton(string.IsNullOrWhiteSpace(categoryUpdated));
        }

        private async Task ChangeStatusButton(bool isDisabled)
        {
            await JSRuntime.InvokeVoidAsync("ChangeStatusButton", isDisabled);
        }
    }
}
