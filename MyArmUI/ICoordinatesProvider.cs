using MyArmClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArmUI
{
    public interface ICoordinatesProvider
    {
        Point3 GetCoordinates();
    }
}
