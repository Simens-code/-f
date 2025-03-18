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
    /// Логика взаимодействия для SootnoshenieVeshestvControl.xaml
    /// </summary>
    public partial class SootnoshenieVeshestvControl : UserControl
    {
        private Dictionary<string, List<string>> _correctAnswers = new Dictionary<string, List<string>>();

        public SootnoshenieVeshestvControl()
        {
            InitializeComponent();
            InitializeDragDrop();
            PopulateSubstances();
            InitializeCorrectAnswers();
        }
        private void InitializeDragDrop()
        {
            acidListBox.PreviewDragOver += OnDragOver;
            acidListBox.Drop += OnDrop;
            saltListBox.PreviewDragOver += OnDragOver;
            saltListBox.Drop += OnDrop;
            oxideListBox.PreviewDragOver += OnDragOver;
            oxideListBox.Drop += OnDrop;
            baseListBox.PreviewDragOver += OnDragOver;
            baseListBox.Drop += OnDrop;

            substancesListBox.PreviewMouseLeftButtonDown += SubstancesListBox_PreviewMouseLeftButtonDown;
            substancesListBox.MouseMove += SubstancesListBox_MouseMove;
        }

        private void PopulateSubstances()
        {
            string[] substances = new string[] { "HNO3", "H2SO4", "H2SO3", "H2SiO3", "H2S", "HF", "HNO2", "H2CO3", "H3PO4", "H3BO3", "HMnO4", "H4P2O7", "HCl", "HBr", "HI",
                "BaSO4", "CuCl2", "AgCl", "Ca(NO3)2", "Fe2(SO4)3", "MgCO3", "ZnSO4", "MnSO4", "Al(NO3)3", "KNO3", "FeS", "Li2SO3", "CaCO3", "MgHPO4", "NaHS", "PbCl2", "Na2SiO3", "Ca(HCO3)2", "Cu(NO2)2", "NaF",
                "Fe2O3", "MgO", "CO2", "H2O", "CaO", "CO", "P2O5", "NO", "N2O", "N2O3", "NO2", "N2O5", "SiO", "SiO2", "SO2", "SO3", "Al2O3", "Na2O", "Cl2O7", "Li2O",
                "Ba(OH)2", "Zn(OH)2", "Al(OH)3", "Mg(OH)2", "NaOH", "KOH", "Fe(OH)3", "Fe(OH)2", "Ni(OH)2", "LiOH", "NH4OH", "Ca(OH)2", "Mn(OH)2", "Cu(OH)2", "Pb(OH)2" };

            foreach (string substance in substances)
            {
                substancesListBox.Items.Add(substance);
            }
        }
        private void InitializeCorrectAnswers()
        {
            _correctAnswers["acidListBox"] = new List<string> { "HNO3", "H2SO4", "H2SO3", "H2SiO3", "H2S", "HF", "HNO2", "H2CO3", "H3PO4", "H3BO3", "HMnO4", "H4P2O7", "HCl", "HBr", "HI" };
            _correctAnswers["saltListBox"] = new List<string> { "BaSO4", "CuCl2", "AgCl", "Ca(NO3)2", "Fe2(SO4)3", "MgCO3", "ZnSO4", "MnSO4", "Al(NO3)3", "KNO3", "FeS", "Li2SO3", "CaCO3", "MgHPO4", "NaHS", "PbCl2", "Na2SiO3", "Ca(HCO3)2", "Cu(NO2)2", "NaF" };
            _correctAnswers["oxideListBox"] = new List<string> { "Fe2O3", "MgO", "CO2", "H2O", "CaO", "CO", "P2O5", "NO", "N2O", "N2O3", "NO2", "N2O5", "SiO", "SiO2", "SO2", "SO3", "Al2O3", "Na2O", "Cl2O7", "Li2O" };
            _correctAnswers["baseListBox"] = new List<string> { "Ba(OH)2", "Zn(OH)2", "Al(OH)3", "Mg(OH)2", "NaOH", "KOH", "Fe(OH)3", "Fe(OH)2", "Ni(OH)2", "LiOH", "NH4OH", "Ca(OH)2", "Mn(OH)2", "Cu(OH)2", "Pb(OH)2" };
        }
        private void SubstancesListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                DragDrop.DoDragDrop(listBox, listBox.SelectedItem.ToString(), DragDropEffects.Move);
            }
        }

        private void SubstancesListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is ListBox listBox && listBox.SelectedItem != null)
            {
                DragDrop.DoDragDrop(listBox, listBox.SelectedItem.ToString(), DragDropEffects.Move);
            }
        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
            e.Handled = true;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(string)) is string substance)
            {
                if (sender is ListBox targetListBox)
                {
                    targetListBox.Items.Add(substance);
                    substancesListBox.Items.Remove(substance);
                    e.Handled = true;
                }
            }
        }
        private void CheckAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            int correctCount = 0;


            if (CheckListBox(acidListBox, "acidListBox")) correctCount++;
            if (CheckListBox(saltListBox, "saltListBox")) correctCount++;
            if (CheckListBox(oxideListBox, "oxideListBox")) correctCount++;
            if (CheckListBox(baseListBox, "baseListBox")) correctCount++;

            MessageBox.Show($"Правильно {correctCount} из 4 классов.");
            ResetListBoxColors();
        }

        private bool CheckListBox(ListBox listBox, string listBoxName)
        {

            List<string> userAnswers = listBox.Items.Cast<string>().ToList();


            List<string> correctAnswers = _correctAnswers[listBoxName];


            bool allCorrectPresent = correctAnswers.All(userAnswers.Contains);
            bool noIncorrectPresent = userAnswers.All(correctAnswers.Contains);


            return allCorrectPresent && noIncorrectPresent;
        }
        private void ResetListBoxColors()
        {
            acidListBox.Background = Brushes.White;
            saltListBox.Background = Brushes.White;
            oxideListBox.Background = Brushes.White;
            baseListBox.Background = Brushes.White;
        }

        private void Выход_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
