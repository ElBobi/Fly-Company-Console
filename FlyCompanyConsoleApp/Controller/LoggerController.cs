using FlyCompanyConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCompanyConsoleApp.Controller
{
    public class LoggerController
    {

        public LoggerController() { }   
        public bool Register()
        {
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            ConfirmPassword(password);
            Console.WriteLine("First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Gender: (M or F)");
            string gender = Console.ReadLine();
            if (gender != "M" && gender != "F")
            {
                CheckGender(gender);
            }
                
            Console.WriteLine("Phone number:");
            string phoneNumber = Console.ReadLine();

            // Check for null data
            var collection = new List<string> { email,username,password,firstName,lastName,gender,phoneNumber};
            if (collection.Any(x => x == String.Empty))
            {
                Console.Clear();
                Console.WriteLine("Please fill all the necessary columns!");
                return false;
            }    

            var user = new User(email, username, password, firstName, lastName, gender, phoneNumber);
            using (var dbcontext = new FlyContext())
            {

                // Check if the user exists
                if (dbcontext.Users.Any(u => u.Username == user.Username))
                {
                    Console.WriteLine("User with this username already exists.");
                    return false;
                }

                if (dbcontext.Users.Any(u => u.Email == user.Email))
                {
                    Console.WriteLine("User with this email already exists.");
                    return false;
                }

                
                // Add the user to the database
                dbcontext.Users.Add(user);
                dbcontext.SaveChanges();
                Console.WriteLine("User registered successfully!");
                return true;
            }
        }

        private void CheckGender(string gender)
        {
            Console.WriteLine("Please enter a valid gender:");
            while (true)
            {
                gender = Console.ReadLine();
                if (gender != "M" && gender != "F")
                {
                    break;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }

        public bool Login(string username, string password)
        {
            using (var dbcontext = new FlyContext())
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) 
                {
                    Console.WriteLine("Please fill all the necessary columns!\n");
                    return false;
                }
                
                if (dbcontext.Users.Any(u => u.Username == username))
                {
                    var user = dbcontext.Users.FirstOrDefault(u => u.Username == username);
                    if (user.Password != password)
                    {
                        Console.WriteLine("There is no combination of this username and password!\n");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("There is no combination of this username and password!\n");
                    return false;
                }
                Console.WriteLine($"Welcome {username}!\n");
                LoggerUser.loggerUser = dbcontext.Users.FirstOrDefault(x => x.Username == username);
                return true;
            }
        }
        public void ConfirmPassword(string password)
        {
            Console.WriteLine("Confirm password");
            while (true)
            {
                string confirmPassword = Console.ReadLine();
                if (password == confirmPassword)
                {
                    break;
                }
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }
    }
}
