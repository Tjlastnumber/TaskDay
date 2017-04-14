using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskDay.Core;

namespace TaskDay.Test
{
    [TestClass]
    public class ToRunUntilStopTest
    {
        [TestMethod]
        public void ToRunUntilStop_Test()
        {
            var input = new DateTime(2017, 1, 1);
            var expected = new DateTime(2017, 1, 1, 0, 0, 30);

            var schedule = new NotifySchedule();
            schedule.ToRunEvery(new TimeSpan(0, 0, 30));
            var actual = schedule.CalculateNextRun(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
