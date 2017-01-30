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
            return GetValue<int>("OutOfRoute", profile.RouteConstraint.OutOfRoute, route);    
        }

        private static T GetValue<T>(string constrainName, T value, Route route)
        {
            object overrideValue = GetOverride(constrainName, route);

            return (overrideValue == null ? value : (T)overrideValue);
        }

        private static object GetOverride(string name, Route route)
        {
            if (route.Vehicle != null)
            {
                PropertyValue constOver = route.Vehicle.ConstraintOverrides.FirstOrDefault(f => f.PropertyName.Equals(name));
                if (constOver != null)
                {
                    return constOver.Value;
                }
            }

            return null;
        }
    }
}
