namespace TaskApi.Data
{
    using TaskApi.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class TaskApiDbContext : DbContext
    {
        public TaskApiDbContext(DbContextOptions<TaskApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Office> Offices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Company>()
                .HasMany(x => x.Offices)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Company>()
                .HasMany(x => x.Employees)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .Entity<Employee>()
               .Property(b => b.Salary)
               .HasColumnType("decimal(18,2)");

            base.OnModelCreating(builder);
        }

    }
}
