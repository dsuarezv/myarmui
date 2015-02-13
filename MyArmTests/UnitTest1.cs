using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyArmClient;

namespace MyArmTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MapTest()
        {
            var a = AxisCalibration.Map(10, 5, 15, 20, 40);
            Assert.AreEqual(a, 30);
        }
    }
}
