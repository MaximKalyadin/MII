﻿using Mii_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mii_3
{
    /// <summary>
    /// Логика взаимодействия для VR.xaml
    /// </summary>
    public partial class VR : Window
    {
        List<View> views = new List<View>();
        List<int> vr = new List<int>();
        public VR(List<View> views)
        {
            InitializeComponent();
            this.views = views;

            Paint();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            vr.Add(int.Parse(Add_textbox.Text));
            Paint();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int n = int.Parse(Generate_textbox.Text);
            for (int i = 0; i < n; i++)
            {
                vr.Add(rnd.Next(0, 101));
            }

            Paint();
        }

        public void Paint()
        {
            listbox.ItemsSource = null;
            listbox.ItemsSource = vr;
            canvas.Children.Clear();

            Line x = new Line { X1 = 20, Y1 = 400, X2 = 20, Y2 = 20, Stroke = Brushes.Black };
            canvas.Children.Add(x);
            Line y = new Line { X1 = 20, Y1 = 400, X2 = 750, Y2 = 400, Stroke = Brushes.Black };
            canvas.Children.Add(y);
            Label label1 = new Label { Content = "0" };
            canvas.Children.Add(label1);
            Canvas.SetBottom(label1, 20);
            Canvas.SetLeft(label1, 17);
            Label label2 = new Label { Content = vr.Count };
            canvas.Children.Add(label2);
            Canvas.SetBottom(label2, 20);
            Canvas.SetLeft(label2, 750);
            Label label3 = new Label { Content = 100 };
            canvas.Children.Add(label3);

            Func<int, int> tX = (xx) => 20 + xx * 750 / (vr.Count > 1 ? vr.Count - 1 : 1);
            Func<double, int> tY = (yy) => (int)(400 - (yy * 380 / 100));

            for (int i = 0; i < 100; i++)
            {
                if (tY(i) != tY(i - 1))
                {
                    Line line = new Line
                    {
                        X1 = tX(0),
                        Y1 = tY(i),
                        X2 = tX(vr.Count > 1 ? vr.Count - 1 : 1),
                        Y2 = tY(i),
                        Stroke = GetBackground(i)
                    };

                    canvas.Children.Add(line);
                }
            }

            canvas.UpdateLayout();
        }

        private SolidColorBrush GetBackground(int y)
        {
            List<View> fs = views.Where(req => req.M(y) > 0).ToList();

            if (fs.Count == 0)
            {
                return new SolidColorBrush(Color.FromArgb(75, 255, 255, 255));
            }

            System.Drawing.Color c = System.Drawing.Color.FromName(fs[0].Color);

            for (int i = 1; i < fs.Count; i++)
            {
                System.Drawing.Color nc = System.Drawing.Color.FromName(fs[i].Color);

                int r = Math.Min((c.R + nc.R) / 2, 255);
                int g = Math.Min((c.G + nc.G) / 2, 255);
                int b = Math.Min((c.B + nc.B) / 2, 255);

                c = System.Drawing.Color.FromArgb(r, g, b);
            }

            return new SolidColorBrush(Color.FromArgb(75, c.R, c.G, c.B));
        }


    }
}