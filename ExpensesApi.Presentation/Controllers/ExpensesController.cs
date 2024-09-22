using ExpensesApi.Domain.Entities;
using ExpensesApi.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesApi.Presentation.Controllers
{
    /// <summary>
    /// Expenses controller 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpensesController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        /// <summary>
        /// Get all the expenses 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllExpenses(CancellationToken cancellationToken)
        {
            var expenses = await _expenseRepository.GetAllExpenseAsync(cancellationToken);
            return Ok(expenses);
        }

        /// <summary>
        /// Create an expense 
        /// </summary>
        /// <param name="expense"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] Expense expense, CancellationToken cancellationToken)
        {
            if (expense == null)
                return BadRequest("Expense is null.");

            await _expenseRepository.AddExpenseAsync(expense, cancellationToken);
            return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, expense);
        }

        /// <summary>
        /// Return an expense by ID
        /// </summary>
        /// <param name="id">Guid of expense</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpense(Guid id, CancellationToken cancellationToken)
        {
            var expense = await _expenseRepository.GetExpenseByIdAsync(id, cancellationToken);
            if (expense == null)
                return NotFound();

            return Ok(expense);
        }
    }
}
