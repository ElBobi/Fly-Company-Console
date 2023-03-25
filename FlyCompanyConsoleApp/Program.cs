using FlyCompanyConsoleApp.Models;
using FlyCompanyConsoleApp.View;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FlyCompanyConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dbcontext = new FlyContext();
            dbcontext.Database.EnsureCreated();
            var startupView = new StartUpView();
            startupView.Run();
        }
    }
}