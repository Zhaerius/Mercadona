var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/articles", () => "Hello World!");

app.Run();
