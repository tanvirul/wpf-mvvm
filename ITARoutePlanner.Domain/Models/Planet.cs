using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.Domain.Models
{
    public class Planet : DomainObject
    {
        public string Name { get; set; }
        public int PositionIndex { get; set; }
        public bool Habitable { get; set; }
        public double Diameter { get; set; }
        public int AverageTemperature { get; set; }
        public double DistanceFromEarth { get; set; }
        public bool IsDwarf { get; set; }
    }
}
