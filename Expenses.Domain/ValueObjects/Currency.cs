namespace ExpensesApi.Domain.ValueObjects
{
    public class Currency
    {
        public string Code { get; }

        protected Currency() { }

        public Currency(string code)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
        }

        public static Currency Create(string code) => new Currency(code);
    }
}
