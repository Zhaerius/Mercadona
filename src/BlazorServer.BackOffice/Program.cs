using BlazorServer.BackOffice.Data;
using Infrastructure;
using Application.Core;
using Infrastructure.Persistence;
using System.Reflection;
using BlazorServer.BackOffice.ApiServices;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;
using BlazorServer.BackOffice.ApiServices.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationCore();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IArticleApiService, ArticleApiService>();

builder.Services.AddHttpClient("MercaApi", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("ApiUrl").Value!);
});

builder.Services.Configure<JsonSerializerOptions>(options => {
    options.PropertyNameCaseInsensitive = true;
});


var app = builder.Build();

//Seed Data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MercaDbContext>();
    MercaDbContectSeed.Seed(dbContext);
}

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
