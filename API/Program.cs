using API.Installer;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();

app.UseMiddlewares();

app.Run();