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
                Console.WriteLine();
                foreach (var f in flights)
                {
                    Console.WriteLine($"{f}\n------------------");
                }

                Console.WriteLine("\nSelect the id of the flight you want to book:");
                int flightId = int.Parse(Console.ReadLine());
                var flight = dbcontext.Flights.FirstOrDefault(x => x.Id == flightId);
                while (flight == null)
                {
                    Console.WriteLine("This is not a valid flight");
                    flightId = int.Parse(Console.ReadLine());
                    flight = dbcontext.Flights.FirstOrDefault(x => x.Id == flightId);
                }
                Console.Clear();

                Console.WriteLine($"You have booked flight:\n{flight}");
                FlightsTraveler ft = new FlightsTraveler()
                {
                    UserId = LoggerUser.loggerUser.Id,
                    FlightId = flight.Id
                };

                dbcontext.FlightsTravelers.Add(ft);
                dbcontext.SaveChanges();

            }
        }
        public void CheckFlightHistory()
        {
            using (FlyContext dbcontext = new FlyContext())
            {
                List<Flight> flights0 = dbcontext.FlightsTravelers.Where(x => x.User == LoggerUser.loggerUser).Select(x => x.Flight).OrderBy(x => x.TakeOffTime).ToList();
                Console.WriteLine($"\nHere are the flights user {LoggerUser.loggerUser.Username} have booked in ascending order from the oldest to the newest: \n");
                for (int i = 0; i < flights0.Count; i++)
                {
                    Console.WriteLine($"Flight No{i+1}:");
                    Console.WriteLine(flights0[i]);
                }
            }
        }
    }
}
