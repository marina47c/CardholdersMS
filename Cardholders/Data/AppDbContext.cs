using CardholderManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CardholderManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cardholder> Cardholders => Set<Cardholder>();
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cardholder>(entity =>
            {
                entity.Property(x => x.Id)
                      .ValueGeneratedOnAdd()
                      .UseIdentityColumn(seed: 101, increment: 1);

                // 🔹 Seed data (fixed IDs so EF can track them)
                entity.HasData(
                    new Cardholder
                    {
                        Id = 1u,
                        FirstName = "Dragan",
                        LastName = "Jurić",
                        PhoneNumber = "+38591234567",
                        Address = "11 Nexi St",
                        TransactionCount = 0,
                    },
                    new Cardholder
                    {
                        Id = 2u,
                        FirstName = "Matej",
                        LastName = "Brlec",
                        PhoneNumber = "+38591876543",
                        Address = "34 Nexi St",
                        TransactionCount = 0,
                    },
                    new Cardholder
                    {
                        Id = 3u,
                        FirstName = "Marija",
                        LastName = "Štefić",
                        PhoneNumber = "+38591876544", // changed to avoid duplicate
                        Address = "65 Nexi St",
                        TransactionCount = 0,
                    },
                    new Cardholder
                    {
                        Id = 4u,
                        FirstName = "Kristina",
                        LastName = "Sardelić",
                        PhoneNumber = "+38591111222",
                        Address = "65 Nexi St",
                        TransactionCount = 0,
                    },
                    new Cardholder
                    {
                        Id = 5u,
                        FirstName = "Marina",
                        LastName = "Capan",
                        PhoneNumber = "+38593344556",
                        Address = "New Nexi St",
                        TransactionCount = 0,
                    }
                );
            });

            modelBuilder.Entity<Employee>()
             .HasIndex(e => e.Username)
             .IsUnique();
        }
    }
}
