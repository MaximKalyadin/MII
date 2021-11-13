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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mii_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    ///

    public partial class MainWindow : Window
    {
        private List<View> List_view = new List<View>();

        public MainWindow()
        {
            InitializeComponent();
            Triangle triangle = new Triangle("First", "Red", "5", "30", "60");
            View view1 = new View
            {
                Name = triangle.Name,
                Color = triangle.Color,
                triangle = triangle,
                trapezoid = null
            };
            List_view.Add(view1);
            Paint();
        }

        private void buttonCreate_Click(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit();
            if (edit.ShowDialog() == true)
            {
                List_view.Add(edit.View);
                Paint();
            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            View view = listBox.SelectedItem as View;
            if (view != null)
            {
                Edit edit = new Edit(view);
                if (edit.ShowDialog() == true)
                {
                    List_view.Remove(view);
                    List_view.Add(edit.View);
                    Paint();
                }
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            View view = listBox.SelectedItem as View;
            List_view.Remove(view);
            Paint();
        }

        private void Paint()
        {
            listBox.ItemsSource = null;
            listBox.ItemsSource = List_view;
            canvas.Children.Clear();

            Line x = new Line { X1 = 20, Y1 = 400, X2 = 20, Y2 = 20, Stroke = Brushes.Black };
            canvas.Children.Add(x);
            Line y = new Line { X1 = 20, Y1 = 400, X2 = 500, Y2 = 400, Stroke = Brushes.Black };
            canvas.Children.Add(y);
            Label label1 = new Label { Content = "0" };
            canvas.Children.Add(label1);
            Canvas.SetBottom(label1, 20);
            Canvas.SetLeft(label1, 17);
            Label label2 = new Label { Content = "100" };
            canvas.Children.Add(label2);
            Canvas.SetBottom(label2, 20);
            Canvas.SetLeft(label2, 500);

            foreach (var el in List_view)
            {
                if (el.trapezoid != null)
                {
                    PathFigure pathFigure = new PathFigure
                    {
                        StartPoint = new Point(el.trapezoid.a * 5, 400)
                    };

                    LineSegment lineSegment1 = new LineSegment
                    {
                        Point = new Point(el.trapezoid.b * 5, 50)
                    };
                    LineSegment lineSegment2 = new LineSegment
                    {
                        Point = new Point(el.trapezoid.c * 5, 50)
                    };
                    LineSegment lineSegment3 = new LineSegment
                    {
                        Point = new Point(el.trapezoid.d * 5, 400)
                    };

                    PathSegmentCollection pathSegments = new PathSegmentCollection
                    {
                        lineSegment1,
                        lineSegment2,
                        lineSegment3
                    };

                    pathFigure.Segments = pathSegments;

                    PathFigureCollection pathFigures = new PathFigureCollection()
                    {
                        pathFigure
                    };

                    PathGeometry pathGeometry = new PathGeometry
                    {
                        Figures = pathFigures
                    };

                    el.pathGeometry = pathGeometry;

                    System.Drawing.Color one = System.Drawing.Color.FromName(el.Color);
                    Brush brush = new SolidColorBrush(Color.FromRgb(one.R, one.G, one.B));
                    Path path = new Path()
                    {
                        Stroke = brush,
                        StrokeThickness = 1,
                        Data = pathGeometry
                    };

                    canvas.Children.Add(path);
                } 
                else
                {

                    PathFigure pathFigure = new PathFigure
                    {
                        StartPoint = new Point(el.triangle.a * 5, 400)
                    };

                    LineSegment lineSegment1 = new LineSegment
                    {
                        Point = new Point(el.triangle.b * 5, 50)
                    };
                    LineSegment lineSegment2 = new LineSegment
                    {
                        Point = new Point(el.triangle.c * 5, 400)
                    };

                    PathSegmentCollection pathSegments = new PathSegmentCollection
                    {
                        lineSegment1,
                        lineSegment2
                    };

                    pathFigure.Segments = pathSegments;

                    PathFigureCollection pathFigures = new PathFigureCollection()
                    {
                        pathFigure
                    };

                    PathGeometry pathGeometry = new PathGeometry
                    {
                        Figures = pathFigures
                    };

                    el.pathGeometry = pathGeometry;

                    System.Drawing.Color one = System.Drawing.Color.FromName(el.Color);
                    Brush brush = new SolidColorBrush(Color.FromRgb(one.R, one.G, one.B));
                    Path path = new Path()
                    {
                        Stroke = brush,
                        StrokeThickness = 1,
                        Data = pathGeometry
                    };

                    canvas.Children.Add(path);
                }
            }
        }

        private void buttonUnit_Click(object sender, RoutedEventArgs e)
        {
            View first = (View)listBox.SelectedItems[0];
            View second = (View)listBox.SelectedItems[1];

            CombinedGeometry cg = new CombinedGeometry(GeometryCombineMode.Union, first.pathGeometry, second.pathGeometry);

            Path path = new Path()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Data = cg
            };
            canvas.Children.Add(path);
        }

        private void buttomVr_Click(object sender, RoutedEventArgs e)
        {
            VR vR = new VR(List_view);
            vR.Show();
        }
    }
}
