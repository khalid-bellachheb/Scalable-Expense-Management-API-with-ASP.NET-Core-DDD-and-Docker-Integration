using ExpensesApi.Domain.Entities;
using ExpensesApi.Domain.Repositories;
using ExpensesApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApi.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddExpenseAsync(Expense expense, CancellationToken cancellationToken)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteExpenseAsync(Expense expense, CancellationToken cancellationToken)
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Expense>> GetAllExpenseAsync(CancellationToken cancellationToken)
        {
            return await _context.Expenses
                       .Include(expense => expense.User) 
                       .ToListAsync();
        }

        public async Task<Expense> GetExpenseByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Expenses
                       .Include(expense => expense.User) 
                       .FirstOrDefaultAsync(expense => expense.Id == id, cancellationToken);
        }

        public async Task UpdateExpenseAsync(Expense expense, CancellationToken cancellationToken)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
