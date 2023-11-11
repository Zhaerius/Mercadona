using BlazorWasm.Models.Promotion;
using BlazorWasm.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorWasm.Components.Promotion;

public class CreatePromotionTwoBase : ComponentBase
{
    protected DateRange _dateRange = new DateRange(DateTime.Now.Date, DateTime.Now.AddMonths(1).Date);

    [Inject] private PromotionService PromotionService { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    protected CreatePromotionRequest CreatePromotion { get; set; } = new();

    [Parameter] public RenderFragment? Title { get; set; }
    [Parameter] public RenderFragment? ButtonValidateOverlay { get; set; }
    [Parameter] public RenderFragment? ButtonValidate { get; set; }
    [Parameter] public EventCallback<Guid> OnPromotionCreated { get; set; }

    protected async Task OnValidSubmit()
    {
        CreatePromotion.Start = DateOnly.FromDateTime((DateTime)_dateRange.Start!);
        CreatePromotion.End = DateOnly.FromDateTime((DateTime)_dateRange.End!);

        Guid? id = await PromotionService.CreatePromotion(CreatePromotion);

        bool valueToDisplay = id != null ? true : false;

        if (valueToDisplay && ButtonValidate is not null)
            NavigationManager.NavigateTo("/promotion");

        if (id is not null && ButtonValidateOverlay is not null)
            await OnPromotionCreated.InvokeAsync((Guid)id);

        DisplayResultSubmit(valueToDisplay);
    }

    private void DisplayResultSubmit(bool result)
    {
        if (result)
            Snackbar.Add("Promotion ajouté", Severity.Success);
        else
            Snackbar.Add("Action impossible", Severity.Error);
    }
}