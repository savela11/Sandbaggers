using API.Models.Entity;
using API.Models.ViewModel;
using API.Services.Interface;
using API.Utility;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;

    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse<ApplicationUser>> ApplicationUserSR(string id)
    {
        var serviceResponse = new ServiceResponse<ApplicationUser>();

        try
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }


            serviceResponse.Data = user;
        }
        catch (Exception e)
        {
            serviceResponse.Message = e.Message;
            serviceResponse.IsSuccess = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<IEnumerable<ApplicationUser>>> ApplicationUsersSR()
    {
        var serviceResponse = new ServiceResponse<IEnumerable<ApplicationUser>>();

        try
        {
            var applicationUsers = await _dbContext.Users.ToListAsync();

            serviceResponse.Data = applicationUsers;
        }
        catch (Exception e)
        {
            serviceResponse.Message = e.Message;
            serviceResponse.IsSuccess = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<UserVm>> UserVmSR(string id)
    {
        var serviceResponse = new ServiceResponse<UserVm>();

        try
        {
            var user = await _dbContext.Users.Include(u => u.UserProfile).Include(u => u.UserSettings).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "User not found";
                return serviceResponse;
            }


            var userVm = new UserVm
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FullName = user.FullName,
                Profile = ProfileVm(user.UserProfile),
                // Settings = _userSettingsService.UserProfileVm(user.UserProfile)
                Settings = new UserSettingsVm()
            };


            serviceResponse.Data = userVm;
        }
        catch (Exception e)
        {
            serviceResponse.Message = e.Message;
            serviceResponse.IsSuccess = false;
        }

        return serviceResponse;
    }


    public async Task<ServiceResponse<UserProfileVm>> ProfileVmSR(string userId)
    {
        var serviceResponse = new ServiceResponse<UserProfileVm>();
        try
        {
            var userProfile = await _dbContext.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);

            if (userProfile == null)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "User profile not found";
                return serviceResponse;
            }


            serviceResponse.Data = new UserProfileVm(userProfile.FirstName, userProfile.LastName, userProfile.Handicap, userProfile.Image);
            // var userProfileVm = new UserProfileVm
            //  {
            //      FirstName = userProfile.FirstName,
            //      LastName = userProfile.LastName,
            //      Image = userProfile.Image,
            //      Handicap = userProfile.Handicap
            //  };


            // userProfileVm.Handicap = userProfile.Handicap;
            // userProfileVm.Image = userProfile.Image;
            // userProfileVm.FirstName = userProfile.FirstName;
            // userProfileVm.LastName = userProfile.LastName;
            // serviceResponse.Data = userProfileVm;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return serviceResponse;
    }

    public async Task<UserProfileVm?> ProfileVm(string userId)
    {
        try
        {
            var userProfile = await _dbContext.UserProfiles.FirstOrDefaultAsync(x => x.UserId == userId);

            return userProfile == null ? null : new UserProfileVm(userProfile.FirstName, userProfile.LastName, userProfile.Handicap, userProfile.Image);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }

    public UserProfileVm ProfileVm(UserProfile userProfile)
    {
        
        return new UserProfileVm(userProfile.FirstName, userProfile.LastName, userProfile.Handicap, userProfile.Image);
        // return new UserProfileVm
        // {
        //     Handicap = userProfile.Handicap,
        //     Image = userProfile.Image,
        //     FirstName = userProfile.FirstName,
        //     LastName = userProfile.LastName
        // };
    }
}