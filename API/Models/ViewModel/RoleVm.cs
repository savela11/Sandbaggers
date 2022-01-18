namespace API.Models.ViewModel;

// public readonly record struct RoleListWithUsersVm(List<string> Roles, List<string> Users);
public readonly record struct RoleWithUserVm(string RoleName, List<UserVmForRole> Users);

public readonly record struct UserVmForRole(string Id, string UserName, string FullName);