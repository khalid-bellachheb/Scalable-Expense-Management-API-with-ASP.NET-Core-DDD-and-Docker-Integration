using ExpensesApi.Domain.Entities;
using ExpensesApi.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExpensesApi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());

            SeedInitialData(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Data/Migrations"));
        }
        private void SeedInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new
                {
                    Id = Guid.Parse("12345678-9abc-def0-1234-567890abcdef"),
                    FirstName = "Anthony",
                    LastName = "Stark",
                    Currency = "USD",
                    DateCreated = DateTime.UtcNow, 
                    DateModified = DateTime.UtcNow, 
                    CreatedBy = "system" 
                },
                new
                {
                    Id = Guid.Parse("abcdef12-3456-7890-abcd-ef1234567890"),
                    FirstName = "Natasha",
                    LastName = "Romanova",
                    Currency = "RUB",
                    DateCreated = DateTime.UtcNow, 
                    DateModified = DateTime.UtcNow, 
                    CreatedBy = "system" 
                }
            );
        }
    }
}
