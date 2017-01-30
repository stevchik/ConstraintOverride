using ConstraintOverride.dto;
using ConstraintOverride.extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride.dataseed
{
    public class RouteGenerator
    {
        static int _customerId = 0;

        public static List<Route> GetRoutes(int numberOfRoutes, int numberOfOrdersWithinRoute, int numberofStopsWithinRoute)
        {
            int i = 0;
            int carrierId = 0;
            bool driverTypeKey = false;
            List<Route> routes = new List<Route>();

            Dictionary<bool, DriverType> driverTypes = new Dictionary<bool, DriverType>();
            driverTypes.Add(true, new DriverType() { IsTeam = true });
            driverTypes.Add(false, new DriverType() { IsTeam = false });

            List<EquimentType> equipmentTypes = new List<EquimentType>();
            equipmentTypes.Add(new EquimentType() { IsFlatbed = false, Length = 48, Name = "48 ft" });
            equipmentTypes.Add(new EquimentType() { IsFlatbed = false, Length = 53, Name = "53 ft" });
            equipmentTypes.Add(new EquimentType() { IsFlatbed = true, Length = 48, Name = "48 flat" });
            equipmentTypes.Add(new EquimentType() { IsFlatbed = false, Length = 53, Name = "53 flat" });

            List<string> modes = new List<string>() { "TL", "LTL" };
            
            while (i++ < numberOfRoutes)
            {
                carrierId = (i / 100) + 1;
                driverTypeKey = i % 2 != 0;

                Route route = new Route();
                route.Carrier = new Carrier() { Name = $"Carrier {carrierId}", CarrierCode = $"T{carrierId}" };
                route.DriverType = driverTypes[driverTypeKey];
                route.EqipmentType = equipmentTypes.RandomElement<EquimentType>();
                route.Mode = modes.RandomElement<string>();
                route.Orders = GetOrders(numberOfOrdersWithinRoute);
                route.Stops = GetStops(numberofStopsWithinRoute);
                routes.Add(route);
            }

            return routes;
        }

        private static List<Stop> GetStops(int numberofStops)
        {
            int i = 0;
            List<Stop> stops = new List<Stop>();

            while (i++ < numberofStops)
            {
                Stop stop = new Stop();

                stop.SequenceNumber = i;
                stop.StopType = (numberofStops / 2 < i ? "P" : "D");
                stop.Warehouse = new Warehouse() { WarehouseCode = $"W{i}", Name = $"Warehouse {i}" };

                stops.Add(stop);
            }

            return stops;
        }

        private static List<Order> GetOrders(int numberOfOrders)
        {
            int i = 0;
            
            List<Order> orders = new List<Order>();

            while (i++ < numberOfOrders)
            {
                _customerId = (_customerId  + i / 2) + 1;

                Order order = new Order();
                order.CustomerCode = $"C{_customerId}";
                order.OrderNumer = i;
                orders.Add(order);
            }

            return orders;
        }
    }
}
