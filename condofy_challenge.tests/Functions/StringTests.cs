using condofy_challenge.Funtions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace condofy_challenge.tests.Functions
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        [DataRow("25:00")]
        [DataRow("10:70")]
        [DataRow(":")]
        [DataRow(":00")]
        [DataRow("00:")]
        public void ConvertInvalidStringHour(string hours)
        {
            var hour = StringFunctions.StringToTime(hours);
            Assert.IsNotNull(hour);
        }
    }
}
