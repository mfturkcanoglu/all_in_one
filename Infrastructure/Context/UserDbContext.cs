using Infrastructure.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class UserDbContext : IdentityDbContext<User, UserRole, string>
{
    public UserDbContext(DbContextOptions options) : base(options)
    {
    }
}