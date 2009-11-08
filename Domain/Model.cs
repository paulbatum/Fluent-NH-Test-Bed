using System;
using System.Collections.Generic;

namespace Domain
{
    public class Foo
    {
        public virtual int Id
        {
            get;
            protected set;
        }
        public virtual IBar Bar
        {
            get;
            set;
        }
    }

    public interface IBar
    {
        string Text
        {
            get;
            set;
        }
    }

    public class Bar : IBar
    {
        public virtual string Text
        {
            get;
            set;
        }
    }

}