using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.dto
{
    public class Route
    {
        public EquimentType EqipmentType { get; set; }
        public string Mode { get; set; }
        public DriverType DriverType { get; set; }
        public Carrier Carrier { get; set; }
        public List<Order> Orders { get; set; }
        public List<Stop> Stops { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
