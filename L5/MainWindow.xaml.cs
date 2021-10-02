using Microsoft.Win32;
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

namespace L5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (MagnifierEffect != null)
            {
                if ((sender as RadioButton).Content.ToString() == "Circle")
                {
                    MagnifierEffect.FrameType = Xceed.Wpf.Toolkit.FrameType.Circle;
                }
                else
                {
                    MagnifierEffect.FrameType = Xceed.Wpf.Toolkit.FrameType.Rectangle;
                }
            }

        }

        private void Amount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MagnifierEffect != null)
            {
                MagnifierEffect.ZoomFactor = (sender as Slider).Value;
            }

        }

        private void Radius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MagnifierEffect != null)
            {
                MagnifierEffect.Radius = (sender as Slider).Value;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            var result = dialog.ShowDialog();
            if (result == true)
            {
                var uriSource = new Uri(dialog.FileName, UriKind.RelativeOrAbsolute);
                SourceImage.Source = new BitmapImage(uriSource);
                MutateImage.Source = new BitmapImage(uriSource);
            }
        }

        private void BlurRadius_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BlurEffect != null)
            {
                BlurEffect.Radius = (sender as Slider).Value;
            }
        }
    }
}
