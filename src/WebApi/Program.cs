using WebApi.Endpoints;
using WebApi.Middlewares;
using Infrastructure.Persistence;
using WebApi;
using Application.Core.Common.Extensions;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.InjectDependencies();
builder.Services.AddApplicationCore();

var app = builder.Build();

//Seed Data
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    await MercaDbContextSeed.SeedAsync(serviceProvider);
}

app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/article")
    .MapArticleEndpoints()
    .WithTags("ArticleManagement");

app.MapGroup("/category")
    .MapCategoryEndpoints()
    .WithTags("CategoryManagement");

app.MapGroup("/promotion")
    .MapPromotionEndpoints()
    .WithTags("PromotionManagement");

app.MapGroup("/auth")
    .MapAuthEndpoints()
    .WithTags("Authentication");

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
