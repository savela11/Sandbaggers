using API.Models.ViewModel;
using API.Utility;

namespace API.Services.Interface;

public interface IAuthService
{
    Task<ServiceResponse<LoggedInUserVm>> LoggedInUserVm(string username, string password);

    Task Logout();
}