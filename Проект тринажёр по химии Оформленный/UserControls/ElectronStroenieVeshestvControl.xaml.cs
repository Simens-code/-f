using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class Element
    {
        public string Name { get; set; }
        public string Configuration { get; set; }
    }
    public partial class ElectronStroenieVeshestvControl : UserControl
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Element> Elements { get; } = new List<Element>();

        private readonly Dictionary<string, string> _correctAnswers = new Dictionary<string, string>();

        public ElectronStroenieVeshestvControl()
        {
            InitializeComponent();
            DataContext = this;
            LoadElements();
            InitializeCorrectAnswers();
        }
        private void LoadElements()
        {
            Elements.Add(new Element { Name = "хлор", Configuration = "1s22s22p63s23p5" });
            Elements.Add(new Element { Name = "фосфор", Configuration = "1s22s22p63s23p3" });
            Elements.Add(new Element { Name = "натрий", Configuration = "1s22s22p63s1" });
            Elements.Add(new Element { Name = "магний", Configuration = "1s22s22p63s2" });
            Elements.Add(new Element { Name = "железо", Configuration = "1s22s22p63s23p64s23d6" });
            Elements.Add(new Element { Name = "кальций", Configuration = "1s22s22p63s23p64s2" });
            Elements.Add(new Element { Name = "мышьяк", Configuration = "1s22s22p63s23p64s23d104p3" });
            Elements.Add(new Element { Name = "стронций", Configuration = "1s22s22p63s23p64s23d104p65s2" });
            Elements.Add(new Element { Name = "молибден", Configuration = "1s22s22p63s23p64s23d104p65s24d4" });
            Elements.Add(new Element { Name = "йод", Configuration = "1s22s22p63s23p64s23d104p65s24d105p5" });
            Elements.Add(new Element { Name = "барий", Configuration = "1s22s22p63s23p64s23d104p65s24d105p66s2" });
            Elements.Add(new Element { Name = "золото", Configuration = "1s22s22p63s23p64s23d104p65s24d105p66s14f145d10" });
        }

        private void InitializeCorrectAnswers()
        {

            foreach (var element in Elements)
            {
                _correctAnswers.Add(element.Name, element.Configuration);
            }
        }

        private void ElementComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (elementComboBox.SelectedItem is Element selectedElement)
            {
                configurationTextBox.Text = selectedElement.Configuration;
            }
        }

        private void CheckAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            if (elementComboBox.SelectedItem is Element selectedElement)
            {

                string correctConfiguration = _correctAnswers[selectedElement.Name];


                if (configurationTextBox.Text == correctConfiguration)
                {
                    MessageBox.Show("Правильно!");
                    configurationTextBox.Background = Brushes.LightGreen;
                }
                else
                {
                    MessageBox.Show("Неправильно!");
                    configurationTextBox.Background = Brushes.LightCoral;
                }
            }
        }

        private void Выход_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
