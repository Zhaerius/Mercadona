using Infrastructure;
using Application.Core;
using System.Reflection;
using BlazorServer.BackOffice.Services;
using System.Text.Json;
using BlazorServer.BackOffice.Services.Abstractions;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorServer.BackOffice.Authentication;
using MudBlazor.Services;
using BlazorServer.BackOffice;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorizationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationCore();
builder.Services.AddUIDependencies();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>();

CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value!) });

builder.Services.Configure<JsonSerializerOptions>(options => {
    options.PropertyNameCaseInsensitive = true;
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
