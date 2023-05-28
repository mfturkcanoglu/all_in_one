using ApplicationCore.Dto.Request;
using ApplicationCore.Dto.Response;
using ApplicationCore.Service.Abstract;
using AutoMapper;
using Infrastructure.Model;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApplicationCore.Service.Impl;

public class UserService : IUserService
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly RoleManager<UserRole> roleManager;
    private readonly IMapper mapper;
    private readonly ITokenService tokenService;

    public UserService(UserManager<User> userManager,
        SignInManager<User> signInManager,
        RoleManager<UserRole> roleManager,
        IMapper mapper,
        ITokenService tokenService)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
        this.mapper = mapper;
        this.tokenService = tokenService;
    }

    public async Task<AuthResponseDto> LoginUser(LoginRequestDto loginRequestDto)
    {
        var user = await userManager.FindByEmailAsync(loginRequestDto.Email);
        if (user != null && await userManager.CheckPasswordAsync(user, loginRequestDto.Password))
        {
            var token = await GetTokenForUser(user);

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
        throw new Exception($"User does not exist with email {loginRequestDto.Email}");
    }

    private async Task<JwtSecurityToken> GetTokenForUser(User user)
    {
        return tokenService.GetToken(await GetClaims(user));
    }

    private async Task<List<Claim>> GetClaims(User user)
    {
        var userRoles = await userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        return authClaims;
    }

    public async Task<AuthResponseDto> Register(UserSignUpRequestDto signUpRequestDto)
    {
        var userExists = await userManager.FindByEmailAsync(signUpRequestDto.Email);
        if (userExists != null)
            throw new Exception($"User already exists with email {signUpRequestDto.Email}");

        User user = new()
        {
            Email = signUpRequestDto.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = signUpRequestDto.CountryId
        };
        var result = await userManager.CreateAsync(user, signUpRequestDto.Password);
        if (!result.Succeeded)
            throw new Exception("User creation failed! Please check user details and try again.");

        var token = await GetTokenForUser(user);
        return new AuthResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = token.ValidTo
        };
    }
}