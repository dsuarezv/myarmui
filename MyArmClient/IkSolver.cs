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
        /// <param name="p">The point to move to</param>
        /// <param name="len1">Arm's link 1 length</param>
        /// <param name="len2">Arm's link 2 length</param>
        /// <returns>The angles of the solution for the inverse kinematics</returns>
        public static RobotAngles GetAnglesForXYZ(Point3 p, int len1, int len2)
        {
            double x = p.X;
            double y = p.Y;
            double z = p.Z;
            double l = Math.Sqrt(x * x + z * z);

            double a2 = len1 * len1;
            double c2 = len2 * len2;
            double a2c2 = len1 * len1 + len2 * len2;
            double arm2ac = 2 * len1 * len2;

            double y2z2 = l * l + y * y;
            double delta = Math.Atan2((double)y, (double)l) * RadiansToDegrees;
            double gamma = Math.Acos((a2 + y2z2 - c2) / (2 * len1 * Math.Sqrt(y2z2))) * RadiansToDegrees;
            double epsilon = Math.Acos((a2c2 - y2z2) / (arm2ac)) * RadiansToDegrees;

            return new RobotAngles()
            {
                A1 = Math.Atan2(z, x) * RadiansToDegrees - 90,
                A3 = 180 - delta - gamma - epsilon,
                A2 = delta + gamma
            };
        }
    }

    public struct IkData
    {
        public Point3 MiddlePoint;
        public Point3 TargetPoint;
        public double Angle1;
        public double Angle2;
        public double Angle3;
    }
}
