using API.Models.Entity;
using API.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Interface;

public interface IRoleService
{
    Task<IList<string>> UserRoles(ApplicationUser applicationUser);
    Task<IEnumerable<IdentityRole>> List();

    Task<IEnumerable<RoleWithUserVm>> ListWithUsers();
}