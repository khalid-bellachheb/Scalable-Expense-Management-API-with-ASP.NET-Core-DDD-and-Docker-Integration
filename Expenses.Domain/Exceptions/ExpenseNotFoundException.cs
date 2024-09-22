using ExpensesApi.Domain.Exceptions.Base;

namespace ExpensesApi.Domain.Exceptions
{
    public class ExpenseNotFoundException : NotFoundException
    {
        public ExpenseNotFoundException(Guid expenseId) 
            : base($"The expense with the identifier {expenseId} was not found.")
        {
        }
    }
}
