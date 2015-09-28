using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyArmClient;
using AngleChecker;

namespace MyArmTests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void MapTest()
        {
            var a = AxisCalibration.Map(10, 5, 15, 20, 40);
            Assert.AreEqual(a, 30);
        }

        [TestMethod]
        public void IkTest1()
        {
            var angles = IkSolver.GetAnglesForXYZ(new Point3(100, 70, 125), 148, 161);

            //double b2, b3;
            //Form1.xyControl_InverseKinematicsSolver(125, 70, 148, 161, out b2, out b3);

            //Assert.AreEqual(a2, b2, 0.0001);
            //Assert.AreEqual(a3, b3, 0.0001);
        }

    }
}
