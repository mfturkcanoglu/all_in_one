﻿namespace API.Installer;

public interface IInstaller
{
    void InstallService(IServiceCollection services, IConfiguration configuration);
}
