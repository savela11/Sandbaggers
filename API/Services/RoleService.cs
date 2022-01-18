using API.Models.Entity;
using API.Models.ViewModel;
using API.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class RoleService : IRoleService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AppDbContext _dbContext;

    public RoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _dbContext = dbContext;
    }

    public async Task<IList<string>> UserRoles(ApplicationUser applicationUser)
    {
        return await _userManager.GetRolesAsync(applicationUser);
    }

    public async Task<IEnumerable<IdentityRole>> List()
    {
        var roles = await _roleManager.Roles.ToListAsync();

        return roles;
    }

    public async Task<IEnumerable<RoleWithUserVm>> ListWithUsers()
    {
        // var roles = await _roleManager.Roles.ToListAsync();
        var users = await _dbContext.Users.ToListAsync();
        var roles = await _dbContext.Roles.ToListAsync();

        var listOfRolesWithUserVm = new List<RoleWithUserVm>();

        foreach (var role in roles)
        {
            var roleWithUserVm = new RoleWithUserVm
            {
                RoleName = role.Name,
                Users = new List<UserVmForRole>()
            };

            foreach (var user in users)
            {
                var isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                if (!isInRole) continue;

                roleWithUserVm.Users.Add(new UserVmForRole(user.Id, user.UserName, user.FullName));
            }

            listOfRolesWithUserVm.Add(roleWithUserVm);
        }


        return listOfRolesWithUserVm;
    }
};