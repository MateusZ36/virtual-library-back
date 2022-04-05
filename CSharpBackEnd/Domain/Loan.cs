using System;

namespace CSharpBackEnd.Domain
{
    public class Loan
    {
        public Book Book { get; set; }
        public User User { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
    }
}