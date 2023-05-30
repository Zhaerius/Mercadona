using Infrastructure;
using Application.Core;
using WebApi.Endpoints;
using WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationCore();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("/article")
    .MapArticleEndpoints();

app.MapGroup("/category")
    .MapCategoryEndpoints();

app.MapGroup("/promotion")
    .MapPromotionEndpoints();



app.UseMiddleware<ExceptionMiddleware>();

app.Run();
