using ExpensesApi.Domain.Primitives;
using ExpensesApi.Domain.ValueObjects;

namespace ExpensesApi.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Currency { get; private set; }
        public List<Expense> ExpenseList { get; private set; }

        protected User() : base() { }

        public User(Guid id, string firstName, string lastName, string currency) : base(id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public static User CreateNewUser(string firstName, string lastName, string currency)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name cannot be empty.", nameof(lastName));
            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("Currency cannot be empty.", nameof(currency));

            return new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Currency = currency
            };
        }

        public void AddExpense(Expense expense)
        {
            if (expense == null) throw new ArgumentNullException(nameof(expense));
            if (expense.Currency != Currency)
                throw new InvalidOperationException("Expense currency must match user currency.");
            ExpenseList.Add(expense);
        }
    }
}
