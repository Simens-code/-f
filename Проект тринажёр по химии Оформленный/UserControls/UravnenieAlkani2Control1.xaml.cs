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
    /// Логика взаимодействия для UravnenieAlkani2Control1.xaml
    /// </summary>
    public partial class UravnenieAlkani2Control1 : UserControl
    {
        private Dictionary<string, string> _correctAnswers = new Dictionary<string, string>();
        public UravnenieAlkani2Control1()
        {
            InitializeComponent();
            InitializeComboBoxes();
            UpdateReactionEquation();
            InitializeCorrectAnswers();
        }
        private void InitializeCorrectAnswers()
        {
            _correctAnswers.Add("productsComboBox", "K2SO4");
            _correctAnswers.Add("productsComboBox2", "2H2O");
            _correctAnswers.Add("coef1ComboBox", "2");
            _correctAnswers.Add("coef2ComboBox", "1");
            _correctAnswers.Add("coef3ComboBox", "1");
            _correctAnswers.Add("coef4ComboBox", "2");
            _correctAnswers.Add("nonIonicComboBox", "2H2O");
            _correctAnswers.Add("ion1ComboBox", "2K+");
            _correctAnswers.Add("ion2ComboBox", "2OH-");
            _correctAnswers.Add("ion3ComboBox", "2H+");
            _correctAnswers.Add("ion4ComboBox", "SO4-2");
            _correctAnswers.Add("ion5ComboBox", "2K+");
            _correctAnswers.Add("ion6ComboBox", "SO4-2");
            _correctAnswers.Add("shortIon1ComboBox", "2H+");
            _correctAnswers.Add("shortIon2ComboBox", "2OH-");
        }
        private void InitializeComboBoxes()
        {
            productsComboBox.Items.Add("K2S");
            productsComboBox.Items.Add("H2O");
            productsComboBox.Items.Add("KSO4");
            productsComboBox.Items.Add("KH2");
            productsComboBox.Items.Add("K2SO");
            productsComboBox.Items.Add("H2S");
            productsComboBox.Items.Add("K2SO4");

            productsComboBox2.Items.Add("K2S");
            productsComboBox2.Items.Add("H2O");
            productsComboBox2.Items.Add("KSO4");
            productsComboBox2.Items.Add("KH2");
            productsComboBox2.Items.Add("K2SO");
            productsComboBox2.Items.Add("H2S");
            productsComboBox2.Items.Add("K2SO4");


            for (int i = 0; i <= 4; i++)
            {
                coef1ComboBox.Items.Add(i.ToString());
                coef2ComboBox.Items.Add(i.ToString());
                coef3ComboBox.Items.Add(i.ToString());
                coef4ComboBox.Items.Add(i.ToString());

            }

            nonIonicComboBox.Items.Add("K2SO4");
            nonIonicComboBox.Items.Add("2H2O");

            ion1ComboBox.Items.Add("K+");
            ion1ComboBox.Items.Add("2K+");
            ion1ComboBox.Items.Add("K-");
            ion1ComboBox.Items.Add("K2+");
            ion1ComboBox.Items.Add("2K-");
            ion1ComboBox.Items.Add("K2-");

            ion2ComboBox.Items.Add("OH+");
            ion2ComboBox.Items.Add("OH-");
            ion2ComboBox.Items.Add("2OH-");
            ion2ComboBox.Items.Add("2OH+");
            ion2ComboBox.Items.Add("OH2-");
            ion2ComboBox.Items.Add("OH2+");

            ion3ComboBox.Items.Add("H+");
            ion3ComboBox.Items.Add("H-");
            ion3ComboBox.Items.Add("2H-");
            ion3ComboBox.Items.Add("2H+");

            ion4ComboBox.Items.Add("SO4+");
            ion4ComboBox.Items.Add("SO4-");
            ion4ComboBox.Items.Add("SO4+2");
            ion4ComboBox.Items.Add("SO4-2");
            ion4ComboBox.Items.Add("4SO+2");
            ion4ComboBox.Items.Add("4SO-2");

            ion5ComboBox.Items.Add("K+");
            ion5ComboBox.Items.Add("2K+");
            ion5ComboBox.Items.Add("K-");
            ion5ComboBox.Items.Add("K2+");
            ion5ComboBox.Items.Add("2K-");
            ion5ComboBox.Items.Add("K2-");

            ion6ComboBox.Items.Add("SO4+");
            ion6ComboBox.Items.Add("SO4-");
            ion6ComboBox.Items.Add("SO4+2");
            ion6ComboBox.Items.Add("SO4-2");
            ion6ComboBox.Items.Add("4SO+2");
            ion6ComboBox.Items.Add("4SO-2");

            nonIonElement.Text = "2H2O";

            shortIon1ComboBox.Items.Add("2H+");
            shortIon1ComboBox.Items.Add("H+");
            shortIon1ComboBox.Items.Add("OH+");

            shortIon2ComboBox.Items.Add("2OH-");
            shortIon2ComboBox.Items.Add("OH-");
            shortIon2ComboBox.Items.Add("H-");

            shortIonProduct.Text = "2H2O";

        }
        private void UpdateReactionEquation()
        {
            string coef1 = coef1ComboBox.SelectedItem as string;
            string coef2 = coef2ComboBox.SelectedItem as string;
            string coef3 = coef3ComboBox.SelectedItem as string;
            string coef4 = coef4ComboBox.SelectedItem as string;

            string equationText = $"{coef1}KOH + {coef2}H2SO4 = {coef3}K2SO4 + {coef4}H2O";
            reactionEquation.Text = equationText;
            UpdateFullIonEquation();
        }
        private void UpdateFullIonEquation()
        {
            if (coef1ComboBox.SelectedItem is string coef1 &&
               coef2ComboBox.SelectedItem is string coef2 &&
               coef3ComboBox.SelectedItem is string coef3 &&
               coef4ComboBox.SelectedItem is string coef4)
            {
                if (coef1 == "2" && coef2 == "1" && coef3 == "1" && coef4 == "2")
                {
                    string fullIonic = ("2KOH") + " + " + ("H2SO4") + " = " + ("K2SO4") + " + " + "2H2O";

                    fullIonEquation.Text = fullIonic;
                }
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateReactionEquation();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            coef1ComboBox.SelectionChanged += comboBox_SelectionChanged;
            coef2ComboBox.SelectionChanged += comboBox_SelectionChanged;
            coef3ComboBox.SelectionChanged += comboBox_SelectionChanged;
            coef4ComboBox.SelectionChanged += comboBox_SelectionChanged;
            productsComboBox.SelectionChanged += ComboBox_SelectionChanged;
            productsComboBox2.SelectionChanged += ComboBox_SelectionChanged;
            nonIonicComboBox.SelectionChanged += ComboBox_SelectionChanged;
            ion1ComboBox.SelectionChanged += ComboBox_SelectionChanged;
            ion2ComboBox.SelectionChanged += ComboBox_SelectionChanged;
            ion3ComboBox.SelectionChanged += ComboBox_SelectionChanged;
            ion4ComboBox.SelectionChanged += ComboBox_SelectionChanged;
            ion5ComboBox.SelectionChanged += ComboBox_SelectionChanged;
            ion6ComboBox.SelectionChanged += ComboBox_SelectionChanged;
            shortIon1ComboBox.SelectionChanged += ComboBox_SelectionChanged;
            shortIon2ComboBox.SelectionChanged += ComboBox_SelectionChanged;
        }

       

        private void CheckAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            int correctCount = 0;

            foreach (var key in _correctAnswers.Keys)
            {
                ComboBox comboBox = (ComboBox)this.FindName(key);
                if (comboBox != null && comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() == _correctAnswers[key])
                {
                    correctCount++;
                    comboBox.Background = Brushes.LightGreen;
                }
                else if (comboBox != null)
                {
                    comboBox.Background = Brushes.LightCoral;
                }
            }
            MessageBox.Show($"Правильно {correctCount} из {_correctAnswers.Count} заданий.");
            ResetComboBoxColors();
        }


        private void ResetComboBoxColors()
        {
            productsComboBox.Background = Brushes.White;
            productsComboBox2.Background = Brushes.White;
            coef1ComboBox.Background = Brushes.White;
            coef2ComboBox.Background = Brushes.White;
            coef3ComboBox.Background = Brushes.White;
            coef4ComboBox.Background = Brushes.White;
            nonIonicComboBox.Background = Brushes.White;
            ion1ComboBox.Background = Brushes.White;
            ion2ComboBox.Background = Brushes.White;
            ion3ComboBox.Background = Brushes.White;
            ion4ComboBox.Background = Brushes.White;
            ion5ComboBox.Background = Brushes.White;
            ion6ComboBox.Background = Brushes.White;
            shortIon1ComboBox.Background = Brushes.White;
            shortIon2ComboBox.Background = Brushes.White;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UpdateReactionEquation();

        }

        private void Выход_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
