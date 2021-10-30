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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public View View;

        public Edit(View View = null)
        {
            InitializeComponent();
            if (View != null)
            {
                this.View = View;

                if (this.View.trapezoid != null)
                {
                    name.Text = this.View.Name;
                    color.Text = this.View.Color;
                    a.Text = this.View.trapezoid.a.ToString();
                    b.Text = this.View.trapezoid.b.ToString();
                    c.Text = this.View.trapezoid.c.ToString();
                    d.Text = this.View.trapezoid.d.ToString();

                    name_triangle.Text = this.View.Name;
                    color_triangle.Text = this.View.Color;
                    a_triangle.Text = this.View.trapezoid.a.ToString();
                    b_triangle.Text = this.View.trapezoid.b.ToString();
                    c_triangle.Text = this.View.trapezoid.c.ToString();

                    tab_control.SelectedIndex = 0;
                }
                else
                {
                    name_triangle.Text = this.View.Name;
                    color_triangle.Text = this.View.Color;
                    a_triangle.Text = this.View.triangle.a.ToString();
                    b_triangle.Text = this.View.triangle.b.ToString();
                    c_triangle.Text = this.View.triangle.c.ToString();

                    name.Text = this.View.Name;
                    color.Text = this.View.Color;
                    a.Text = this.View.triangle.a.ToString();
                    b.Text = this.View.triangle.b.ToString();
                    c.Text = this.View.triangle.c.ToString();

                    tab_control.SelectedIndex = 1;
                }
            }
        }

        private void saveTrapezoid_triangle_Click(object sender, RoutedEventArgs e)
        {
            Triangle tr = new Triangle(name_triangle.Text, color_triangle.Text, a_triangle.Text, b_triangle.Text, c_triangle.Text);
            View = new View
            {
                Name = tr.Name,
                Color = tr.Color,
                trapezoid = null,
                triangle = tr
            };
            DialogResult = true;
        }

        private void saveTrapezoid_Click(object sender, RoutedEventArgs e)
        {
            Trapezoid tr = new Trapezoid(name.Text, color.Text, a.Text, b.Text, c.Text, d.Text);
            View = new View
            {
                Name = tr.Name,
                Color = tr.Color,
                trapezoid = tr,
                triangle = null
            };
            DialogResult = true;
        }
    }
}
