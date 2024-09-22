using ExpensesApi.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApi.Application.Validators
{
    public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator()
        {
            RuleFor(command => command.UserId).NotEmpty();
            RuleFor(command => command.Amount).GreaterThan(0);
            RuleFor(command => command.Currency).NotEmpty();
            RuleFor(command => command.Date).LessThanOrEqualTo(DateTime.UtcNow);
            RuleFor(command => command.Comment).NotEmpty();
        }
    }
}
