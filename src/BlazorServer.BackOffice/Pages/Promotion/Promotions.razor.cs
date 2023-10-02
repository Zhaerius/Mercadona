using BlazorServer.BackOffice.Models.Promotion;
using BlazorServer.BackOffice.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Promotion
{
    public class SearchPromotionBase : ComponentBase
    {
        protected bool isActive = true;
        protected string linkAdd = "/promotion/create";
        protected int rowPerPage = 15;
        protected string searchString = "";

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private PromotionService PromotionService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        public IEnumerable<PromotionModel>? Promotions { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Promotions = await PromotionService.GetPromotionByStatus(isActive);
        }

        protected bool FilterFunc(PromotionModel promotion)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            return promotion.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase);
        }

        protected async Task RefreshPromotions()
        {
            isActive = !isActive;
            Promotions = await PromotionService.GetPromotionByStatus(isActive);
            searchString = "";
        }

        protected async Task DeletePromotion(Guid id)
        {
            bool isSucces = await PromotionService.DeletePromotion(id);

            if (isSucces)
            {
                Snackbar.Add("Promotion supprimé", Severity.Success);
                Promotions = Promotions.Where(a => a.Id != id).ToList();
            }
            else
            {
                Snackbar.Add("Action impossible", Severity.Error);
            }
        }

        protected void RedirectToUpdate(Guid id) => NavigationManager.NavigateTo($"/promotion/update/{id}");
    }
}
