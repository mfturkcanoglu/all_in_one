using ApplicationCore.Profiles;
using ApplicationCore.Service.Abstract;
using ApplicationCore.Service.Impl;
using AutoMapper;

namespace API.Installer;

public class ServiceInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfiles(
                new List<Profile>
                {
                    new UserProfile(),
                }
            );
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserService, UserService>();
    }
}
