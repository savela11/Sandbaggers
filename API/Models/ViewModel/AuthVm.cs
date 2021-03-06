namespace API.Models.ViewModel;

public class LoggedInUserVm
{
    public string? Id { get; set; }
    public string? Username { get; set; }
    public List<string> Roles { get; set; } = new();
    public string? Token { get; set; }
    public UserSettingsVm Settings { get; set; } = new();
    public string? Image { get; set; }
}