using System;
using System.Collections.Generic;

namespace Domain
{
    public class Coordinate
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
    }

    public class Trip
    {
        public int Id { get; set; }
        public Coordinate Origin { get; set; }
        public Coordinate Destination { get; set; }
    }
}