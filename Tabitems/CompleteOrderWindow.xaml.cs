using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Windows.Shapes;

namespace Tabitems
{
    /// <summary>
    /// Логика взаимодействия для CompleteOrderWindow.xaml
    /// </summary>
    public partial class CompleteOrderWindow : Window
    {

        bool[] serviceInfo= new bool[7];
        public class PointCoordinate
        {
            public float x;
            public float y;
            public PointCoordinate(float x_, float y_)
            {
                x = x_;
                y = y_;
            }

        }
        public CompleteOrderWindow(bool[] servInf, string orComment, int rating)
        {
            InitializeComponent();
            SliderDigit.Content = "0";
            servInf= serviceInfo;
            orComment=orderComment.Text;
            rating = Convert.ToInt32(SliderDigit.Content);
        }
        public void OnPaint(PointCoordinate[] p, int n)
        {

            double R = 5, r = 10;   // радиусы
            double alpha = 60;       // поворот
            double x0 = 20, y0 = 20; // центр


            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = k % 2 == 0 ? r : R;
                p[k] = new PointCoordinate((float)(x0 + l * Math.Cos(a)), (float)(y0 + l * Math.Sin(a)));
                a += da;
            }

        }

        private void AddStar()
        {
            Polygon p = new Polygon();
            int n = 5;  // число вершин
            PointCoordinate[] points = new PointCoordinate[2 * n + 1];
            OnPaint(points, n);
            PointCollection pc = new PointCollection();
            for (int i = 0; i < 11; i++)
            {
                Point point1 = new Point(points[i].x, points[i].y);
                pc.Add(point1);
            }
            p.Points = pc;
            p.Stroke = System.Windows.Media.Brushes.Gray;
            p.Fill = System.Windows.Media.Brushes.AliceBlue;
            MyPanel.Children.Add(p);
        }
        private void DeleteStar()
        {
            MyPanel.Children.RemoveAt(MyPanel.Children.Count - 1);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = sender as Slider;
            int sliderDigit = Convert.ToInt32(Math.Round(slider.Value, 0));

            if (sliderDigit - Convert.ToInt32(SliderDigit.Content) > 0)
            {
                for (int i = 0; i < sliderDigit - Convert.ToInt32(SliderDigit.Content); i++)
                    AddStar();
            }
            if (sliderDigit - Convert.ToInt32(SliderDigit.Content) < 0)
            {
                for (int i = 0; i < Convert.ToInt32(SliderDigit.Content) - sliderDigit; i++)
                    DeleteStar();
            }
            SliderDigit.Content = Math.Round(slider.Value, 0).ToString();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox ch = new CheckBox();
            ch = sender as CheckBox;
            if (ch.Content.ToString() == "колеровка по спектрофотометру")
                serviceInfo[3] = true;
            if (ch.Content.ToString() == "автомобиль на улице")
                serviceInfo[4] = true;
            if (ch.Content.ToString() == "доколеровка")
                serviceInfo[5] = true;
            if (ch.Content.ToString() == "слив по спектрофотометру")
                serviceInfo[6] = true;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox ch = new CheckBox();
            ch = sender as CheckBox;
            if (ch.Content.ToString() == "колеровка по спектрофотометру")
                serviceInfo[3] = false;
            if (ch.Content.ToString() == "автомобиль на улице")
                serviceInfo[4] = false;
            if (ch.Content.ToString() == "доколеровка")
                serviceInfo[5] = false;
            if (ch.Content.ToString() == "слив по спектрофотометру")
                serviceInfo[6] = false;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            serviceInfo[0] = false;
            serviceInfo[1] = false;
            serviceInfo[2] = false;

            RadioButton rb = new RadioButton();
            rb = sender as RadioButton;
            if (rb.Content.ToString() == "колеровка")
                serviceInfo[3] = true;
            if (rb.Content.ToString() == "приготовление по коду")
                serviceInfo[4] = true;
            if (rb.Content.ToString() == "транслак")
                serviceInfo[5] = true;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
