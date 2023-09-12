using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;


namespace BlazorServer.BackOffice.Pages.Category
{
    public class CategoriesBase : ComponentBase
    {
        protected string _searchString = "";
        protected int _rowPerPage = 10;
        protected bool _displayRowNavigation = false;
        protected CategoryModel? _elementBeforeEdit;

        [Inject] private CategoryService CategoryService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] protected IJSRuntime JSRuntime { get; set; } = null!;
        protected IEnumerable<CategoryModel> Categories { get; set; } = new List<CategoryModel>();
        protected string LinkAddCategory { get; set; } = "/category/create";


        protected override async Task OnInitializedAsync()
        {
            Categories = await CategoryService.GetCategories();

            if (Categories.Count() > _rowPerPage)
                _displayRowNavigation = true;
        }

        protected bool FilterFunc(CategoryModel category)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            return category.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase);
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

        protected void BackupItem(object element)
        {
            _elementBeforeEdit = new CategoryModel()
            {
                Name = ((CategoryModel)element).Name,
            };
        }

        protected void ResetItemToOriginalValues(object element)
        {
            ((CategoryModel)element).Name = _elementBeforeEdit!.Name;
        }

        protected async void ItemHasBeenCommittedAsync(object element)
        {
            var categoryUpdated = new UpdateCategoryRequest()
            {
                Id = ((CategoryModel)element).Id,
                Name = ((CategoryModel)element).Name
            };

            var result = await CategoryService.UpdateCategory(categoryUpdated);

            if (result)
            {
                Snackbar.Add("Catégorie correctement modifié", Severity.Success);
            }
            else
            {
                Snackbar.Add("Modification impossible", Severity.Error);
                StateHasChanged();
            }
        }
    }
}
