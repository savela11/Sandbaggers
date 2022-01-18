using API.Models.Entity;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories;

public class UserManagerRepo : IUserManagerRepo
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserManagerRepo(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IList<string>> UserRoles(ApplicationUser user)
    {
        return await _userManager.GetRolesAsync(user);
    }
}