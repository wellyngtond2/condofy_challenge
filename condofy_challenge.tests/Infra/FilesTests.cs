using condofy_challenge.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace condofy_challenge.tests.Infra
{
    [TestClass]
    public class FilesTests
    {
        [TestMethod]
        public void GetAvailableRestaurantWithNullHour()
        {
            var restaurants = Files.GetAvailableRestaurant(null);
            Assert.IsNotNull(restaurants);
        }

        [TestMethod]
        [DataRow("25:00")]
        [DataRow("10:70")]
        [DataRow(":")]
        [DataRow(":00")]
        [DataRow("00:")]
        public void GetAvailableRestaurantWithInvalidHour(string hours)
        {
            var restaurants = Files.GetAvailableRestaurant(hours);
            Assert.IsNotNull(restaurants);
        }

        [TestMethod]
        public void AddRestaurantWithOutLineFiele()
        {
            var restaurant = Files.addRestaurant(null, DateTime.Now.TimeOfDay);
            Assert.IsNotNull(restaurant);
        }

        [TestMethod]
        [DataRow("Mac,15:00-40:59")]
        [DataRow("Mac,15:00-23:80")]
        [DataRow("Mac,")]
        public void AddRestaurantWithInvalidHourInLineFile(string line)
        {
            var restaurant = Files.addRestaurant(line, DateTime.Now.TimeOfDay);
            Assert.IsNotNull(restaurant);
        }

        [TestMethod]
        public void AddRestaurantWithOutNameInLineFile()
        {
            var restaurant = Files.addRestaurant(", 15:00 - 23:80", DateTime.Now.TimeOfDay);
            Assert.IsNotNull(restaurant);
        }
    }
}
