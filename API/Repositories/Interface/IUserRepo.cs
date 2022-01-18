using API.Models.Entity;

namespace API.Repositories.Interface;

public interface IUserRepo
{

    Task<ApplicationUser?> ApplicationUserById(string id, bool includeProfile = false, bool includeSettings = false);
    Task<ApplicationUser?> ApplicationUserByUsername(string username, bool includeProfile = false, bool includeSettings = false);
}