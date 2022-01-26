namespace API.Models.ViewModel;

public class UserSettingsVm
{
    public List<FavoriteLinkVm> FavoriteLinks { get; set; } = new();

    public ContactVm Contact { get; set; } = new();
}

public class FavoriteLinkVm
{
    public string? Name { get; set; }
    public string? Link { get; set; }
}

public class ContactVm
{
    public bool IsEmailShowing { get; set; }
    public bool IsPhoneNumberShowing { get; set; }
}