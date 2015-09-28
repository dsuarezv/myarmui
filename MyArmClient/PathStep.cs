using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArmClient
{
    public class PathStep
    {
        /// <summary>
        /// Target position
        /// </summary>
        public Point3 Position { get; set; }
        
        /// <summary>
        /// Time to perform this step, in ms
        /// </summary>
        public Int16 Time { get; set; }

        public PathStep()
        { 
            // For the XmlSerializer
        }
    }
}
