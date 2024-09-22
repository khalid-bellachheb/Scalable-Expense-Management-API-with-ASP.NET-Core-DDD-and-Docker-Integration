using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApi.Domain.ValueObjects
{
    public class Comment
    {
        public string Text { get; private set; }

        private Comment() { } 

        private Comment(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("Comment cannot be empty or whitespace.");

            if (text.Length > 500) 
                throw new ArgumentException("Comment cannot be longer than 500 characters.");

            Text = text;
        }

        public static Comment Create(string text) => new Comment(text);

        public override bool Equals(object obj)
        {
            if (obj is Comment other)
            {
                return Text == other.Text;
            }
            return false;
        }

        public override int GetHashCode() => Text.GetHashCode();

        public override string ToString() => Text;
    }
}
