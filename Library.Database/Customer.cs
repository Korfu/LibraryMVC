using System;
using System.Collections.Generic;

namespace Library.Database
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
