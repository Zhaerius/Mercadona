using BlazorServer.BackOffice.Models.Promotion;
using BlazorServer.BackOffice.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Promotion
{
    public class CreatePromotionBase : ComponentBase
    {
        protected bool _success;
        protected DateRange _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.AddMonths(1).Date);

        [Inject] PromotionService PromotionService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
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
                Snackbar.Add("Promotion ajouté avec succès", Severity.Success);
            else
                Snackbar.Add("Impossible d'ajouter la promotion", Severity.Error);
        }

    }
}
