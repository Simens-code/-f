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


namespace Проект_тринажёр_по_химии_Оформленный
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void carbtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            carbg.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            carbord.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            batbg.Background = new SolidColorBrush(Color.FromRgb(9, 132, 209));
            batbord.Background = new SolidColorBrush(Color.FromRgb(23, 84, 123));
            clbg.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            clbord.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            kil.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            kilk.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            Temi.Visibility = Visibility.Visible;
           

        }
        private void battarybtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            carbg.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            carbord.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            batbg.Background = new SolidColorBrush(Color.FromRgb(9, 132, 209));
            batbord.Background = new SolidColorBrush(Color.FromRgb(23, 84, 123));
            clbg.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            clbord.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            kil.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            kilk.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            Temi.Visibility = Visibility.Hidden;
            

        }
        private void climatebtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            carbg.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            carbord.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            batbg.Background = new SolidColorBrush(Color.FromRgb(9, 132, 209));
            batbord.Background = new SolidColorBrush(Color.FromRgb(23, 84, 123));
            clbg.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            clbord.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            kil.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            kilk.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            Temi.Visibility = Visibility.Hidden;
            


        }
        private void Spravocniy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            carbg.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            carbord.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            batbg.Background = new SolidColorBrush(Color.FromRgb(9, 132, 209));
            batbord.Background = new SolidColorBrush(Color.FromRgb(23, 84, 123));
            clbg.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            clbord.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            kil.Background = new SolidColorBrush(Color.FromRgb(128, 128, 128));
            kilk.Background = new SolidColorBrush(Color.FromRgb(82, 82, 82));
            Temi.Visibility = Visibility.Hidden;
            

        }


    }
}