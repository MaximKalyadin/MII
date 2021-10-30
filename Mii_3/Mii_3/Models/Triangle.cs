using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mii_3.Models
{
    public class Triangle
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }

        public Triangle(string Name, string Color, string a, string b, string c)
        {
            this.Name = Name;
            this.Color = Color;
            this.a = double.Parse(a);
            this.b = double.Parse(b);
            this.c = double.Parse(c);
        }
    }
}