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

namespace Проект_тринажёр_по_химии_Оформленный.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class TemiKZadaniyamControl : UserControl
    {
        public TemiKZadaniyamControl()
        {
            InitializeComponent();
        }

        private void Alkani_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           MainWindow mainWindow = new MainWindow();
            mainWindow.battarybtn_MouseLeftButtonDown();
        }

        private void Veshestva_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
