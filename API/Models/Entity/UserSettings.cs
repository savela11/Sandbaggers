using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Entity;

public class UserSettings
{
    [Key] [Required] public string UserId { get; set; } = null!;

    public ApplicationUser User { get; set; } = null!;

    [Column(TypeName = "jsonb")] public List<FavoriteLink> FavoriteLinks { get; set; } = new List<FavoriteLink>();


    //TODO add a contact property after resetting the database instead of separate iscontact and email showing
    // [Column(TypeName = "jsonb")]
    // public Contact Contact { get; set; }


    // public Contact Contact { get; set; } = null!;

    public bool IsContactNumberShowing { get; set; } = false;

    public bool IsContactEmailShowing { get; set; } = false;
}

public class FavoriteLink
{
    public string? Name { get; set; }
    public string? Link { get; set; }
}

public class Contact
{
    public bool IsPhoneNumberShowing { get; set; } = false;

    public bool IsEmailShowing { get; set; } = false;
}