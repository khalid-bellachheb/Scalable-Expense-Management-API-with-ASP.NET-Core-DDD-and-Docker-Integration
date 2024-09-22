using ExpensesApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpensesApi.Infrastructure.Data.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.Type).IsRequired();
            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.Currency).IsRequired().HasMaxLength(3);
            builder.Property(e => e.Comment).IsRequired();
            builder.Property(e => e.DateCreated).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
        }
    }
}
