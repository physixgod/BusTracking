using BusTracking.Domain.ENTITIES;
using Microsoft.EntityFrameworkCore;

namespace BusTracking.Infrastructure.DATA
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Societe> Societes { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<TrackingEvent> TrackingEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Societe)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SocieteId);

            base.OnModelCreating(modelBuilder);
        }
    }
}