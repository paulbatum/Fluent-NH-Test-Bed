using System;
using System.Collections.Generic;

namespace Domain
{
    public class Book
    {
        public int Id { get; private set; }
        public virtual string Title { get; set; }
        public IList<Rating> Ratings { get; set; }

        public Book()
        {
            Ratings = new List<Rating>();
        }
        
    }

    public class CD
    {
        public int Id { get; private set; }
        public virtual string Title { get; set; }
        public IList<Rating> Ratings { get; set; }

        public CD()
        {
            Ratings = new List<Rating>();
        }
    }

    public class Rating
    {        
        public int UserId { get; set; }
        public int Value { get; set; }
    }
    


}