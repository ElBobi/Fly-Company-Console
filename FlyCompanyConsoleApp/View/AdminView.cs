using FlyCompanyConsoleApp.Controller;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("Press 1 to manage Flights");
                Console.WriteLine("Press 2 to manage Users");
                Console.WriteLine("Press 3 to manage Employees");
                Console.WriteLine("Press 4 to manage Planes");
                Console.WriteLine("Press ESC to terminate the program");

                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:
                        {
                            Console.WriteLine("Press 1 to add a flight");
                            Console.WriteLine("Press 2 to edit a flight");
                            Console.WriteLine("Press 3 to remove a flight");
                            Console.WriteLine("Press ESC to exit this menu");
                            key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                                    {
                                        AddAFlight();
                                        break;
                                    }
                                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                                    {
                                        EditAFlight();
                                        break;
                                    }
                                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                                    {
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
                            Console.WriteLine("Press 1 to make an user admin");
                            Console.WriteLine("Press 2 to ban a user");
                            Console.WriteLine("Press ESC to exit the menu");
                            switch (key.Key)
                            {
                                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                                    {
                                        MakeAdmin();
                                        break;
                                    }
                                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                                    {
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
                            Console.WriteLine("Press 1 to add an employee to a flight");
                            Console.WriteLine("Press 2 to add a new employee");
                            Console.WriteLine("Press 3 to remove an employee");
                            Console.WriteLine("Press ESC to exit the menu");
                            switch (key.Key)
                            {
                                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                                    {
                                        AddEmployeeToAFlight();
                                        break;
                                    }
                                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                                    {
                                        AddEmployee();
                                        break;
                                    }
                                case ConsoleKey.D3 or ConsoleKey.NumPad3:
                                    {
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
                            Console.WriteLine("Press 1 to add a flight to a plane");
                            Console.WriteLine("Press 2 to add a plane");
                            Console.WriteLine("Press 3 to remove a plane");
                            Console.WriteLine("Press ESC to exit the menu");
                            switch (key.Key)
                            {
                                case ConsoleKey.D1 or ConsoleKey.NumPad1:
                                    {
                                        AddFlightToPlane();
                                        break;
                                    }
                                case ConsoleKey.D2 or ConsoleKey.NumPad2:
                                    {
                                        AddPlane();
                                        break;
                                    }
                                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
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
                    default:
                        continue;
                }

            }
        }

        private void RemoveAPlane()
        {
            throw new NotImplementedException();
        }

        private void AddPlane()
        {
            throw new NotImplementedException();
        }

        private void AddFlightToPlane()
        {
            throw new NotImplementedException();
        }

        private void BanEmployee()
        {
            throw new NotImplementedException();
        }

        private void AddEmployee()
        {
            throw new NotImplementedException();
        }

        private void AddEmployeeToAFlight()
        {
            throw new NotImplementedException();
        }

        private void BanUser()
        {
            throw new NotImplementedException();
        }

        private void MakeAdmin()
        {
            throw new NotImplementedException();
        }

        private void RemoveAFlight()
        {
            throw new NotImplementedException();
        }

        private void EditAFlight()
        {
            throw new NotImplementedException();
        }

        private void AddAFlight()
        {
            throw new NotImplementedException();
        }
    }
}
