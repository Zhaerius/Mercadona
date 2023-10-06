using Blazored.LocalStorage;
using BlazorWasm.Authentication;
using BlazorWasm.Components.Upload;
using BlazorWasm.Services;
using BlazorWasm.Services.Abstractions;
using BlazorWasm.Templates;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using System.Text.Json;

namespace BlazorWasm
{
    public static class Dependencies
    {
        public static void InjectDependencies(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddBlazoredLocalStorage();

            builder.AddMudBlazorUI();
            builder.AddCustomServices();
            builder.AddHttpClient();
            builder.AddAuth();
        }

        private static void AddMudBlazorUI(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddMudServices();

            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 400;
                config.SnackbarConfiguration.ShowTransitionDuration = 400;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Text;
            });

            //builder.Services.AddTransient<MudLocalizer, MyMudLocalizer>();
        }
        private static void AddCustomServices(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped<ArticleService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<PromotionService>();
            builder.Services.AddScoped<UploadState>();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();
        }
        private static void AddHttpClient(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value!) });

            builder.Services.Configure<JsonSerializerOptions>(options =>
            {
                options.PropertyNameCaseInsensitive = true;
            });
        }
        private static void AddAuth(this WebAssemblyHostBuilder builder)
        {
            builder.Services.AddAuthorizationCore(opts =>
            {
                opts.AddPolicy("RequireAdmin", policy => policy.RequireRole("Administrateur"));
                opts.AddPolicy("RequireUserMercadona", policy => policy.RequireRole("Utilisateur"));
            });
        }


    }
}
