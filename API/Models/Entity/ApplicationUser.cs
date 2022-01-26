using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Models.Entity;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    [Required] public UserProfile UserProfile { get; set; } = null!;

    [Required] public UserSettings UserSettings { get; set; } = null!;
}