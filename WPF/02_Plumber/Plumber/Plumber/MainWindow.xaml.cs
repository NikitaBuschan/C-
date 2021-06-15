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

namespace Plumber
{

    enum Wey { up, down, left, right }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Wey Two = Wey.up;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {

            if (Two == Wey.right)
            {
                imgTwo.Source = BitmapFrame.Create(new Uri(@"E:\.net\HomeWork\WPF\02_Plumber\Plumber\Plumber\image\4.jpg"));
                Two = Wey.down;
            }
            else if (Two == Wey.down)
            {
                imgTwo.Source = BitmapFrame.Create(new Uri(@"E:\.net\HomeWork\WPF\02_Plumber\Plumber\Plumber\image\3.jpg"));
                Two = Wey.left;
            }
            else if (Two == Wey.left)
            {
                imgTwo.Source = BitmapFrame.Create(new Uri(@"E:\.net\HomeWork\WPF\02_Plumber\Plumber\Plumber\image\2.jpg"));
                Two = Wey.up;
            }
            else if (Two == Wey.up)
            {
                imgTwo.Source = BitmapFrame.Create(new Uri(@"E:\.net\HomeWork\WPF\02_Plumber\Plumber\Plumber\image\1.jpg"));
                Two = Wey.right;
            }
        }
    }
}
