using Grant_Me.Models;
using Microsoft.EntityFrameworkCore;

namespace Grant_Me.Data // Namespace matches the folder structure
{
    public class GrantDbContext : DbContext
    {
        public GrantDbContext(DbContextOptions<GrantDbContext> options) : base(options) { }

        public DbSet<Grant> Grants { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
