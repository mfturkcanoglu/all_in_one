using Microsoft.OpenApi.Models;

namespace API.Util;

public static class SwaggerUtil
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddSwaggerGenNewtonsoftSupport();

        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "All in one API",
                    Version = "v1",
                    Description = "API to perform All in one operations",
                }
            );
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Enter a valid token.",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
            });
            option.SupportNonNullableReferenceTypes();
        });

        return services;
    }
}
