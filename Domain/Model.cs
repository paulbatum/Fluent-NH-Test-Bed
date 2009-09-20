using System.Collections.Generic;

namespace Domain
{
    public class TestEntityA
    {
        public virtual int Id { get; set; }
        private IList<TestEntityB> _children = new List<TestEntityB>();
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }

        //public virtual IEnumerable<TestEntityB> Children
        //{
        //    get { return _children; }            
        //}
    }


    public class TestEntityB //: EntityBase<int>
    {
        public virtual int Id { get; set; }
        public virtual string Comment { get; set; }
        public virtual TestEntityA TestEntityA { get; set; }
    }

    public class Address
    {
        public virtual string Line1 { get; set;}
        public virtual string Line2 { get; set; }
    }

    public class EntityBase<T>
    {
        public virtual T Id { get; set; }
    }
}