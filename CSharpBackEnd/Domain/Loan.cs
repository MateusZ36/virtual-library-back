using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CSharpBackEnd.Domain
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<User> Book { get; set; }
        public User User { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
    }
}