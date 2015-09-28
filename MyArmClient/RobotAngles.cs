using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArmClient
{
    public class RobotAngles
    {
        public double A1;       // Rotation axis angle
        public double A2;       // Right axis angle
        public double A3;       // Left axis angle
        public double A4;       // Effector axis angle
        public double A5;       // NOT USED YET
        public double A6;       // NOT USED YET

        public bool IsNaN()
        {
            return (double.IsNaN(A2) || double.IsNaN(A3) || double.IsNaN(A1) || double.IsNaN(A4) || double.IsNaN(A5) || double.IsNaN(A6));
        }
    }
}
