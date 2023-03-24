using FlyCompanyConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FlyCompanyConsoleApp.Controller
{
    public class AdminController
    {
        public void AddAFlight(string? fromDestination, string? toDestination, DateTime takeOffTime, DateTime landTime, int planeId)
        {
            using (var dbcontext = new FlyContext())
            {
                Flight flight = new Flight();
                flight.FromDestination = fromDestination;
                flight.ToDestination = toDestination;
                flight.TakeOffTime = takeOffTime;
                flight.LandTime = landTime;
                flight.PlaneId = planeId;
                dbcontext.Flights.Add(flight);
                dbcontext.SaveChanges();
            }
        }

        public void RemoveAFlight(int flightId)
        {
            using (var dbcontext = new FlyContext())
            {
                while (true)
                {
                    Flight flight = dbcontext.Flights.FirstOrDefault(f => f.Id == flightId);
                    if (flight != null)
                    {
                        dbcontext.Flights.Remove(flight);
                        break;
                    }
                    Console.WriteLine("There is no such flight");
                    Console.Write("Flight ID: ");
                    flightId = int.Parse(Console.ReadLine());
                    Console.Clear();
                }

            }
        }

        public void MakeAdmin(string username)
        {
            using (var dbcontext = new FlyContext())
            {
                while (true)
                {
                    if (username != null)
                    {
                        dbcontext.Users.FirstOrDefault(x => x.Username == username).IsAdmin = true;
                        break;
                    }
                    Console.WriteLine("Username cannot be null");
                    Console.Write("Username of the user: ");
                    username = Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void BanUser(string username)
        {
            using (var dbcontext = new FlyContext())
            {
                while (true)
                {
                    if (username != null)
                    {
                        var user = dbcontext.Users.FirstOrDefault(x => x.Username == username);
                        if (user != null)
                        {
                            dbcontext.Users.Remove(user);
                            break;
                        }
                        Console.WriteLine("Username doesn't exist");
                        username = Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    Console.WriteLine("Username cannot be null");
                    Console.Write("Username of the user: ");
                    username = Console.ReadLine();
                    Console.Clear();
                }
            }

        }

        public void AddEmployeeToAFlight(string firstName, string lastName)
        {
            using (var dbcontext = new FlyContext())
            {
                while (true)
                {
                    var employee = dbcontext.Employees.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
                    if (employee != null)
                    {
                        Console.Write("FLight ID: ");
                        int flightId = int.Parse(Console.ReadLine());
                        var flight = dbcontext.Flights.FirstOrDefault(x => x.Id == flightId);
                        if (flight != null)
                        {
                            var flightsCrew = new FlightsCrew();
                            flightsCrew.Employee = employee;
                            flightsCrew.Flight = flight;
                            dbcontext.FlightsCrews.Add(flightsCrew);
                        }
                        Console.WriteLine("Flight doesn't exist");
                        continue;
                    }
                    Console.WriteLine("Employee doesn't exist");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
