using ExpensesApi.Domain.Entities;

namespace ExpensesApi.Domain.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense> GetExpenseByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Expense>> GetAllExpenseAsync(CancellationToken cancellationToken);
        Task AddExpenseAsync(Expense expense, CancellationToken cancellationToken);
        Task UpdateExpenseAsync(Expense expense, CancellationToken cancellationToken);
        Task DeleteExpenseAsync(Expense expense , CancellationToken cancellationToken);
    }
}
