using API.Middleware;

namespace API.Installer;

public static class Installer
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        var services = typeof(Program).Assembly.ExportedTypes
        .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
        .Select(Activator.CreateInstance)
        .Cast<IInstaller>()
        .ToList();

        foreach (var service in services)
        {
            service.InstallService(builder.Services, builder.Configuration);
        }
    }

    public static void UseMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
}
