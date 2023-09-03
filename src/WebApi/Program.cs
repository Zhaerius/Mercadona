using Infrastructure;
using Application.Core;
using WebApi.Endpoints;
using WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationCore();

builder.Services
    .AddAuthentication(otps =>
    {
        otps.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        otps.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        otps.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
    {
        opts.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true)
            .AllowAnyHeader());
});

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
    .RequireAuthorization("RequireUserMercadona"); ;

app.MapGroup("/promotion")
    .MapPromotionEndpoints()
    .RequireAuthorization("RequireUserMercadona"); ;

app.MapGroup("/auth")
    .MapAuthEndpoints();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
