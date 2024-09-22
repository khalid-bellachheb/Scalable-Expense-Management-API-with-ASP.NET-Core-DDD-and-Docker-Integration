using ExpensesApi.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApi.Application.DTOs
{
    public class ExpenseDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Comment Comment { get; set; }
        public string Type { get; set; }
    }
}
