using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Data.Entities;

namespace Span.Culturio.Api.Data {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        public DbSet<CultureObject> CultureObjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageItem> PackageItems { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Visits> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
