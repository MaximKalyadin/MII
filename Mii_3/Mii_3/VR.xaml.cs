using Mii_3.Models;
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
        int edge;
        double prediction = 1.2;
        List<int> forecasted = new List<int>();
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
                if (vr.Count == 0)
                {
                    vr.Add(rnd.Next(0, 101));
                    continue;
                }
                else
                {
                    int k = rnd.Next(-20, 21);

                    if (vr[vr.Count - 1] + k > 100 || vr[vr.Count - 1] + k < 0)
                    {
                        i--;
                        continue;
                    }

                    vr.Add(vr[vr.Count - 1] + k);
                }
            }

            Paint();
        }

        public void Paint()
        {
            Forecast();

            listbox.ItemsSource = null;
            listbox.ItemsSource = vr;

            edge = (int)(forecasted.Count / prediction) - 1;

            canvas.Children.Clear();

            Line x = new Line { X1 = 20, Y1 = 400, X2 = 20, Y2 = 20, Stroke = Brushes.Black };
            canvas.Children.Add(x);
            Line y = new Line { X1 = 20, Y1 = 400, X2 = 900, Y2 = 400, Stroke = Brushes.Black };
            canvas.Children.Add(y);
            Label label1 = new Label { Content = "0" };
            canvas.Children.Add(label1);
            Canvas.SetBottom(label1, 20);
            Canvas.SetLeft(label1, 17);
            Label label2 = new Label { Content = forecasted.Count };
            canvas.Children.Add(label2);
            Canvas.SetBottom(label2, 20);
            Canvas.SetLeft(label2, 900);
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
                        X2 = tX(forecasted.Count > 1 ? forecasted.Count - 1 : 1),
                        Y2 = tY(i),
                        StrokeThickness = 3,
                        Stroke = GetBackground(i)
                    };

                    canvas.Children.Add(line);
                }
            }

            /*Polyline polyline = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            PointCollection points = new PointCollection();
            for (int i = 0; i < vr.Count; i++)
            {
                Point point = new Point(tX(i), tY(vr[i]));
                points.Add(point);
            }
            polyline.Points = points;
            canvas.Children.Add(polyline);*/

            Line edgeL = new Line { X1 = tX(edge), Y1 = tY(0), X2 = tX(edge), Y2 = tY(100), Stroke = Brushes.Black };
            canvas.Children.Add(edgeL);

            /*for (int i = 1; i < vr.Count; i++)
            {
                Line line = new Line { X1 = tX(i - 1), Y1 = tY(vr[i - 1]), X2 = tX(i), Y2 = tY(vr[i]), Stroke = GetTrendBrush(i) };
                canvas.Children.Add(line);
            }*/

            for (int i = 1; i < forecasted.Count; i++)
            {
                Line line = new Line { X1 = tX(i - 1), Y1 = tY(forecasted[i - 1]), X2 = tX(i), Y2 = tY(forecasted[i]), Stroke = GetTrendBrush(i) };
                canvas.Children.Add(line);
            }
        }

        private SolidColorBrush GetTrendBrush(int i)
        {
            List<(int start, int end)> vs = new List<(int start, int end)>
            {
                (0, 0)
            };

            Func<int, View> GetFunction = (y) =>
            {
                double max = views.Max(req => req.Function(y));
                if (max == 0)
                {
                    return null;
                }
                View view = views.First(req => req.Function(y) == max);
                return view;
            };

            Func<int, int> index = (x) =>
            {
                for (int k = 0; k < vs.Count; k++)
                {
                    if (x >= vs[k].start && x <= vs[k].end)
                    {
                        return k;
                    }
                }
                return 0;
            };

            for (int k = 1; k < 100; k++)
            {
                View currentF = GetFunction(k);
                View prevF = GetFunction(k - 1);
                int currentCount = (views.Where(req => req.Function(k) > 0).Count());
                int prevCount = (views.Where(req => req.Function(k - 1) > 0).Count());
                if (currentCount == prevCount)
                {
                    vs[vs.Count - 1] = (vs[vs.Count - 1].start, k);
                }
                else
                {
                    vs.Add((k, k));
                }
            }

            int current = index(forecasted[i]);
            int prev = index(forecasted[i - 1]);

            if (current > prev)
            {
                if (current - prev >= 3)
                {
                    return Brushes.Aqua;
                }
                return Brushes.Green;
            }
            if (current < prev)
            {
                if (prev - current >= 3)
                {
                    return Brushes.Yellow;
                }
                return Brushes.Red;
            }

            return Brushes.Black;
        }

        private SolidColorBrush GetBackground(int y)
        {
            List<View> fs = views.Where(req => req.Function(y) > 0).ToList();

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


        private void Forecast()
        {
            Random rnd = new Random();

            forecasted = new List<int>();
            forecasted.AddRange(vr);

            List<Brush> brushes = new List<Brush>();
            for (int i = 1; i < forecasted.Count; i++)
            {
                brushes.Add(GetTrendBrush(i));
            }
                
            Dictionary<Brush, Dictionary<Brush, int>> dict = new Dictionary<Brush, Dictionary<Brush, int>>();

            for (int i = 1; i < brushes.Count; i++)
            {
                Brush prev = brushes[i - 1];
                Brush current = brushes[i];

                if (!dict.ContainsKey(prev))
                {
                    dict.Add(prev, new Dictionary<Brush, int>());
                }
                    

                if (!dict[prev].ContainsKey(current))
                {
                    dict[prev].Add(current, 1);
                }
                else
                {
                    dict[prev][current]++;
                }
            }

            List<(int start, int end)> fs = new List<(int start, int end)>();
            fs.Add((1, 1));

            Func<int, View> GetFunction = (y) =>
            {
                double max = views.Max(req => req.Function(y));
                if (max == 0)
                {
                    return null;
                }
                View view = views.First(req => req.Function(y) == max);
                return view;
            };

            for (int k = 2; k < 100; k++)
            {
                View currentF = GetFunction(k);
                View prevF = GetFunction(k - 1);
                int currentCount = (views.Where(req => req.Function(k) > 0).Count());
                int prevCount = (views.Where(req => req.Function(k - 1) > 0).Count());
                if (currentCount == prevCount)
                {
                    fs[fs.Count - 1] = (fs[fs.Count - 1].start, k);
                }
                else
                {
                    fs.Add((k, k));
                }
            }

            Func<int, int> index = (x) =>
            {
                for (int k = 0; k < fs.Count; k++)
                {
                    if (x >= fs[k].start && x <= fs[k].end)
                    {
                        return k;
                    }
                } 
                return 0;
            };

            Func<int, int> center = (i) => fs[i].start + (fs[i].end - fs[i].start) / 2;

            int n = (int)(vr.Count * prediction - vr.Count);

            int last = vr.Count > 0 ? vr[vr.Count - 1] : 0;
            double maxWrong = 0;

            for (int i = 0; i < n; i++)
            {
                int prevIndex = index(forecasted[forecasted.Count - 1]);
                List<Brush> variants = new List<Brush>();
                Brush pb = brushes[brushes.Count - 1];

                foreach (Brush b in dict[pb].Keys)
                {
                    for (int j = 0; j < dict[pb][b]; j++)
                    {
                        variants.Add(b);
                    } 
                }

                Brush trend = null;
                int m = 0;
                while (true)
                {
                    trend = variants[rnd.Next(0, variants.Count)];

                    if (trend == Brushes.Red)
                    {
                        m = -1;
                    }
                    else if (trend == Brushes.Green)
                    {
                        m = 1;
                    }
                    else if (trend == Brushes.Blue)
                    {
                        m = 0;
                    }
                    if (prevIndex + m >= 0 && prevIndex + m < fs.Count)
                    {
                        break;
                    } 
                }

                int currentIndex = prevIndex + m;
                int c = center(currentIndex);

                forecasted.Add(c);
                brushes.Add(trend);

                int k = 0;
                while (true)
                {
                    k = rnd.Next(-20, 21);
                    if (last + k <= 100 || last + k >= 0)
                    {
                        break;
                    }
                }

                last += k;

                double wrong = Math.Abs((double)(forecasted[forecasted.Count - 1] - last) / forecasted[forecasted.Count - 1]);
                maxWrong = Math.Max(maxWrong, wrong);
            }

            if (vr.Count > 0)
            {
                MessageBox.Show(maxWrong.ToString(), "Oшибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
