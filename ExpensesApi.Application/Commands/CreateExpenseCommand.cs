using ExpensesApi.Application.DTOs;
using ExpensesApi.Domain.Enums;
using MediatR;

namespace ExpensesApi.Application.Commands
{
    public class CreateExpenseCommand : IRequest<ExpenseDto>
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public ExpenseTypeEnum Type { get; set; }
    }
}
