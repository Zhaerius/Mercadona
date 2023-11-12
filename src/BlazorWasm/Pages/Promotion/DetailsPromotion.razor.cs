using BlazorWasm.Models.Promotion;
using BlazorWasm.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWasm.Pages.Promotion
{
    public class DetailsPromotionBase: ComponentBase
    {
        [Parameter] public Guid Id { get; set; }
        [Inject] PromotionService PromotionService { get; set; } = null!;

        protected PromotionModel? Promotion { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Promotion = await PromotionService.GetPromotionWithArticlesById(Id);
        }

        protected Color GetColorEnum(bool status)
        {
            if (status)
                return Color.Success;
            else
                return Color.Dark;
        }


    }
}
