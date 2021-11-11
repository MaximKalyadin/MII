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

        public double M(int x)
        {
            if (x > a && x < b)
            {
                double y = (double)(x - a) / (double)(b - a);
                return y;
            }
            else if (x > b && x < c)
            {
                double y = (double)(c - x) / (double)(c - b);
                return y;
            }
            else
            {
                return x == b ? 1 : 0;
            }
        }
    }
}