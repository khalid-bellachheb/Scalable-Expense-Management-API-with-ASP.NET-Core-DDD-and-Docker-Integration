using AutoMapper;
using ExpensesApi.Application.DTOs;
using ExpensesApi.Domain.Entities;

namespace ExpensesApi.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expense, ExpenseDto>();
        }
    }
}
