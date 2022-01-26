using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace API.Models.Entity;

public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Specifies that an object's dates are coming in as UTC.
    /// </summary>
    /// <property name="DateTimeKind" value="Utc" />
    /// <typeparam name="T"></typeparam>
    /// <param name=""></param>
    /// <returns></returns> 
    public string? FullName { get; set; }
    [Required] public UserProfile UserProfile { get; set; } = null!;

    [Required] public UserSettings UserSettings { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}