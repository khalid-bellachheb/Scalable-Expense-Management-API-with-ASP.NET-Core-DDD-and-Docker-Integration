using AutoMapper;
using ExpensesApi.Application.DTOs;
using ExpensesApi.Domain.Entities;
using ExpensesApi.Domain.Repositories;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApi.Application.Queries
{
    public class GetExpensesByUserQueryHandler : IRequestHandler<GetExpensesByUserQuery, IEnumerable<ExpenseDto>>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public GetExpensesByUserQueryHandler(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExpenseDto>> Handle(GetExpensesByUserQuery query, CancellationToken cancellationToken)
        {
            Expense expense = await _expenseRepository.GetExpenseByIdAsync(query.UserId, cancellationToken);
            return _mapper.Map<IEnumerable<ExpenseDto>>(expense);
        }
    }
}
