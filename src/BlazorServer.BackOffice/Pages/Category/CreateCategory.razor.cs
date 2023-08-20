using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Category
{
    public class CreateCategoryBase : ComponentBase
    {
        protected MudForm form;
        protected bool success;
        protected CreateCategoriesRequest createCategories = new CreateCategoriesRequest()
        {
            Categories = new List<CreateCategoryRequest>()
            {
                new CreateCategoryRequest()
            }
        };

        [Inject] protected ICategoryService CategoryService { get; set; } = null!;
        [Inject] protected ISnackbar Snackbar { get; set; } = null!;


        protected void AddElementToList()
        {
            createCategories.Categories.Add(new CreateCategoryRequest());
        }

        protected void RemoveLastIndexToList()
        {
            if (createCategories.Categories.Count > 1)
            {
                createCategories.Categories.RemoveAt(createCategories.Categories.Count - 1);
                CheckValidationInputs();
            }
        }

        public async Task OnValidSubmit()
        {
            bool result = await CategoryService.CreateCategories(createCategories);
            DisplayResultSubmit(result);
            StateHasChanged();
        }

        private void DisplayResultSubmit(bool result)
        {          
            if (result)
                Snackbar.Add("Catégories ajouté avec succès", Severity.Success);
            else
                Snackbar.Add("Impossible d'ajouter la liste de catégorie", Severity.Error);
        }

        private void CheckValidationInputs()
        {
            var ValidationStatus = createCategories.Categories.Any(c => string.IsNullOrWhiteSpace(c.Name));

            if (ValidationStatus)
                success = false;
            else
                success = true;
        }
    }
}
