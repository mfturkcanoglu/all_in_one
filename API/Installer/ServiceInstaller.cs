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
                }
            );
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}
