using FlyCompanyConsoleApp.Controller;
using FlyCompanyConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCompanyConsoleApp.View
{
    public class StartUpView
    {
        private LoggerController loggerController;
        public StartUpView()
        {
            loggerController = new LoggerController();
        }

        public void Run()
        {

            while (true)
            {
                Console.WriteLine("Welcome to Fly Company!");
                Console.WriteLine("Press '1' if you want to log into the system");
                Console.WriteLine("Press '2' if you want to register ");
                Console.WriteLine("Press 'ESC' to terminate");

                ConsoleKeyInfo key = Console.ReadKey(); // Terminate the program
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            return;
                        }

                    case ConsoleKey.D2:
                        {
                            Register();
                            break;
                        }

                    case ConsoleKey.D1:
                        {
                            Login();
                            FlightView fv = new FlightView();
                            fv.Run();

                        }
                        break;
                    default: // Any other key
                        Console.Clear();
                        continue;
                }
            }

        }
        public void Login()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Password: ");
                string password = Console.ReadLine();
                if (loggerController.Login(username, password))
                {
                    break;
                }
            }

        }
        public void Register()
        {
            Console.Clear();
            while (true)
            {
                if (loggerController.Register())
                {
                    break;
                }
            }
        }


    }
}
