using Microsoft.EntityFrameworkCore;

namespace eUrzad.Entities
{
    public class InstitutionDbContext : DbContext
    {
        private string _connectionString =
           "Server=(localdb)\\mssqllocaldb; Database= InstytucjeDb; Trusted_Connection=True;";


        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Institution>()
                .Property(r => r.Voicodeship)
                .IsRequired();

            modelBuilder.Entity<Institution>()
                .Property(r => r.City)
                .IsRequired();

            modelBuilder.Entity<Institution>()
                .Property(r => r.PostalCode)
                .IsRequired();

            modelBuilder.Entity<Institution>()
                .Property(r => r.Street)
                .IsRequired();

            modelBuilder.Entity<Institution>()
                .Property(r => r.BuldingNumber)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(r => r.Voicodeship)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(r => r.City)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(r => r.Street)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(r => r.BuldingNumber)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(r => r.Voicodeship)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(r => r.ContactEmail)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(r => r.ContactEmail)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(r => r.City)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(r => r.Street)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(r => r.BuldingNumber)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(r => r.LastName)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(r => r.Age)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(r => r.LastName)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(r => r.Age)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(r => r.Postion)
                .IsRequired();

            modelBuilder.Entity<DocumentType>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
