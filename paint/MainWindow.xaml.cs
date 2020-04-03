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
                Paint.DrawLine((int)point.X, (int)point.Y, (int)P.X, (int)P.Y, Colors.Black);
                
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Paint.Clear(Colors.White);
        }
    }
}
