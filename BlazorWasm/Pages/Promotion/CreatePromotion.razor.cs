using BlazorWasm.Models.Promotion;
using BlazorWasm.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWasm.Pages.Promotion
{
    public class CreatePromotionBase : ComponentBase
    {
        protected bool _success;
        protected DateRange _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.AddMonths(1).Date);

        [Inject] private PromotionService PromotionService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        protected CreatePromotionRequest CreatePromotion { get; set; } = new();

        protected async Task OnValidSubmit()
        {
            _success = true;
            CreatePromotion.Start = DateOnly.FromDateTime((DateTime)_dateRange.Start!);
            CreatePromotion.End = DateOnly.FromDateTime((DateTime)_dateRange.End!);

            var result = await PromotionService.CreatePromotion(CreatePromotion);

            NavigationManager.NavigateTo("/promotion");
            DisplayResultSubmit(result);
        }

        private void DisplayResultSubmit(bool result)
        {
            if (result)
                Snackbar.Add("Promotion ajouté", Severity.Success);
            else
                Snackbar.Add("Action impossible", Severity.Error);
        }

    }
}
