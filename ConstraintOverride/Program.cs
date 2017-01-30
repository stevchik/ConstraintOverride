using ConstraintOverride.dataseed;
using ConstraintOverride.dto;
using ConstraintOverride.matcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintOverride
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRoutes;
            int numberOfOrders;
            int numberOfStops;
            int numberOfMatches = 0;
            int routeIndex = 0;
            Route route = null;

            string value = string.Empty;
            Console.WriteLine("Number of routes?");
            value = Console.ReadLine();
            if (!int.TryParse(value, out numberOfRoutes))
            {
                numberOfRoutes = 1000;
            }

            Console.WriteLine("Number of orders within route?");
            value = Console.ReadLine();
            if (!int.TryParse(value, out numberOfOrders))
            {
                numberOfOrders = 20;
            }

            Console.WriteLine("Number of stops within route?");
            value = Console.ReadLine();
            if (!int.TryParse(value, out numberOfStops))
            {
                numberOfStops = 40;
            }

            List<Route> routes = RouteGenerator.GetRoutes(numberOfRoutes, numberOfOrders, numberOfStops);

            Console.WriteLine($"Done with {routes.Count} Routes");

            Profile profile = ProfileGenerator.GetProfile();

            Console.WriteLine($"Done with Profile");

            numberOfMatches = VehicleFinder.FindVehicles(routes, profile.Vehicles);

            Console.WriteLine($"Found {numberOfMatches} matches");

            Console.WriteLine($"Route index:");

            value = Console.ReadLine();
            while (!value.Equals("x"))
            {
                if (int.TryParse(value, out routeIndex))
                {
                    route = routes[routeIndex];
                    Console.WriteLine($"Out of route for {routeIndex} is {ConstraintFinder.GetOutOfRoute(profile, route)}");
                    if (route.Vehicle!=null)
                    {
                        Console.WriteLine($"Vehicle {route.Vehicle.Name}");
                    }
                }
                value = Console.ReadLine();
            }
           
            
        }
    }
}
