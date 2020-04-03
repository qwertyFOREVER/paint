using ColorPickerWPF;
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

namespace paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WriteableBitmap Paint = BitmapFactory.New(652,334);
        WriteableBitmap Buf;
        Point point;
        int tool = 1, thickness = 1;
        Color color = Colors.Black;
        Color ColorEnt = Colors.Black;
        bool isDrawable = false;
        public MainWindow()
        {
            InitializeComponent();
            img.Source = Paint;
            Paint.Clear(Colors.White);
        }

        private void img_move(object sender, MouseEventArgs e)
        {
            if (isDrawable)
            {
                Point P = e.GetPosition(img);
                Paint = Buf.Clone();
                img.Source = Paint;
                switch (tool)
                {
                    case 1:
                        Paint.DrawLine((int)point.X, (int)point.Y, (int)P.X, (int)P.Y, color);
                        point = e.GetPosition(img);
                        Buf = Paint.Clone();
                        break;
                    case 2:
                        Paint.DrawLineAa((int)point.X, (int)point.Y, (int)P.X, (int)P.Y, color, thickness);
                        break;
                    case 3:
                        Paint.DrawEllipse((int)point.X, (int)point.Y, (int)P.X, (int)P.Y, color);
                        break;

                }
            }
        }

        private void img_down(object sender, MouseButtonEventArgs e)
        {
            Buf = Paint.Clone();
            point = e.GetPosition(img);
            isDrawable = true;
        }

        private void img_up(object sender, MouseButtonEventArgs e)
        {
            isDrawable = false;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Paint.Clear(Colors.White);
        }

        private void Pen_Click(object sender, RoutedEventArgs e)
        {
            tool = 1;
            color = ColorEnt;
        }

        private void Straight_Click(object sender, RoutedEventArgs e)
        {
            tool = 2;
            color = ColorEnt;
        }

        private void Palette_Click(object sender, RoutedEventArgs e)
        {
            if(ColorPickerWindow.ShowDialog (out ColorEnt))
            {
                color = ColorEnt;
            }
        }

        private void Erwser_Click(object sender, RoutedEventArgs e)
        {
            tool = 1;
            color = Colors.White;
        }

        private void Ellips_Click(object sender, RoutedEventArgs e)
        {
            tool = 3;
            color = ColorEnt;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            thickness = (int)(sender as Slider).Value;
        }
    }
}
