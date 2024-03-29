﻿using System;
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

        public double M(int x)
        {
            if (x > a && x < b)
            {
                double y = (double)(x - a) / (double)(b - a);
                return y;
            }
            else if (x >= b && x <= c)
            {
                return 1;
            }
            else if (x > c && x < d)
            {
                double y = (double)(d - x) / (double)(d - c);
                return y;
            }
            else
            {
                return 0;
            }
        }
    }
}
