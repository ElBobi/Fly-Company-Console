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
            var startupView = new StartUpView();
            startupView.Run();
        }
    }
}