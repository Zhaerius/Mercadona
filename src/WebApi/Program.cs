using WebApi.Endpoints;
using WebApi.Middlewares;
using Infrastructure.Persistence;
using WebApi;
using Application.Core.Common.Extensions;

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

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/article")
    .MapArticleEndpoints()
    .RequireAuthorization("RequireUserMercadona");

app.MapGroup("/category")
    .MapCategoryEndpoints()
    .RequireAuthorization("RequireUserMercadona");

app.MapGroup("/promotion")
    .MapPromotionEndpoints()
    .RequireAuthorization("RequireUserMercadona");

app.MapGroup("/auth")
    .MapAuthEndpoints();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
