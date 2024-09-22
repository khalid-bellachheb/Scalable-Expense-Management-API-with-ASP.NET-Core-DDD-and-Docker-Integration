using ExpensesApi.Domain.Enums;
using ExpensesApi.Domain.Primitives;
using ExpensesApi.Domain.ValueObjects;

namespace ExpensesApi.Domain.Entities
{
    public class Expense : Entity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Comment { get; private set; }
        public ExpenseTypeEnum Type { get; private set; }
        public bool IsApproved { get; private set; } 
        public DateTime? ApprovalDate { get; private set; }

        protected Expense() // For EF Core
            : base() 
        { 
        } 

        protected Expense(Guid id) 
            : base(id) 
        { 
        }

        public Expense(User user, DateTime date, decimal amount, string currency, string comment, ExpenseTypeEnum type)
            : this(Guid.NewGuid(), user, date, amount, comment, currency, type) { }

        public Expense(Guid id, User user, DateTime date, decimal amount, string currency, string comment, ExpenseTypeEnum type)
            : base(id)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            UserId = user.Id;
            Date = date;
            Amount = amount;
            Currency = currency;
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
            Type = type;
        }
    }
}
