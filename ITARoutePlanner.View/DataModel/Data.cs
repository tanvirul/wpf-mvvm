using ITARoutePlanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITARoutePlanner.View.DataModel
{
    public class Data
    {
        public IEnumerable<Spacecraft> Spacecrafts { get; set; }
        public IEnumerable<Planet> Planets { get; set; }

    }
}
