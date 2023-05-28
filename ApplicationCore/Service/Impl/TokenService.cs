using ApplicationCore.Service.Abstract;
using Infrastructure.Option;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApplicationCore.Service.Impl;

public class TokenService : ITokenService
{
    private readonly TokenOption tokenOption;

    public TokenService(IOptions<TokenOption> tokenOption)
    {
        this.tokenOption = tokenOption.Value;
    }

    public JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecurityKey));

        var token = new JwtSecurityToken(
            issuer: tokenOption.Issuer,
            audience: tokenOption.Audience,
            expires: DateTime.Now.AddHours(tokenOption.TokenExpiration),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}