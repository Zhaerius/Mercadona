using BlazorServer.BackOffice.Authentication;
using BlazorServer.BackOffice.Components.Upload;
using BlazorServer.BackOffice.Services;
using BlazorServer.BackOffice.Services.Abstractions;
using BlazorServer.BackOffice.Templates;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using System.Text.Json;

namespace BlazorServer.BackOffice
{
    public static class Dependencies
    {
        public static void InjectDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.AddMudBlazorUI();
            builder.AddCustomServices();
            builder.AddHttpClient();
            builder.AddAuth();
        }

        private static void AddMudBlazorUI(this WebApplicationBuilder builder)
        {
            builder.Services.AddMudServices();

            builder.Services.AddMudServices(config =>
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

            builder.Services.AddTransient<MudLocalizer, MyMudLocalizer>();
        }
        private static void AddCustomServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ArticleService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<PromotionService>();
            builder.Services.AddScoped<UploadState>();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
        }
        private static void AddHttpClient(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value!) });

            builder.Services.Configure<JsonSerializerOptions>(options => {
                options.PropertyNameCaseInsensitive = true;
            });
        }
        private static void AddAuth(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorizationCore(opts =>
            {
                opts.AddPolicy("RequireAdmin", policy => policy.RequireRole("Administrateur"));
                opts.AddPolicy("RequireUserMercadona", policy => policy.RequireRole("Utilisateur"));
            });
        }


    }
}
