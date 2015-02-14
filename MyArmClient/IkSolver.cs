using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArmClient
{
    public class IkSolver
    {
        private const double RadiansToDegrees = 180 / Math.PI;

        public static void GetAnglesForXYZ(int x, int y, int z, int armA, int armC, out double angle1, out double angle2, out double angle3)
        {
            double armA2 = armA * armA;
            double armC2 = armC * armC;
            double armA2C2 = armA * armA + armC * armC;
            double arm2AC = 2 * armA * armC;


            double y2z2 = y * y + z * z;
            double delta = Math.Atan2((double)z, (double)x) * RadiansToDegrees;
            double gamma = Math.Acos((armA2 + y2z2 - armC2) / (2 * armA * Math.Sqrt(y2z2))) * RadiansToDegrees;
            double epsilon = Math.Acos((armA2C2 - y2z2) / (arm2AC)) * RadiansToDegrees;


            angle1 = 180 - delta - gamma - epsilon;
            angle2 = delta + gamma;
            angle3 = Math.Atan2(y, x) * RadiansToDegrees;
        }
    }
}
