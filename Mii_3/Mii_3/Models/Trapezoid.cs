using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mii_3.Models
{
    public class Trapezoid
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double d { get; set; }

        public Trapezoid(string Name, string Color, string a, string b, string c, string d)
        {
            this.Name = Name;
            this.Color = Color;
            this.a = double.Parse(a);
            this.b = double.Parse(b);
            this.c = double.Parse(c);
            this.d = double.Parse(d);
        }
    }
}
