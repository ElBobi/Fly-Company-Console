using FlyCompanyConsoleApp.Controller;
using FlyCompanyConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyCompanyTests
{
    [TestFixture]
    public class AdminTests
    {
        [Test]
        public void AddAFlight_WithValidData_ShouldSaveToDatabase()
        {
            // Arrange
            string fromDestination = "London";
            string toDestination = "New York";
            DateTime takeOffTime = DateTime.Now;
            DateTime landTime = DateTime.Now.AddHours(6);
            int planeId = 1;
            AdminController adminController = new AdminController();

            // Act
            adminController.AddAFlight(fromDestination, toDestination, takeOffTime, landTime, planeId);

            // Assert
            using (var context = new FlyContext())
            {
                Flight flight = context.Flights.FirstOrDefault(f => f.FromDestination == fromDestination && f.ToDestination == toDestination && f.TakeOffTime == takeOffTime && f.LandTime == landTime && f.PlaneId == planeId);
                Assert.IsNotNull(flight);
            }
        }

        [Test]
        public void RemoveAFlight_WithValidFlightId_ShouldRemoveFromDatabase()
        {
            // Arrange
            Flight flight = new Flight
            {
                FromDestination = "London",
                ToDestination = "New York",
                TakeOffTime = DateTime.Now,
                LandTime = DateTime.Now.AddHours(6),
                PlaneId = 1
            };
            using (var context = new FlyContext())
            {
                context.Flights.Add(flight);
                context.SaveChanges();
            }
            int flightId = flight.Id;
            AdminController adminController = new AdminController();

            // Act
            adminController.RemoveAFlight(flightId);

            // Assert
            using (var context = new FlyContext())
            {
                Flight removedFlight = context.Flights.FirstOrDefault(f => f.Id == flightId);
                Assert.IsNull(removedFlight);
            }
        }

        [Test]
        public void RemoveAFlight_WithInvalidFlightId_ShouldNotRemoveFromDatabase()
        {
            // Arrange
            int flightId = -1;
            AdminController adminController = new AdminController();

            // Act
            adminController.RemoveAFlight(flightId);

            // Assert
            using (var context = new FlyContext())
            {
                int count = context.Flights.Count();
                Assert.AreEqual(0, count);
            }
        }
    }
}
