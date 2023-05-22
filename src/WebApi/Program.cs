using Infrastructure;
using Application.Core;
using WebApi.Endpoints;
using WebApi.Middlewares;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationCore();

//Eviter les référence circulaire dans la sérialisation
builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGroup("/article")
    .MapArticleEndpoints();


app.UseMiddleware<ExceptionMiddleware>();

app.Run();
