using ApplicationCore.Service.Abstract;
using Infrastructure.Model;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Service.Impl;

public class UserService : IUserService
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly RoleManager<UserRole> roleManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<UserRole> roleManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.roleManager = roleManager;
    }
}