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
    /// <summary>
    /// Логика взаимодействия для NumenklaturaVeshestvaControl.xaml
    /// </summary>
    public partial class NumenklaturaVeshestvaControl : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public List<string> HydrogenOptions { get; } = new List<string> { "H", "H2", "H3" };
        public List<string> NumberOptions { get; } = new List<string> { "1", "2", "3", "4", "5", "6" };
        public List<string> SubstituentOptions { get; } = new List<string> { "метил", "этил", "пропил", "изопропил" };
        public List<string> DiTriOptions { get; } = new List<string> { "ди", "три", "тетра", "пента" };
        public List<string> ChainOptions { get; } = new List<string> { "этан", "пропан", "бутан", "пентан", "гексан", "гептан", "октан" };


        private readonly Dictionary<string, string> _correctAnswers = new Dictionary<string, string>
        {
            {"c1hComboBox", "H3"},
            {"c2hComboBox", "H"},
            {"c3hComboBox", "H2"},
            {"c4hComboBox", "H"},
            {"c5hComboBox", "H2"},
            {"c6hComboBox", "H3"},
            {"c7hComboBox", "H3"},
            {"c8hComboBox", "H3"},

            {"n1ComboBox", "1"},
            {"n2ComboBox", "2"},
            {"n3ComboBox", "3"},
            {"n4ComboBox", "4"},
            {"n5ComboBox", "5"},
            {"n6ComboBox", "6"},

            {"substituent1ComboBox", "метил"},
            {"substituent2ComboBox", "метил"},

            {"position1ComboBox", "2"},
            {"position2ComboBox", "4"},
            {"diTriComboBox", "ди"},
            {"chainNameComboBox", "гексан"}

        };
        private string _selectedSubstituent;

        public string SelectedSubstituent
        {
            get { return _selectedSubstituent; }
            set
            {
                _selectedSubstituent = value;
                OnPropertyChanged();
            }
        }
        public NumenklaturaVeshestvaControl()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void CheckAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            int correctCount = 0;


            foreach (var key in _correctAnswers.Keys)
            {
                Control control = this.FindName(key) as Control;
                if (control != null)
                {
                    string userAnswer = "";
                    if (control is ComboBox comboBox)
                    {
                        userAnswer = comboBox.SelectedItem as string;
                    }
                    else if (control is TextBox textBox)
                    {
                        userAnswer = textBox.Text;
                    }

                    if (userAnswer == _correctAnswers[key])
                    {
                        correctCount++;
                        control.Background = Brushes.LightGreen;
                    }
                    else
                    {
                        control.Background = Brushes.LightCoral;
                    }
                }
            }

            MessageBox.Show($"Правильно {correctCount} из {_correctAnswers.Count} заданий.");


            ResetControlColors();
        }

        private void ResetControlColors()
        {

            foreach (var control in FindVisualChildren<Control>(this))
            {
                control.Background = Brushes.White;
            }
        }


        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        

        private void Выход_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        
    }
}
