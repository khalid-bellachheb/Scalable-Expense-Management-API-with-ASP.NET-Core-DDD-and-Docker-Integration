using ExpensesApi.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApi.Application.Queries
{
    public class GetExpensesByUserQuery : IRequest<IEnumerable<ExpenseDto>>
    {
        public Guid UserId { get; set; }
    }
}
