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
    /// Логика взаимодействия для UravnenieAlkani1Control.xaml
    /// </summary>
    public partial class UravnenieAlkani1Control : UserControl
    {
        private ListBox _dragSource = null;


        private readonly Dictionary<string, string> _correctAnswers = new Dictionary<string, string>()
        {
            {"reaction1Source", "CuCl2 + KOH"},
            {"reaction1Target", "Cu(OH)2↓ + KCl"},
            {"reaction2Source", "Na2CO3 + HCl"},
            {"reaction2Target", "NaCl + CO2↑ + H2O"},
            {"reaction3Source", "ZnS + H2SO4"},
            {"reaction3Target", "ZnSO4 + H2S↑"},
            {"reaction4Source", "Fe(OH)3 + HNO3"},
            {"reaction4Target", "Fe(NO3)3 + H2O"}
        };
        public UravnenieAlkani1Control()
        {
            InitializeComponent();
            InitializeDragDrop();
            PopulateDragSource();
        }

        private void Выход_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void InitializeDragDrop()
        {

            reaction1Source.PreviewDragOver += OnDragOver;
            reaction1Source.Drop += OnDrop;

            reaction1Target.PreviewDragOver += OnDragOver;
            reaction1Target.Drop += OnDrop;

            reaction2Source.PreviewDragOver += OnDragOver;
            reaction2Source.Drop += OnDrop;

            reaction2Target.PreviewDragOver += OnDragOver;
            reaction2Target.Drop += OnDrop;

            reaction3Source.PreviewDragOver += OnDragOver;
            reaction3Source.Drop += OnDrop;

            reaction3Target.PreviewDragOver += OnDragOver;
            reaction3Target.Drop += OnDrop;

            reaction4Source.PreviewDragOver += OnDragOver;
            reaction4Source.Drop += OnDrop;

            reaction4Target.PreviewDragOver += OnDragOver;
            reaction4Target.Drop += OnDrop;
        }

        private void PopulateDragSource()
        {
            DragSourceList.Items.Add("KOH");
            DragSourceList.Items.Add("CuCl2");
            DragSourceList.Items.Add("Cu(OH)2↓ + KCl");
            DragSourceList.Items.Add("Na2CO3");
            DragSourceList.Items.Add("HCl");
            DragSourceList.Items.Add("NaCl + CO2↑ + H2O");
            DragSourceList.Items.Add("ZnS");
            DragSourceList.Items.Add("H2SO4");
            DragSourceList.Items.Add("ZnSO4 + H2S↑");
            DragSourceList.Items.Add("Fe(OH)3");
            DragSourceList.Items.Add("HNO3");
            DragSourceList.Items.Add("Fe(NO3)3 + H2O");

            DragSourceList.PreviewMouseLeftButtonDown += DragSource_PreviewMouseLeftButtonDown;
            DragSourceList.MouseMove += DragSource_MouseMove;
        }

        private void DragSource_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _dragSource = sender as ListBox;
            if (_dragSource != null)
            {
                HitTestResult hitTestResult = VisualTreeHelper.HitTest(_dragSource, e.GetPosition(_dragSource));

                if (hitTestResult != null && hitTestResult.VisualHit is ListBoxItem)
                {
                    _dragSource.CaptureMouse();
                }
            }
        }

        private void DragSource_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && _dragSource != null)
            {
                DragDrop.DoDragDrop(DragSourceList, DragSourceList.SelectedItem, DragDropEffects.Move);
                _dragSource.ReleaseMouseCapture();
            }
        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Move;
            e.Handled = true;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(string)) is string text)
            {
                TextBox targetTextBox = sender as TextBox;
                if (targetTextBox != null)
                {
                    targetTextBox.Text = text;

                    e.Handled = true;
                }
            }
        }

       


        private void CheckAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            int correctCount = 0;


            foreach (var key in _correctAnswers.Keys)
            {
                TextBox textBox = (TextBox)this.FindName(key);
                if (textBox != null && textBox.Text.Trim() == _correctAnswers[key])
                {
                    correctCount++;
                    textBox.Background = Brushes.LightGreen;
                }
                else if (textBox != null)
                {
                    textBox.Background = Brushes.LightCoral;
                }
            }

            MessageBox.Show($"Правильно {correctCount} из {_correctAnswers.Count} уравнений.");


            ResetTextBoxColors();
        }
        private void ResetTextBoxColors()
        {
            reaction1Source.Background = Brushes.White;
            reaction1Target.Background = Brushes.White;
            reaction2Source.Background = Brushes.White;
            reaction2Target.Background = Brushes.White;
            reaction3Source.Background = Brushes.White;
            reaction3Target.Background = Brushes.White;
            reaction4Source.Background = Brushes.White;
            reaction4Target.Background = Brushes.White;
        }
    }
}
