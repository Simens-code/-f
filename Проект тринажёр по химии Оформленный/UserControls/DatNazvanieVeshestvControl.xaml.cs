using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    
    
    public partial class DatNazvanieVeshestvControl : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Substance> Substances { get; set; } = new ObservableCollection<Substance>();
        public ObservableCollection<string> SubstanceNames { get; set; } = new ObservableCollection<string>();


        public DatNazvanieVeshestvControl()
        {
            InitializeComponent();
            DataContext = this;
            LoadSubstances();
        }
        private void LoadSubstances()
        {

            Substances = new ObservableCollection<Substance>(new List<Substance>
            {
                new Substance { Formula = "Fe2O3", CorrectName = "Оксид железа (III)" },
                new Substance { Formula = "Ca3(PO4)2", CorrectName = "Ортофосфат кальция" },
                new Substance { Formula = "(NH4)2CO3", CorrectName = "Карбонат аммония" },
                new Substance { Formula = "PbCl2", CorrectName = "Хлорид свинца" },
                new Substance { Formula = "BaSiO3", CorrectName = "Силикат бария" },
                new Substance { Formula = "Mg(OH)2", CorrectName = "Гидроксид магния" },
                new Substance { Formula = "H3BO3", CorrectName = "Борная кислота" },
                new Substance { Formula = "KMnO4", CorrectName = "Перманганат калия" },
                new Substance { Formula = "Na2SO4", CorrectName = "Сульфат натрия" },
                new Substance { Formula = "CuSO4", CorrectName = "Сульфат меди (II)" },
                new Substance { Formula = "H2SiO3", CorrectName = "Кремниевая кислота" },
                new Substance { Formula = "NaHSO4", CorrectName = "Гидросульфат натрия" },
                new Substance { Formula = "NiBr2", CorrectName = "Бромид никеля" },
                new Substance { Formula = "K2Cr2O7", CorrectName = "Дихромат калия" },
                new Substance { Formula = "Al(OH)3", CorrectName = "Гидроксид алюминия" },
                new Substance { Formula = "AgNO3", CorrectName = "Нитрат серебра" },
                new Substance { Formula = "K2MnO4", CorrectName = "Манганат калия" },
                new Substance { Formula = "Li3PO4", CorrectName = "Ортофосфат лития" },
                new Substance { Formula = "NH4NO3", CorrectName = "Нитрат аммония" },
                new Substance { Formula = "Li2SO3", CorrectName = "Сульфит лития" },
                new Substance { Formula = "Pb(NO3)2", CorrectName = "Нитрат свинца" },
                new Substance { Formula = "AlCl3", CorrectName = "Хлорид алюминия" },
                new Substance { Formula = "BaS", CorrectName = "Сульфид бария" },
                new Substance { Formula = "Mg(NO2)2", CorrectName = "Нитрит магния" },
                new Substance { Formula = "K2CO3", CorrectName = "Карбонат калия" }
            });


            List<string> names = Substances.Select(s => s.CorrectName).ToList();


            Random rng = new Random();
            names = names.OrderBy(a => rng.Next()).ToList();


            SubstanceNames = new ObservableCollection<string>(names);
        }

        private void NamesListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                DragDrop.DoDragDrop(listBox, listBox.SelectedItem.ToString(), DragDropEffects.Move);
            }
        }

        private void NamesListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && sender is ListBox listBox && listBox.SelectedItem != null)
            {
                DragDrop.DoDragDrop(listBox, listBox.SelectedItem.ToString(), DragDropEffects.Move);
            }
        }

        private void Substance_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(string)) is string name)
            {
                if (sender is StackPanel targetPanel)
                {

                    string formula = targetPanel.Tag as string;


                    Substance substance = Substances.FirstOrDefault(s => s.Formula == formula);


                    if (substance != null)
                    {

                        if (string.IsNullOrEmpty(substance.AssignedName))
                        {
                            substance.AssignedName = name;
                            SubstanceNames.Remove(name);
                        }
                    }
                }
            }
        }
        private void CheckAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            int correctCount = 0;

            foreach (var substance in Substances)
            {

                StackPanel substancePanel = FindSubstancePanel(substance.Formula);
                if (substance.AssignedName == substance.CorrectName)
                {
                    correctCount++;
                    if (substancePanel != null)
                    {
                        substancePanel.Background = Brushes.LightGreen;
                    }
                }
                else
                {
                    if (substancePanel != null)
                    {
                        substancePanel.Background = Brushes.LightCoral;
                    }
                }
            }

            MessageBox.Show($"Правильно сопоставлено {correctCount} из {Substances.Count} веществ.");
            resetSubstancePanelsColor();

        }


        private StackPanel FindSubstancePanel(string formula)
        {
            foreach (var item in substancesItemsControl.Items)
            {
                if (item is Substance substance && substance.Formula == formula)
                {

                    var container = substancesItemsControl.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                    if (container != null)
                    {
                        return FindVisualChild<StackPanel>(container);
                    }
                }
            }
            return null;
        }


        private T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        return (T)child;
                    }
                    T childItem = FindVisualChild<T>(child);
                    if (childItem != null) return childItem;
                }
            }
            return null;
        }

        private void resetSubstancePanelsColor()
        {
            foreach (var item in substancesItemsControl.Items)
            {
                if (item is Substance substance)
                {

                    var container = substancesItemsControl.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                    if (container != null)
                    {
                        var panel = FindVisualChild<StackPanel>(container);
                        if (panel != null)
                        {
                            panel.Background = Brushes.White;
                        }
                    }
                }
            }
        }

        private void Выход_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
    public class Substance : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Formula { get; set; }
        private string _assignedName;

        public string AssignedName
        {
            get { return _assignedName; }
            set
            {
                if (_assignedName != value)
                {
                    _assignedName = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CorrectName { get; set; }
    }
}
