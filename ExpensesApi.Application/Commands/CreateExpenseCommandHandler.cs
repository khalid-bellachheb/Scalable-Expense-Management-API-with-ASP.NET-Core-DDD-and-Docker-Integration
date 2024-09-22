using AutoMapper;
using ExpensesApi.Application.DTOs;
using ExpensesApi.Domain.Entities;
using ExpensesApi.Domain.Repositories;
using ExpensesApi.Domain.ValueObjects;
using MediatR;

namespace ExpensesApi.Application.Commands
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ExpenseDto>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateExpenseCommandHandler(IExpenseRepository expenseRepository, IUserRepository useRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _userRepository = useRepository;
            _mapper = mapper;
        }

        public async Task<ExpenseDto> Handle(CreateExpenseCommand command, CancellationToken cancellationToken)
        {
            // Fetch the user from the repository
            User user = await _userRepository.GetUserByIdAsync(command.UserId, cancellationToken);

            if (user == null)
                throw new InvalidOperationException("User not found.");

            Expense expense = new Expense(
                user,
                command.Date,
                command.Amount,
                command.Currency,
                command.Comment,
                command.Type);

            await _expenseRepository.AddExpenseAsync(expense, cancellationToken);
            return _mapper.Map<ExpenseDto>(expense);
        }
    }
}
