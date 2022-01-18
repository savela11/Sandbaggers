namespace API.Models.ViewModel;

public class UserVm
{
    public string? Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FullName { get; set; }
    public UserProfileVm? Profile { get; set; }
    public UserSettingsVm? Settings { get; set; }
}