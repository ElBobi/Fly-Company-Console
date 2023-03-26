using FlyCompanyConsoleApp.Controller;
using FlyCompanyConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCompanyConsoleApp.View
{
    public class FlightView
    {
        private FlightController flightController;
        public FlightView()
        {
            flightController = new FlightController();
        }
        public void Run()
        {
            while (true)
            {

                Console.WriteLine("Press '1' if you want to book a flight");
                Console.WriteLine("Press '2' if you want to check flight history");
                Console.WriteLine("Press Escape to log out");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1: // book a flight
                        {
                            Console.Clear();

                            // Read the flights data from the user
                            Console.WriteLine("Take off destination:");
                            string takeOffDestination = Console.ReadLine();
                            Console.WriteLine("Land destination:");
                            string landDestination = Console.ReadLine();
                            Console.WriteLine("Latest flight date (YY/MM/DD)");
                            string dateAsString = Console.ReadLine();
                            DateTime date = DateTime.Parse(dateAsString);
                            flightController.BookAFlight(takeOffDestination, landDestination, date);
                        }
                        break;

                    case ConsoleKey.D2 or ConsoleKey.NumPad2: // check flight history
                        {
                            Console.Clear();
                            flightController.CheckFlightHistory();
                            Console.WriteLine("\nPress any key to return to the menu: ");
                            ConsoleKeyInfo key2 = Console.ReadKey();
                        }
                        break;

                    case ConsoleKey.Escape: // Log out
                        {
                            Console.Clear();
                            return;
                        }
                        

                    default:
                        continue;
                }
                Console.Clear();
            }
        }
    }
}
