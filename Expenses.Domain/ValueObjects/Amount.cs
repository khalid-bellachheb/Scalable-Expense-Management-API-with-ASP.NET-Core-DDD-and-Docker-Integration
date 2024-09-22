using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApi.Domain.ValueObjects
{
    public class Amount
    {
        public decimal Value { get; }
        public Currency Currency { get; }

        private Amount(decimal value, Currency currency)
        {
            if (value < 0) 
                throw new ArgumentException("Amont value cannot be negative", nameof(value));
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
            Value = value;
        }

        public static Amount Create(decimal value, Currency currency) => new Amount(value, currency);

        public override bool Equals(object obj)
        {
            return obj is Amount amount &&
                   Value == amount.Value &&
                   Currency.Equals(amount.Currency);
        }

        public bool Equals(Amount other)
        {
            return other != null &&
                   Value == other.Value &&
                   Currency.Equals(other.Currency);
        }

        public static bool operator ==(Amount left, Amount right) => Equals(left, right);
        public static bool operator !=(Amount left, Amount right) => !Equals(left, right);

        public Amount Add(Amount other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            if (!Currency.Equals(other.Currency))
                throw new InvalidOperationException("Cannot add amounts with different currencies.");

            return new Amount(Value + other.Value, Currency);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Currency);
        }

        public override string ToString()
        {
            return $"{Value} {Currency.Code}";
        }
    }
}
