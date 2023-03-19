using FlyCompanyConsoleApp.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FlyCompanyConsoleApp.Controller
{
    public class FlightController
    {
        public FlightController() { }
        public void BookAFlight(string takeOffDestination, string landDestination, DateTime date)
        {
            using (var dbcontext = new FlyContext())
            {
                var flights = dbcontext.Flights.
                                OrderBy(x => x.TakeOffTime < date)
                                .Where(x => x.FromDestination == takeOffDestination && x.ToDestination == landDestination)
                                .Take(30)
                                .ToList();
                foreach (var flight in flights)
                {
                    Console.WriteLine($"{flight}\n------------------");
                }

                Console.WriteLine("\nSelect the number of the flight you want to book:");
                int flightId = int.Parse(Console.ReadLine());
                while (flightId < 0 || flightId > flights.Count())
                {
                    Console.WriteLine("This is not a valid flight");
                    flightId = int.Parse(Console.ReadLine());
                }
                Console.Clear();

                Console.WriteLine($"You have booked flight:\n{flights[flightId]}");
                FlightsTraveler ft = new FlightsTraveler();
                ft.User = LoggerUser.loggerUser;
                ft.UserId = LoggerUser.loggerUser.Id;
                ft.Flight = dbcontext.Flights.FirstOrDefault(x => x.Id == flights[flightId].Id);
                ft.FlightId = flights[flightId].Id;
                dbcontext.FlightsTravelers.Add(ft);
                dbcontext.SaveChanges();
            }
        }
        public void CheckFlightHistory()
        {
            using (FlyContext dbcontext = new FlyContext()) 
            {
                var flights = dbcontext.FlightsTravelers.Where(x => x.User == LoggerUser.loggerUser);
                foreach (var flight in flights)
                {
                    Console.WriteLine(flight);
                    Console.WriteLine("\n---------------------\n");
                }
            }
        }
    }
}
