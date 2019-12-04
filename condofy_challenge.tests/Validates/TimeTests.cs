using condofy_challenge.Validates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace condofy_challenge.tests.Validates
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void ValidateHourWithOutValue()
        {
            var valid_hour = TimerValidate.isHour(null);
            Assert.IsFalse(valid_hour);
        }

        [TestMethod]
        [DataRow("25:00")]
        [DataRow("10:70")]
        [DataRow(":")]
        [DataRow(":00")]
        [DataRow("00:")]
        public void ValidateHourWithInvalidHour(string hour)
        {
            var valid_hour = TimerValidate.isHour(hour);
            Assert.IsFalse(valid_hour);
        }
    }
}
