using Microsoft.AspNetCore.Identity;

namespace Pro.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string? Address { get; set; }
        public bool IsActive { get; set; } = true;
        public string ProfileImgPath { get; set; } = default!;
    }
}
