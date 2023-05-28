using API.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Installer;

public class ApiInstaller : IInstaller
{

    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .AddNewtonsoftJson();
        services.AddLogging();
        services.AddSingleton<ILogger, Logger<Program>>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerServices();
        services.AddDistributedMemoryCache();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configuration["TokenOption:Audience"],
                ValidIssuer = configuration["TokenOption:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOption:SecurityKey"]))
            };
        });
    }
}
