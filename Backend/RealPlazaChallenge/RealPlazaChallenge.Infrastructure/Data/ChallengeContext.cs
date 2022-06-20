using Microsoft.EntityFrameworkCore;
using RealPlazaChallenge.Infrastructure.Models;


namespace RealPlazaChallenge.Infrastructure.Data
{
    public class ChallengeContext : DbContext
    {
        public ChallengeContext() { 
        }

        public ChallengeContext(DbContextOptions<ChallengeContext> options) : base(options) { 
        }

        public DbSet<tb_product> products { get; set; }
        public DbSet<tb_user> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChallengeContext).Assembly);
        }
    }
}
