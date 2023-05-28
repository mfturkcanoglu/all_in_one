using Infrastructure.Option;
using Microsoft.Extensions.Configuration;

namespace ApplicationCore.OptionsSetup;

public class TokenOptionsSetup : OptionsSetup<TokenOption>
{
    private const string Section = "TokenOption";
    public TokenOptionsSetup(IConfiguration configuration) : base(configuration, Section)
    {
    }
}