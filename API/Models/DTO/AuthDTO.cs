using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO;

public readonly record struct LogInUserDto(string Username, string Password);

public class LoginUserDto
{
    [Required]
    [DataType(DataType.Text)]
    [StringLength(20)]
    public string UserName { get; set; } = null!;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
        MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}

public class RegisterUserDto
{
    [Required]
    [DataType(DataType.Text)]
    [StringLength(20)]
    public string UserName { get; set; } = null!;

    [Required]
    [DataType(DataType.Text)]
    [StringLength(20)]
    public string FirstName { get; set; } = null!;

    [Required]
    [DataType(DataType.Text)]
    [StringLength(20)]
    public string LastName { get; set; } = null!;

    [Required]
    [DataType(DataType.Text)]
    [StringLength(20)]
    public string RegistrationCode { get; set; } = null!;

    [Required] [EmailAddress] public string Email { get; set; } = null!;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
        MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = null!;

    [Required] public bool LoginAfterRegister { get; set; }
}