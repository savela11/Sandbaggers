using API.Models.Entity;
using API.Models.ViewModel;
using API.Utility;

namespace API.Services.Interface;

public interface IUserService
{
    public Task<ServiceResponse<ApplicationUser>> ApplicationUserSR(string id);
    public Task<ServiceResponse<IEnumerable<ApplicationUser>>> ApplicationUsersSR();

    public Task<ServiceResponse<UserVm>> UserVmSR(string id);
    
    public Task<ServiceResponse<UserProfileVm>> ProfileVmSR(string userId);
    public Task<UserProfileVm?> ProfileVm(string userId);
    public UserProfileVm ProfileVm(UserProfile userProfile);
}