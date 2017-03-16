using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstraintOverride.dto.Constraints;

namespace ConstraintOverride.dto
{
    public class Profile
    {
        public List<Override> Overrides { get; set; }
        public List<RouteConstraint> RouteConstraints { get; set; }
        public List<EquipmentTypeConstraint> EquipmentTypeConstraints { get; set; }
    }
}
