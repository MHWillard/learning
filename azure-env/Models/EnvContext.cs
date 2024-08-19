using Microsoft.EntityFrameworkCore;

namespace azure_env.Models
{
    public class EnvContext : DbContext
    {
        public EnvContext(DbContextOptions<EnvContext> options)
    : base(options)
        {
        }

        public DbSet<EnvClass> EnvItems { get; set; } = null!;
    }
}
