using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArmClient
{
    public class Point3
    {
        public double X;
        public double Y;
        public double Z;

        public Point3() { }

        public Point3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return String.Format("{0:0}, {1:0}, {2:0}", X, Y, Z);
        }

        public Point3 Clone()
        {
            return new Point3() { X = this.X, Y = this.Y, Z = this.Z };
        }
    }
}
