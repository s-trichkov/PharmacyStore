using Microsoft.EntityFrameworkCore;
using PS.Models.Entities;

namespace PS.Data
{
    public class PharmacyStoreDbContext : DbContext
    {
        public PharmacyStoreDbContext(DbContextOptions<PharmacyStoreDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Medicine> Medicines { get; set; }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Prescription> Prescription { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=localhost; DataBase=PharmacyStore; User Id = admin; Password = adminpass");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Medicine>()
            //    .HasOne(m => m.Brand)
            //    .WithMany(b => b.Medicines)
            //    .HasForeignKey(m => m.BrandId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Brand>()
            //    .HasMany(b => b.Medicines)
            //    .WithOne(m => m.Brand)
            //    .HasForeignKey(b => b.MedicineId)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
