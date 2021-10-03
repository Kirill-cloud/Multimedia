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
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace L6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public DrawingAttributes DrawingAttributes { get; set; } = new DrawingAttributes();
        private InkCanvasEditingMode editingMode;

        public InkCanvasEditingMode EditingMode
        {
            get { return editingMode; }
            set
            {
                editingMode = value;
                OnPropertyChanged();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeInkCanvas();
        }

        private void InitializeInkCanvas()
        {
            this.DataContext = this;
            DrawingAttributes.Color = new Color() { R = 255, G = 0, B = 0, A = 255 };

            DrawingAttributes.AttributeChanged += updateSize;
            DrawingAttributes.Width = 5;

            EditingMode = InkCanvasEditingMode.Ink;
        }

        private void updateSize(object sender, PropertyDataChangedEventArgs e)
        {
            DrawingAttributes.Height = DrawingAttributes.Width;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = (sender as Button);
            switch (x.Content)
            {
                case "Ink": EditingMode = InkCanvasEditingMode.Ink; break;
                case "GestureOnly": EditingMode = InkCanvasEditingMode.GestureOnly; break;
                case "InkAndGesture": EditingMode = InkCanvasEditingMode.InkAndGesture; break;
                case "EraseByStroke": EditingMode = InkCanvasEditingMode.EraseByStroke; break;
                case "None": EditingMode = InkCanvasEditingMode.None; break;
                case "EraseByPoint": EditingMode = InkCanvasEditingMode.EraseByPoint; break;
                case "Select": EditingMode = InkCanvasEditingMode.Select; break;
                default: EditingMode = InkCanvasEditingMode.Ink; break;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
