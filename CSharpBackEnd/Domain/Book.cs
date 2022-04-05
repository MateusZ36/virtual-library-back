using System;
using System.Collections.Generic;

namespace CSharpBackEnd.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri ImageUrl { get; set; }
        public Genre Genre { get; set; }
        public List<Author> Author {get; set; }
        public List<PublishingCompany> Company { get; set; }
    }
}