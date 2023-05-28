using ApplicationCore.OptionsSetup;

namespace API.Installer;

public class OptionInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureOptions<TokenOptionsSetup>();
    }
}
