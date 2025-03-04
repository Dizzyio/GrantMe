using Microsoft.AspNetCore.Identity;

namespace Grant_Me.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
