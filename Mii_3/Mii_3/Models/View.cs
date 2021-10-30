using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Mii_3.Models
{
    public class View
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public Trapezoid trapezoid { get; set; }
        public Triangle triangle { get; set; }
        public PathGeometry pathGeometry { get; set; }
    }
}
