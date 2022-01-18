using API.Models.Entity;

namespace API.Repositories.Interface;

public interface IUserManagerRepo
{
    Task<IList<string>> UserRoles(ApplicationUser user);
}