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
    /// Логика взаимодействия для KartinkiAlkaniControl.xaml
    /// </summary>
    public partial class KartinkiAlkaniControl : UserControl
    {
        private List<string> _correctImageOrder = new List<string> { "kikd.jpg", "kdkdk.jpg", "clip_image011_thumb-2.jpg" };
        private ListBox _dragSource = null;
        public KartinkiAlkaniControl()
        {
            InitializeComponent();
            InitializeDragDrop();
            PopulateDragSource();
            PopulateSourceImages();
        }

        private void Выход_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void InitializeDragDrop()
        {
            target1.PreviewDragOver += OnDragOver;
            target1.Drop += OnDrop;

            target2.PreviewDragOver += OnDragOver;
            target2.Drop += OnDrop;

            target3.PreviewDragOver += OnDragOver;
            target3.Drop += OnDrop;

            sourceImages.PreviewMouseLeftButtonDown += DragSource_PreviewMouseLeftButtonDown;
            sourceImages.MouseMove += DragSource_MouseMove;
        }

        private void PopulateDragSource()
        {
            DragSourceList.Items.Add("ориентация диполей воды вокруг кристалла NaCl; их притяжение к ионам Na+ и Cl- в узлах кристаллической решетки противоположно заряженными концами");
            DragSourceList.Items.Add("гидратация (взаимодействие) молекул воды с противоположно заряженными ионами поверхностного слоя кристалла NaCl;");
            DragSourceList.Items.Add("диссоциация (распад) кристалла электролита на гидратированные ионы.");

            DragSourceList.PreviewMouseLeftButtonDown += DragSource_PreviewMouseLeftButtonDown;
            DragSourceList.MouseMove += DragSource_MouseMove;
        }

        private void PopulateSourceImages()
        {

            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;



        }

        private Image CreateImage(string imagePath)
        {
            Image image = new Image();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            image.Source = bitmapImage;
            image.Width = 100;
            image.Height = 100;
            return image;
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
                if (_dragSource.SelectedItem is Image selectedImage)
                {
                    DragDrop.DoDragDrop(_dragSource, selectedImage, DragDropEffects.Move);
                    _dragSource.ReleaseMouseCapture();
                }
                if (_dragSource.SelectedItem is string selectedText)
                {
                    DragDrop.DoDragDrop(_dragSource, selectedText, DragDropEffects.Move);
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
            ListBox targetListBox = sender as ListBox;
            if (e.Data.GetData(typeof(Image)) is Image image)
            {

                if (_dragSource == sourceImages)
                {
                    targetListBox.Items.Add(image);
                    sourceImages.Items.Remove(image);
                    e.Handled = true;
                    return;
                }
            }

            if (e.Data.GetData(typeof(string)) is string text)
            {
                targetListBox.Items.Add(text);
                DragSourceList.Items.Remove(text);
                e.Handled = true;
            }
        }


        private void CheckAnswersButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> userImageOrder = new List<string>();


            foreach (var item in target1.Items)
            {
                if (item is Image image)
                {
                    userImageOrder.Add(System.IO.Path.GetFileName(image.Source.ToString()));
                }
            }
            foreach (var item in target2.Items)
            {
                if (item is Image image)
                {
                    userImageOrder.Add(System.IO.Path.GetFileName(image.Source.ToString()));
                }
            }
            foreach (var item in target3.Items)
            {
                if (item is Image image)
                {
                    userImageOrder.Add(System.IO.Path.GetFileName(image.Source.ToString()));
                }
            }

            bool areEqual = _correctImageOrder.SequenceEqual(userImageOrder);

            if (areEqual)
            {
                MessageBox.Show("Правильно!");
            }
            else
            {
                MessageBox.Show("Неправильно!");
            }
        }

       
    }
}
