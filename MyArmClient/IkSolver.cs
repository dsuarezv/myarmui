using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArmClient
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Coordinate system is as follows:
    /// * +X goes right
    /// * +Z moves away from the robot
    /// * +Y goes upward
    /// 
    /// X,Z form the table plane. Y goes up and down the table.
    /// </remarks>
    public class IkSolver
    {
        private const double RadiansToDegrees = 180 / Math.PI;

        /// <summary>
        /// Calculates inverse kinematics for location x, y, z. Outputs the angles of the joints to reach that position. 
        /// </summary>
        /// <param name="x">Desired X coordinate</param>
        /// <param name="y">Desired Y coordinate</param>
        /// <param name="z">Desired Z coordinate</param>
        /// <param name="lenA">Arm's link 1 length</param>
        /// <param name="lenC">Arm's link 2 length</param>
        /// <param name="angle1">Solution angle 1 (Rotation) in degrees</param>
        /// <param name="angle2">Solution angle 2 (Right servo) in degrees</param>
        /// <param name="angle3">Solution angle 3 (Left servo) in degrees</param>
        public static void GetAnglesForXYZ(int x, int y, int z, int lenA, int lenC, out double angle1, out double angle2, out double angle3)
        {
            double a2 = lenA * lenA;
            double c2 = lenC * lenC;
            double a2c2 = lenA * lenA + lenC * lenC;
            double arm2ac = 2 * lenA * lenC;


            double y2z2 = y * y + z * z;
            double delta = Math.Atan2((double)z, (double)x) * RadiansToDegrees;
            double gamma = Math.Acos((a2 + y2z2 - c2) / (2 * lenA * Math.Sqrt(y2z2))) * RadiansToDegrees;
            double epsilon = Math.Acos((a2c2 - y2z2) / (arm2ac)) * RadiansToDegrees;


            angle1 = Math.Atan2(y, x) * RadiansToDegrees;
            angle2 = 180 - delta - gamma - epsilon;
            angle3 = delta + gamma;
        }
    }
}
