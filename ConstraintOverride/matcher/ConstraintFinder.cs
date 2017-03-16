using ConstraintOverride.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.matcher
{
    public static class ConstraintFinder
    {
        public static int GetOutOfRoute(Profile profile, Route route)
        {
            RouteConstraint rConst = profile.RouteConstraints.Where(r => r.Mode.Equals(r.Mode)).FirstOrDefault();

            return (rConst!= null ? GetValue<int>("OutOfRoute", rConst.OutOfRoute, route) : 0);    
        }

        private static T GetValue<T>(string constrainName, T value, Route route)
        {
            object overrideValue = GetOverride(constrainName, route);

            return (overrideValue == null ? value : (T)overrideValue);
        }

        private static object GetOverride(string name, Route route)
        {
            if (route.Override != null)
            {
                PropertyValue constOver = route.Override.ConstraintOverrides.FirstOrDefault(f => f.PropertyName.Equals(name));
                if (constOver != null)
                {
                    return constOver.Value;
                }
            }

            return null;
        }
    }
}
