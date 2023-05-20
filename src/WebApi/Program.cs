using Infrastructure;
using Application.Core;
using WebApi.Endpoints;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationCore();

var app = builder.Build();

app.MapGroup("/article")
    .MapArticleEndpoints();


app.UseMiddleware<ExceptionMiddleware>();

app.Run();
