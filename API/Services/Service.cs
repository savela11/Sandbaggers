using API.Config;
using API.Models.Entity;
using API.Repositories.Interface;
using API.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Services;

public class Service : IService
{
    public Service(AppDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager,
        IOptions<AppSettingsExtension> appSettingsExtension,
        IRepository repo)
    {
        Auth = new AuthService(dbContext, userManager, signInManager, repo, appSettingsExtension);
        User = new UserService(dbContext);
        Role = new RoleService(userManager, roleManager, dbContext);
    }


    public IAuthService Auth { get; private set; }
    public IUserService User { get; private set; }
    public IRoleService Role { get; private set; }
}