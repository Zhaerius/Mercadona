using BlazorWasm.Models.Promotion;
using BlazorWasm.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWasm.Pages.Promotion
{
    public class UpdatePromotionBase : ComponentBase
    {
        protected bool _success;
        protected DateRange _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.AddMonths(1).Date);

        [Parameter] public Guid Id { get; set; }
        [Inject] private PromotionService PromotionService { get; set; } = null!;
        [Inject] private ISnackbar Snackbar { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;
        protected UpdatePromotionRequest? UpdatePromotion { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var promotionToUpdate = await PromotionService.GetPromotionById(Id);

            if (promotionToUpdate != null)
            {
                UpdatePromotion = new UpdatePromotionRequest();
                UpdatePromotion.Id = promotionToUpdate.Id;
                UpdatePromotion.Name = promotionToUpdate.Name;
                UpdatePromotion.Discount = promotionToUpdate.Discount;
                _dateRange = new DateRange(promotionToUpdate.Start.ToDateTime(TimeOnly.Parse("00:00 PM")), promotionToUpdate.End.ToDateTime(TimeOnly.Parse("00:00 PM")));
            }
        }

        protected async Task OnValidSubmit()
        {
            _success = true;
            UpdatePromotion.Start = DateOnly.FromDateTime((DateTime)_dateRange.Start!);
            UpdatePromotion.End = DateOnly.FromDateTime((DateTime)_dateRange.End!);

            var result = await PromotionService.UpdateArticle(UpdatePromotion);

            NavigationManager.NavigateTo("/promotion");
            DisplayResultSubmit(result);
        }

        private void DisplayResultSubmit(bool result)
        {
            if (result)
                Snackbar.Add("Promotion modifié", Severity.Success);
            else
                Snackbar.Add("Action impossible", Severity.Error);
        }

    }
}
