using System;
using System.Collections.Generic;

namespace Domain
{

    public class Customer : Person
    {
        public virtual DateTime CustomerSince { get; set; }
    }

    public class Person
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleInitial { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual string Email { get; set; }

        public Person()
        {
        }
    }
}