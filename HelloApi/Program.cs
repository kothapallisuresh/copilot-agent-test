var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/hello", () => "Hello from Copilot!");

app.MapGet("/time", () => DateTime.UtcNow.ToString("o"));

app.Run();

// Make the implicit Program class accessible to tests
public partial class Program { }
