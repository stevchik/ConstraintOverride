using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.dto
{
    public class Profile
    {
        public List<Vehicle> Vehicles { get; set; }
        public RouteConstraint RouteConstraint { get; set; }
    }
}
