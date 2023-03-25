using FlyCompanyConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlyCompanyConsoleApp.Controller
{
    public class LoggerController
    {
        public LoggerController() { }

        // Register method for creating a new user account
        public bool Register()
        {
            Console.WriteLine("Email:");
            string email = Console.ReadLine();
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();

            // Use the ConfirmPassword method to make sure the user enters the password correctly
            ConfirmPassword(password);

            Console.WriteLine("First Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Gender: (Male, Female, or Unknown)");
            string gender = Console.ReadLine();

            // Use the CheckGender method to validate the gender input
            if (gender != "Male" && gender != "Female" && gender != "Unknown")
            {
                CheckGender(gender);
            }

            Console.WriteLine("Phone number:");
            string phoneNumber = Console.ReadLine();

            // Check for null or empty data
            if (string.IsNullOrEmpty(email) ||
    string.IsNullOrEmpty(username) ||
    string.IsNullOrEmpty(password) ||
    string.IsNullOrEmpty(firstName) ||
    string.IsNullOrEmpty(lastName) ||
    string.IsNullOrEmpty(gender) ||
    string.IsNullOrEmpty(phoneNumber))
            {
                Console.Clear();
                Console.WriteLine("Please fill all the necessary columns!");
                return false;
            }

            var user = new User(email, username, password, firstName, lastName, gender, phoneNumber);
            using (var dbcontext = new FlyContext())
            {
                // Check if the user exists by email or username
                if (dbcontext.Users.Any(u => u.Username == user.Username))
                {
                    Console.WriteLine("A user with this username already exists.");
                    return false;
                }

                if (dbcontext.Users.Any(u => u.Email == user.Email))
                {
                    Console.WriteLine("A user with this email already exists.");
                    return false;
                }

                // Add the user to the database and save changes
                dbcontext.Users.Add(user);
                dbcontext.SaveChanges();
                Console.Clear();
                Console.WriteLine("User registered successfully!");
                return true;
            }
        }

        // Login method for logging in an existing user
        public bool Login(string username, string password)
        {
            using (var dbcontext = new FlyContext())
            {
                var user = dbcontext.Users.FirstOrDefault(u => u.Username == username);

                if (user == null || user.Password != password)
                {
                    Console.WriteLine("There is no combination of this username and password!\n");
                    return false;
                }

                Console.Clear();
                Console.WriteLine($"Welcome {username}!\n");
                LoggerUser.loggerUser = user;
                return true;
            }
        }

        // Method to confirm password
        public void ConfirmPassword(string password)
        {
            Console.WriteLine("Confirm password");

            // Loop until the user confirms the password
            while (true)
            {
                string confirmPassword = Console.ReadLine();

                // If the confirmation matches the original password, exit the loop
                if (password == confirmPassword)
                {
                    break;
                }

                // Otherwise, clear the console and prompt the user again
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }
        private void CheckGender(string gender)
        {
            Console.WriteLine("Please enter a valid gender:");

            // Loop until the user enters a valid gender
            while (true)
            {
                gender = Console.ReadLine();

                // If the gender is valid, exit the loop
                if (gender == "Male" || gender == "Female" || gender == "Unknown")
                {
                    break;
                }

                // Otherwise, clear the console and prompt the user again
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }
    }
}
