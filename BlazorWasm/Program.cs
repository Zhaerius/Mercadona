using BlazorWasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.InjectDependencies();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7063") });

await builder.Build().RunAsync();
