using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class EntityBase
    {
        public int Key { get; set; }
    }

    public class Job : EntityBase
    {
        public double NotServedPenalty { get; set; }
        public IList<Stop> Stops { get; set; }
    }

    public class Stop : EntityBase
    {
        
    }
}