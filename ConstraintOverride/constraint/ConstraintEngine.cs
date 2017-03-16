using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstraintOverride.dto;
using ConstraintOverride.dto.Constraints;


namespace ConstraintOverride.constraint
{
    public class ConstraintEngine
    {
        public void GetConstraintGroups(Profile profile)
        {
            List<ConstraintGroup> cGroups = new List<ConstraintGroup>();
            
            foreach(RouteConstraint rConst in  profile.RouteConstraints)
            {
                cGroups.RouteConstraint = rConst;
            }
        }

    }
}
