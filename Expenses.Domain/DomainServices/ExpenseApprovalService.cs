using ExpensesApi.Domain.Entities;
using ExpensesApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApi.Domain.DomainServices
{
    public class ExpenseApprovalService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseApprovalService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
    }
}
