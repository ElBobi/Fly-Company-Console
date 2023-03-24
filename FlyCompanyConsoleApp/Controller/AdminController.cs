using FlyCompanyConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
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
                        dbcontext.SaveChanges();  // Save changes after removing the flight
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
                        dbcontext.SaveChanges();  // Save changes after making the user an admin
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
                            dbcontext.SaveChanges();  // Save changes after removing the user
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
                        Console.Write("Flight ID: ");
                        int flightId;
                        if (!int.TryParse(Console.ReadLine(), out flightId))
                        {
                            Console.WriteLine("Invalid input for Flight ID. Please enter an integer value.");
                            continue;
                        }
                        var flight = dbcontext.Flights.FirstOrDefault(x => x.Id == flightId);
                        if (flight != null)
                        {
                            var flightsCrew = new FlightsCrew();
                            flightsCrew.Employee = employee;
                            flightsCrew.Flight = flight;
                            dbcontext.FlightsCrews.Add(flightsCrew);
                            dbcontext.SaveChanges();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No flight with this ID exists.");
                            continue;
                        }
                    }
                    Console.WriteLine("No employee with this name exists.");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void AddEmployee(string firstName, string lastName)
        {
            using (var dbcontext = new FlyContext())
            {
                while (true)
                {
                    var employee = dbcontext.Employees.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
                    if (employee != null)
                    {
                        dbcontext.Employees.Add(employee);
                        break; 
                    }
                    Console.WriteLine("Employee doesn't exist");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Clear();
                }
                dbcontext.SaveChanges(); // Save the changes made to the database
            }
        }

        internal void BanEmployee(string? firstName, string? lastName)
        {
            using (var dbcontext = new FlyContext())
            {
                while (true)
                {
                    var employee = dbcontext.Employees.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
                    if (employee != null)
                    {
                        dbcontext.Employees.Remove(employee);
                        break; 
                    }
                    Console.WriteLine("Employee doesn't exist");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Clear();
                }
                dbcontext.SaveChanges(); // Save the changes made to the database
            }
        }

        public void AddPlane(int capacity)
        {
            using (var dbcontext = new FlyContext())
            {
                var plane = new Plane();
                plane.Capacity = capacity;
                dbcontext.Planes.Add(plane);
                dbcontext.SaveChanges(); // Save the changes made to the database
            }

        }

        public void RemoveAPlane(int planeId)
        {
            using (var dbcontext = new FlyContext())
            {
                while (true)
                {
                    var plane = dbcontext.Planes.FirstOrDefault(x => x.Id == planeId);
                    if (plane != null)
                    {
                        dbcontext.Planes.Remove(plane);
                        dbcontext.SaveChanges(); //
                        break;
                    }
                    Console.WriteLine("No place with this id");
                    Console.Write("Plane ID: ");
                    planeId = int.Parse(Console.ReadLine());
                }
                
            }
        }
    }
}