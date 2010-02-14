using System;
using System.Collections.Generic;

namespace Domain
{
    public class Entity
    {
        public int Id { get; set; }
    }

    public class Customer : Entity
    {        
        public string FirstName { get; set; }
        public IDictionary<string, Book> FavouriteBooks { get; set; }

        public Customer()
        {
            FavouriteBooks = new Dictionary<string, Book>();
        }

    }

    public class Book : Entity
    {
        public string Name { get; set; }
    }


}