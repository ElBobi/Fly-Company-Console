using FlyCompanyConsoleApp.Controller;
using System;

namespace FlyCompanyConsoleApp.View
{
    public class AdminView
    {
        private AdminController adminController;

        public AdminView()
        {
            adminController = new AdminController();
        }

        public void Run()
        {
            while (true)
            {
                // Display menu options
                Console.WriteLine("Press 1 to manage Flights");
                Console.WriteLine("Press 2 to manage Users");
                Console.WriteLine("Press 3 to manage Employees");
                Console.WriteLine("Press 4 to manage Planes");
                Console.WriteLine("Press ESC to terminate the program");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();

                switch (key.Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        {
                            // Display flight management options
                            Console.WriteLine("Press 1 to add a flight");
                            Console.WriteLine("Press 2 to remove a flight");
                            Console.WriteLine("Press ESC to exit this menu");

                            key = Console.ReadKey();
                            Console.Clear();

                            switch (key.Key)
                            {
                                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                                    {
                                        // Call method to add a flight
                                        AddAFlight();
                                        break;
                                    }
                                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                                    {
                                        // Call method to remove a flight
                                        RemoveAFlight();
                                        break;
                                    }
                                case ConsoleKey.Escape:
                                    break;
                                default:
                                    continue;
                            }

                            break;
                        }
                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        {
                            // Display user management options
                            Console.WriteLine("Press 1 to make a user admin");
                            Console.WriteLine("Press 2 to ban a user");
                            Console.WriteLine("Press ESC to exit the menu");

                            key = Console.ReadKey();
                            Console.Clear();

                            switch (key.Key)
                            {
                                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                                    {
                                        // Call method to make a user admin
                                        MakeAdmin();
                                        break;
                                    }
                                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                                    {
                                        // Call method to ban a user
                                        BanUser();
                                        break;
                                    }
                                case ConsoleKey.Escape:
                                    break;
                                default:
                                    continue;
                            }

                            break;
                        }
                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        {
                            // Display employee management options
                            Console.WriteLine("Press 1 to add an employee to a flight");
                            Console.WriteLine("Press 2 to add a new employee");
                            Console.WriteLine("Press 3 to remove an employee");
                            Console.WriteLine("Press ESC to exit the menu");

                            key = Console.ReadKey();
                            Console.Clear();

                            switch (key.Key)
                            {
                                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                                    {
                                        // Call method to add an employee to a flight
                                        AddEmployeeToAFlight();
                                        break;
                                    }
                                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                                    {
                                        // Call method to add a new employee
                                        AddEmployee();
                                        break;
                                    }
                                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                                    {
                                        // Call method to remove an employee
                                        BanEmployee();
                                        break;
                                    }
                                case ConsoleKey.Escape:
                                    break;
                                default:
                                    continue;
                            }

                            break;
                        }
                    case ConsoleKey.D4 or ConsoleKey.NumPad4:
                        {
                            // Display plane management options
                            Console.WriteLine("Press 1 to add a plane");
                            Console.WriteLine("Press 2 to remove a plane");
                            Console.WriteLine("Press ESC to exit the menu");
                            key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                                    {
                                        AddPlane();
                                        break;
                                    }
                                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                                    {
                                        RemoveAPlane();
                                        break;
                                    }
                                case ConsoleKey.Escape:
                                    break;
                                default:
                                    continue;
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        return;
                    default:
                        continue;
                }
            }
        }

        private void RemoveAPlane()
        {
            Console.Write("Plane ID: ");
            int planeId = int.Parse(Console.ReadLine());
            adminController.RemoveAPlane(planeId);
        }

        private void AddPlane()
        {
            Console.Write("Capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            adminController.AddPlane(capacity);
        }

        private void BanEmployee()
        {
            Console.Clear();
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            adminController.BanEmployee(firstName, lastName);
        }

        private void AddEmployee()
        {
            Console.Clear();
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            adminController.AddEmployee(firstName, lastName);
        }

        private void AddEmployeeToAFlight()
        {
            Console.Clear();
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            adminController.AddEmployeeToAFlight(firstName, lastName);
        }

        private void BanUser()
        {
            Console.Clear();
            Console.Write("Username of the user: ");
            string username = Console.ReadLine();
            adminController.BanUser(username);
        }

        private void MakeAdmin()
        {
            Console.Clear();
            Console.Write("Username of the user: ");
            string username = Console.ReadLine();
            adminController.MakeAdmin(username);
        }

        private void RemoveAFlight()
        {
            Console.Clear();
            Console.Write("Flight Id:");
            int flightId = int.Parse(Console.ReadLine());
            adminController.RemoveAFlight(flightId);

        }

        private void AddAFlight()
        {
            Console.Clear();
            Console.Write("From: ");
            string fromDestination = Console.ReadLine();
            Console.Write("\nTo: ");
            string toDestination = Console.ReadLine();
            Console.Write("\nTake off time (DD/MM/YYYY): ");
            string takeOffTimeString = Console.ReadLine();
            DateTime takeOffTime = DateTime.Parse(takeOffTimeString);
            Console.Write("Approximate landing time: ");
            string landTimeString = Console.ReadLine();
            DateTime landTime = DateTime.Parse(landTimeString);
            Console.Write("Plane ID: ");
            int planeId = int.Parse(Console.ReadLine());
            adminController.AddAFlight(fromDestination, toDestination, takeOffTime, landTime, planeId);
        }
    }
}
