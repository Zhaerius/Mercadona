using BlazorServer.BackOffice.Models.Promotion;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BackOffice.Pages.Promotion
{
    public class CreatePromotionBase : ComponentBase
    {
        protected bool _success;
        protected DateRange _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.AddMonths(1).Date);

        protected CreatePromotionRequest CreatePromotion { get; set; } = new();

        protected async Task OnValidSubmit()
        {
            _success = true;

            CreatePromotion.Start = DateOnly.FromDateTime((DateTime)_dateRange.Start!);
            CreatePromotion.End = DateOnly.FromDateTime((DateTime)_dateRange.End!);
        }

    }
}
