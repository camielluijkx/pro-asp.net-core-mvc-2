using Microsoft.AspNetCore.Identity;

namespace Users.Models
{
    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }

        public QualificationLevels Qualifications { get; set; }
    }
}