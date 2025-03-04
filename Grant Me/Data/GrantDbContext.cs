using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Grant_Me.Models;

namespace Grant_Me.Data
{
    public class GrantDbContext : IdentityDbContext<User>
    {
        public GrantDbContext(DbContextOptions<GrantDbContext> options) : base(options) { }

        public DbSet<Grant> Grants { get; set; }
    }
}
