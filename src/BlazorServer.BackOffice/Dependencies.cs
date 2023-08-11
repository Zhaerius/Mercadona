using BlazorServer.BackOffice.Templates;
using MudBlazor;
using MudBlazor.Services;

namespace BlazorServer.BackOffice
{
    public static class Dependencies
    {
        public static IServiceCollection AddUIDependencies(this IServiceCollection services)
        {
            services.AddMudServices();

            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Text;
            });

            services.AddTransient<MudLocalizer, MyMudLocalizer>();

            return services;
        }
    }
}
