using Microsoft.AspNetCore.Identity;

namespace BnDapi.Data
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
