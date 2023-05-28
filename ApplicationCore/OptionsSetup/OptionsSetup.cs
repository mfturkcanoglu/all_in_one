using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ApplicationCore.OptionsSetup;

public class OptionsSetup<T> : IConfigureOptions<T>
    where T : class
{
    private readonly IConfiguration _configuration;
    private readonly string _sectionName;

    public OptionsSetup(IConfiguration configuration, string sectionName)
    {
        _configuration = configuration;
        _sectionName = sectionName;
    }

    public void Configure(T options)
    {
        _configuration.GetSection(_sectionName).Bind(options);
    }
}