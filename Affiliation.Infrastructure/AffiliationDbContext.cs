using Affiliation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Affiliation.Infrastructure
{
    public class AffiliationDbContext : DbContext
    {
        private static bool _created = false;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="options">DbContextOptions object.</param>
        public AffiliationDbContext(DbContextOptions<AffiliationDbContext> options)
            : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Affiliate>()
                .HasAlternateKey(a => a.Name);
            modelBuilder.Entity<Customer>()
                .HasAlternateKey(c => c.Name);
        }
    }
}
