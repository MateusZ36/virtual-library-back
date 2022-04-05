﻿using System;
using System.Collections.Generic;

namespace CSharpBackEnd.Domain
{
    public class PublishingCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}