using API.Models.Entity;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public class UserRepo : IUserRepo
{
    private readonly AppDbContext _dbContext;

    public UserRepo(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<ApplicationUser?> ApplicationUserById(string id, bool includeProfile, bool includeSettings)
    {
        if (includeProfile && includeSettings)
        {
            return await _dbContext.Users.Include(u => u.UserProfile).Include(u => u.UserSettings).FirstOrDefaultAsync(u => u.Id == id);
        }
        else if (!includeProfile && includeSettings)
        {
            return await _dbContext.Users.Include(u => u.UserSettings).FirstOrDefaultAsync(u => u.Id == id);
        }
        else if (includeProfile && !includeSettings)
        {
            return await _dbContext.Users.Include(u => u.UserProfile).FirstOrDefaultAsync(u => u.Id == id);
        }
        else
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }

    public async Task<ApplicationUser?> ApplicationUserByUsername(string username, bool includeProfile, bool includeSettings)
    {
        if (includeProfile && includeSettings)
        {
            return await _dbContext.Users.Include(u => u.UserProfile).Include(u => u.UserSettings).FirstOrDefaultAsync(u => u.NormalizedUserName == username.ToUpper());
        }
        else if (!includeProfile && includeSettings)
        {
            return await _dbContext.Users.Include(u => u.UserSettings).FirstOrDefaultAsync(u => u.NormalizedUserName == username.ToUpper());
        }
        else if (includeProfile && !includeSettings)
        {
            return await _dbContext.Users.Include(u => u.UserProfile).FirstOrDefaultAsync(u => u.NormalizedUserName == username.ToUpper());
        }
        else
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == username.ToUpper());
        }
    }
}