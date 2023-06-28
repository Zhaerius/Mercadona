using Infrastructure;
using Application.Core;
using WebApi.Endpoints;
using WebApi.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("RequireSuperAdmin", policy => policy.RequireRole("superadmin"));
    opts.AddPolicy("RequireUserMercadona", policy => policy.RequireRole("UserMercadona"));
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapGroup("/article")
    .MapArticleEndpoints();

app.MapGroup("/category")
    .MapCategoryEndpoints();

app.MapGroup("/promotion")
    .MapPromotionEndpoints();

app.MapGroup("/auth")
    .MapAuthEndpoints();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
