namespace API.Services.Interface;

public interface IService
{
    
    public IUserService User { get; }
    public IAuthService Auth { get; }
    public IRoleService Role { get; }
}