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

namespace cv09
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator calculator = new Calculator();
        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            display.Text= calculator.Display;
            memory.Text= calculator.Memory;
        }

        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            calculator.NumberButton((sender as Button).Content.ToString());
            Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calculator.Button((sender as Button).Content.ToString());
            Update();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            calculator.ClearButton((sender as Button).Content.ToString());
            Update();
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            calculator.Evaluate();
            Update();
        }

        private void operation_Click(object sender, RoutedEventArgs e)
        {
            calculator.OperationSet((sender as Button).Content.ToString());
            Update();
        }

        private void MemoryButton_Click(object sender, RoutedEventArgs e)
        {
            calculator.MemoryOperation((sender as Button).Content.ToString());
            Update();
        }
    }
}
