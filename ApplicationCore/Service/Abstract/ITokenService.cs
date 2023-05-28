using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApplicationCore.Service.Abstract;

public interface ITokenService
{
    JwtSecurityToken GetToken(List<Claim> authClaims);
}