using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.Entity;

public class UserProfile
{
    [Key] [Required] public string UserId { get; set; } = null!;

    public ApplicationUser User { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    [Column(TypeName = "decimal(10,1)")] public decimal Handicap { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}