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
                while (fromDestination == null || toDestination == null || takeOffTime == null || landTime == null)
                {
                    Console.WriteLine("Please fill all the fields\n");
                    Console.Write("From: ");
                    fromDestination = Console.ReadLine();
                    Console.Write("\nTo: ");
                    toDestination = Console.ReadLine();
                    Console.Write("\nTake off time (DD/MM/YYYY): ");
                    string takeOffTimeString = Console.ReadLine();
                    takeOffTime = DateTime.Parse(takeOffTimeString);
                    Console.Write("Approximate landing time: ");
                    string landTimeString = Console.ReadLine();
                    landTime = DateTime.Parse(landTimeString);
                    Console.Write("Plane ID: ");
                    planeId = int.Parse(Console.ReadLine());
                }
                Flight flight = new Flight();
                flight.FromDestination = fromDestination;
                flight.ToDestination = toDestination;
                flight.TakeOffTime = takeOffTime;
                flight.LandTime = landTime;
                while (dbcontext.Planes.FirstOrDefault(x => x.Id == planeId) == null)
                {
                    Console.WriteLine("Wrong planeId. Please enter a valid one:");
                    planeId = int.Parse(Console.ReadLine());
                }
                flight.PlaneId = planeId;
                dbcontext.Flights.Add(flight);
                dbcontext.SaveChanges();
                Console.Clear();
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
                        var canceledFlight = new CanceledFlight()
                        {
                            Flight = flight,
                            FlightId = flight.Id,
                        };
                        dbcontext.CanceledFlights.Add(canceledFlight);
                        dbcontext.SaveChanges();  // Save changes after removing the flight
                        Console.Clear();
                        break;
                    }
                    Console.WriteLine("There is no such flight");
                    Console.Write("Flight ID: ");
                    flightId = int.Parse(Console.ReadLine());
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
                        Console.Clear();
                        break;
                    }
                    Console.WriteLine("Username cannot be null");
                    Console.Write("Username of the user: ");
                    username = Console.ReadLine();
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
                            Console.Clear();
                            break;
                        }
                        Console.WriteLine("Username doesn't exist");
                        username = Console.ReadLine();
                        continue;
                    }
                    Console.WriteLine("Username cannot be null");
                    Console.Write("Username of the user: ");
                    username = Console.ReadLine();
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
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No flight with this ID exists.");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No employee with this name exists.");
                        Console.Write("First name: ");
                        firstName = Console.ReadLine();
                        Console.Write("Last name: ");
                        lastName = Console.ReadLine();
                    }
                }
            }
        }

        public void AddEmployee(string firstName, string lastName, string type, string gender)
        {
            using (var dbcontext = new FlyContext())
            {
                while (true)
                {
                    if (firstName != null && lastName != null && type != null && gender != null)
                    {
                        var employee = new Employee();
                        employee.FirstName = firstName;
                        employee.LastName = lastName;
                        employee.Type = type;
                        employee.Gender = gender;
                        dbcontext.Employees.Add(employee);
                        Console.Clear();
                        break;
                    }
                    Console.WriteLine("Please fill all fields:\n");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
                    Console.Write("Type of employee (Stewardess/Pilot): ");
                    type = Console.ReadLine();
                    Console.Write("Gender (Male/Female/Unknown): ");
                    gender = Console.ReadLine();
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
                        Console.Clear();
                        break;
                    }
                    Console.WriteLine("Employee doesn't exist");
                    Console.Write("First name: ");
                    firstName = Console.ReadLine();
                    Console.Write("Last name: ");
                    lastName = Console.ReadLine();
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
                        dbcontext.SaveChanges();
                        Console.Clear();
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