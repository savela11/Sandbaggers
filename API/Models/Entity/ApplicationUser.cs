using Microsoft.AspNetCore.Identity;

namespace API.Models.Entity;

public class ApplicationUser : IdentityUser
{
    
        public string? FullName { get; set; }
        public UserProfile UserProfile { get; set; }

        public UserSettings UserSettings { get; set; }
}