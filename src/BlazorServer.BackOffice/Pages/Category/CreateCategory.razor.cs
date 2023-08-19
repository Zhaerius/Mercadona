using BlazorServer.BackOffice.Models.Category;
using BlazorServer.BackOffice.Services;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Category
{
    public class CreateCategoryBase : ComponentBase
    {
        [Inject] protected ICategoryService CategoryService { get; set; } = null!;
        [Inject] protected ISnackbar Snackbar { get; set; } = null!;
        protected CreateCategoriesRequest CreateCategories = new CreateCategoriesRequest()
        {
            Categories = new List<CreateCategoryRequest>() 
            { 
                new CreateCategoryRequest() 
            }
        };

        protected void AddElementToList()
        {
            CreateCategories.Categories.Add(new CreateCategoryRequest());
        }

        protected void RemoveLastIndexToList()
        {
            if (CreateCategories.Categories.Count > 1)
                CreateCategories.Categories.RemoveAt(CreateCategories.Categories.Count - 1);
        }

        public async Task OnValidSubmit()
        {
            bool result = await CategoryService.CreateCategories(CreateCategories);
            DisplayResultSubmit(result);
        }

        private void DisplayResultSubmit(bool result)
        {          
            if (result)
                Snackbar.Add("Catégories ajouté avec succès", Severity.Success);
            else
                Snackbar.Add("Impossible d'ajouter la liste de catégorie", Severity.Error);
        }
    }
}
