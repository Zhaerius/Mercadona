using System.Globalization;
using BlazorServer.BackOffice;
using Microsoft.Extensions.FileProviders;

CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture("fr");

var builder = WebApplication.CreateBuilder(args);

builder.InjectDependencies();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider("C:\\Users\\gaeta\\source\\Repos\\Blob\\Mercadona\\"),
    RequestPath = "/blob"
});

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
