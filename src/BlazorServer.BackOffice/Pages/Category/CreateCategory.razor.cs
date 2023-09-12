using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Category
{
    public class CreateCategoryBase : ComponentBase
    {
        protected MudForm _form = null!;
        protected bool _success;

        [Inject] private CategoryService CategoryService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        protected CreateCategoriesRequest CreateCategories { get; set; } = new CreateCategoriesRequest()
        {
            Categories = new List<CreateCategoryRequest>()
            {
                new CreateCategoryRequest()
            }
        };


        protected void AddElementToList()
        {
            CreateCategories.Categories!.Add(new CreateCategoryRequest());
        }

        protected void RemoveLastIndexToList()
        {
            var nbCategories = CreateCategories.Categories!.Count;

            if (nbCategories > 1)
            {
                CreateCategories.Categories.RemoveAt(nbCategories - 1);
                CheckValidationInputs();
            }
        }

        public async Task OnValidSubmit()
        {
            bool result = await CategoryService.CreateCategories(CreateCategories);
            DisplayResultSubmit(result);
            NavigationManager.NavigateTo("/category");
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
            var ValidationStatus = CreateCategories.Categories!.Any(c => string.IsNullOrWhiteSpace(c.Name));

            if (ValidationStatus)
                _success = false;
            else
                _success = true;
        }
    }
}
