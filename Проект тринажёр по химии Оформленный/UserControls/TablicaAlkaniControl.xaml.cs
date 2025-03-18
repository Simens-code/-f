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
    /// Логика взаимодействия для TablicaAlkaniControl.xaml
    /// </summary>
    public partial class TablicaAlkaniControl : UserControl
    {
        private ListBox _dragSource = null;

        // Правильные ответы для проверки
        private readonly Dictionary<string, string> _correctAnswers = new Dictionary<string, string>()
        {
            {"alkanesFormula", "CnH2n+2"},
            {"alkenesFormula", "CnH2n"},
            {"alkynesFormula", "CnH2n-2"},
            {"alkadienesFormula", "CnH2n-2"}, // Assuming alkadienes also use CnH2n-2
            {"alkanesBond", "все σ - связи"},
            {"alkenesBond", "одна π - связь"},
            {"alkynesBond", "две π - связи"},
            {"alkadienesBond", "две π - связи"},
            {"alkanesConnection", "замещение"},
            {"alkenesConnection", "присоединение"},
            {"alkynesConnection", "присоединение"},
            {"alkadienesConnection", "присоединение"},
            {"alkanesProperties", "Галогенирование"},
            {"alkenesProperties", "Гидрирование"},
            {"alkynesProperties", "Сульфирование"},
            {"alkadienesProperties", "Гидрирование"},
            {"alkanesClassFormula", "C4H10, C11H22, C12H26, C14H30"},
            {"alkenesClassFormula", "C11H20, C6H12, C8H16, C22H44, C11H22, C30H60"},
            {"alkynesClassFormula", "C4H4, C6H10, C9H14, C11H2, C12H24, C21H40"},
            {"alkadienesClassFormula", "C4H4, C10H18, C12H22, C11H8, C22H42, C13H28"},
            {"alkanesClassNames", "2-метил-3-этилпентан"},
            {"alkenesClassNames", "хорэтан"},
            {"alkynesClassNames", "2,4-диметилпентен-2"},
            {"alkadienesClassNames", "3-метилбутен-1"},
            {"alkanesClassStructures", "CH3\n|    \nCH3–CH-CH2–CH3 \n|    \nCH3–C–CH3\nCH3"},
            {"alkenesClassStructures", "CH3-CH=CH-CH3"},
            {"alkynesClassStructures", "CH-C=C-CH3\n|  \nCl"},
            {"alkadienesClassStructures", "CH2=CH-CH=CH2"}
        };

        public TablicaAlkaniControl()
        {
            InitializeComponent();
            InitializeDragDrop();
            PopulateDragSource();
        }
        private void InitializeDragDrop()
        {
            // Подписываем PreviewDragOver и Drop для всех TextBox-ов
            foreach (var control in FindVisualChildren<TextBox>(this))
            {
                control.PreviewDragOver += OnDragOver;
                control.Drop += OnDrop;
            }
        }

        //Вспомогательный метод для поиска всех TextBox-ов на странице
        public static IEnumerable<TextBox> FindVisualChildren<TextBox>(DependencyObject depObj)
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is TextBox)
                    {

                    }

                    foreach (TextBox childOfChild in FindVisualChildren<TextBox>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        private void PopulateDragSource()
        {
            DragSourceList.Items.Add("CnH2n+2");
            DragSourceList.Items.Add("CnH2n");
            DragSourceList.Items.Add("CnH2n-2");
            DragSourceList.Items.Add("все σ - связи");
            DragSourceList.Items.Add("одна π - связь");
            DragSourceList.Items.Add("две π - связи");
            DragSourceList.Items.Add("замещение");
            DragSourceList.Items.Add("присоединение");
            DragSourceList.Items.Add("Галогенирование");
            DragSourceList.Items.Add("Гидрирование");
            DragSourceList.Items.Add("Сульфирование");
            DragSourceList.Items.Add("C4H10, C11H22, C12H26, C14H30");
            DragSourceList.Items.Add("C11H20, C6H12, C8H16, C22H44, C11H22, C30H60");
            DragSourceList.Items.Add("C4H4, C6H10, C9H14, C11H2, C12H24, C21H40");
            DragSourceList.Items.Add("C4H4, C10H18, C12H22, C11H8, C22H42, C13H28");
            DragSourceList.Items.Add("2-метил-3-этилпентан");
            DragSourceList.Items.Add("хорэтан");
            DragSourceList.Items.Add("2,4-диметилпентен-2");
            DragSourceList.Items.Add("3-метилбутен-1");
            DragSourceList.Items.Add("5,5-диметил-3->этилпентен-3");
            DragSourceList.Items.Add("4,5-диметилгексен-2");
            DragSourceList.Items.Add("3,3-диметилгексин-1");
            DragSourceList.Items.Add("2,5-диметилгексин-3");
            DragSourceList.Items.Add("1-бром-2,5,7-триметил-5-этилоктан-3");
            DragSourceList.Items.Add("1,4,5-трихлоргескин-2");
            DragSourceList.Items.Add("3-этилгексин-1");
            DragSourceList.Items.Add("Бутадиен-1,2");
            DragSourceList.Items.Add("4,4-диметилпентадиен-1,2");
            DragSourceList.Items.Add("3,5,5-триметилгексадиен-1,3");
            DragSourceList.Items.Add("2,4-диэтилгептадиен-2,5");
            DragSourceList.Items.Add("CH3\n|    \nCH3–CH-CH2–CH3 \n|    \nCH3–C–CH3\nCH3");
            DragSourceList.Items.Add("CH3-CH=CH-CH3");
            DragSourceList.Items.Add("CH-C=C-CH3\n|  \nCl");
            DragSourceList.Items.Add("CH2=CH-CH=CH2");

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
                if (_dragSource.SelectedItem is string selectedText)
                {
                    DragDrop.DoDragDrop(DragSourceList, selectedText, DragDropEffects.Move);
                    _dragSource.ReleaseMouseCapture();
                }
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
                // Проверяем, что TextBox не null
                if (targetTextBox != null)
                {
                    targetTextBox.Text = text;
                    DragSourceList.Items.Remove(text);
                    e.Handled = true;
                }
            }
        }

       

        // Метод для проверки правильности заполнения
        private void CheckAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            int correctCount = 0;

            foreach (var key in _correctAnswers.Keys)
            {
                TextBox textBox = (TextBox)this.FindName(key);
                if (textBox != null && textBox.Text.Trim() == _correctAnswers[key])
                {
                    correctCount++;
                    textBox.Background = Brushes.LightGreen; // Подсвечиваем правильно заполненные поля
                }
                else if (textBox != null)
                {
                    textBox.Background = Brushes.LightCoral;  // Подсвечиваем неправильно заполненные поля
                }
            }

            MessageBox.Show($"Правильно заполнено {correctCount} из {_correctAnswers.Count} полей.");

            // Возвращаем полям белый цвет после проверки
            ResetTextBoxColors();
        }

        private void ResetTextBoxColors()
        {
            foreach (var control in FindVisualChildren<TextBox>(this))
            {
                control.Background = Brushes.White; // Возвращаем исходный цвет
            }
        }
    }
}
