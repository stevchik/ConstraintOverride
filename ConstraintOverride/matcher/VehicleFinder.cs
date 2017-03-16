using ConstraintOverride.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.matcher
{
    public class VehicleFinder
    {
        public static int FindVehicles(List<Route> routes, List<Override> overrides)
        {
            int numberOfMatches = 0;

            foreach (Override vehicle in overrides)
            {
                foreach (Route route in routes.Where(r => r.Override == null))
                {
                    if (doesVehicleMatchRoute(vehicle, route))
                    {
                        numberOfMatches++;
                        route.Override = vehicle;
                    }
                }
            }

            return numberOfMatches;
        }

        private static bool doesVehicleMatchRoute(Override vehicle, Route route)
        {
            foreach (Filter filter in vehicle.Filters)
            {
                if (!doesFilterMatchRoute(filter, route))
                {
                    return false;
                }
            }

            //we are still here. All filters in this vehicle matched a route
            return true;
        }

        private static bool doesFilterMatchRoute(Filter filter, Route route)
        {
            if (filter == null || filter.FilterConditions == null || filter.FilterConditions.Count == 0) return false;

            foreach (PropertyValue value in filter.FilterConditions)
            {
                Object objectValue = null;
                List<Object> objectValues = null;
               
                switch (value.Operator)
                {
                    case FilterOperator.Equals:
                        objectValue = PropertyValueFinder.GetPropertyValue(value.PropertyMap, route);
                        if (objectValue == null) return false;
                        if (!objectValue.Equals(value.Value))
                        {
                            return false;
                        }
                        break;
                    case FilterOperator.NotEquals:
                        objectValue = PropertyValueFinder.GetPropertyValue(value.PropertyMap, route);
                        if (objectValue == null) return false;
                        if (objectValue.Equals(value.Value))
                        {
                            return false;
                        }
                        break;
                    case FilterOperator.Contains:
                        objectValues = PropertyValueFinder.GetPropertyValues(value.PropertyMap, value.PropertyName, route);
                        if (objectValues == null || objectValues.Count==0) return false;
                        if ( objectValues.FirstOrDefault(o => value.Value.ToString().IndexOf(o.ToString()) >= 0) == null)
                        {
                            return false;
                        }                      
                        break;
                    default:
                        break;
                }

            }
            return true;
        }
    }
}
