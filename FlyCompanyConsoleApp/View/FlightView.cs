﻿using FlyCompanyConsoleApp.Controller;
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
                Console.WriteLine("Press '3' to log out");
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1: // book a flight
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
                            flightController.BookAFlight();
                        }
                        break;

                    case ConsoleKey.D2: // check flight history
                        {
                            Console.Clear();
                            flightController.CheckFlightHistory();
                        }
                        break;

                    case ConsoleKey.D3: // log out
                        break;

                    default:
                        continue;
                }
                Console.Clear();
                break;

            }
        }
    }
}
