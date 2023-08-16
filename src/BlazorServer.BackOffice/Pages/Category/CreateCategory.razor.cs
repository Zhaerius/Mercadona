using BlazorServer.BackOffice.Models;
using BlazorServer.BackOffice.Services;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BackOffice.Pages.Category
{
    public class CreateCategoryBase : ComponentBase
    {
        [Inject] protected ICategoryService CategoryService { get; set; } = null!;
        protected List<CreateCategoryRequest> categories = new()
        {
            new CreateCategoryRequest()
        };

        protected void AddElementToList()
        {
            categories.Add(new CreateCategoryRequest());
        }

        protected void RemoveLastIndexToList()
        {
            if (categories.Count > 1)
                categories.RemoveAt(categories.Count - 1);
        }

        public void OnValidSubmit()
        {

        }
    }
}
