using System.Collections.Generic;

namespace Domain
{
    public class EntityBase<T> : PersistentBase
    {
        private T _id = default(T);

        public virtual T Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }
    }

    public abstract class PersistentBase
    {}

    public class TestEntityA : EntityBase<int>
    {
        private string _name;

        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private IList<TestEntityB> _children = new List<TestEntityB>();

        public virtual IEnumerable<TestEntityB> Children
        {
            get { return _children; }
            //protected set { _children = value.ToList(); }
        }

        public virtual void AddChild(TestEntityB b)
        {
            _children.Add(b);
            b.TestEntityA = this;
        }
    }

    public class TestEntityB : EntityBase<int>
    {
        private string _comment;

        public virtual string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        private TestEntityA _testEntityA = null;

        public virtual TestEntityA TestEntityA
        {
            get { return _testEntityA; }
            set { _testEntityA = value; }
        }
    }
}