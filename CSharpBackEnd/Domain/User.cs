using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpBackEnd.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EmailAddressAttribute Email { get; set; }
        public string Cpf { get; set; }
        public List<Loan> Loans { get; set; } 
    }
}