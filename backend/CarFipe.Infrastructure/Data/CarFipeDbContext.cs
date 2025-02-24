using CarFipe.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarFipe.Infrastructure.Data
{
    public class CarFipeDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public CarFipeDbContext(DbContextOptions<CarFipeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
            base.OnModelCreating(modelBuilder);
        }
    }
}
