using BlazorWasm.Models.Promotion;
using BlazorWasm.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWasm.Pages.Promotion
{
    public class SearchPromotionBase : ComponentBase
    {
        protected bool _isActive = true;
        protected string _linkAdd = "/promotion/create";
        protected int _rowPerPage = 15;
        protected string _searchString = "";
        protected bool _loading;

        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private PromotionService PromotionService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        public IEnumerable<PromotionModel>? Promotions { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Promotions = await PromotionService.GetPromotionByStatus(_isActive);
        }

        protected bool FilterFunc(PromotionModel promotion)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            return promotion.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase);
        }

        protected async Task RefreshPromotions()
        {
            _isActive = !_isActive;
            _loading = true;
            Promotions = await PromotionService.GetPromotionByStatus(_isActive);
            _loading = false;
            _searchString = "";
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
