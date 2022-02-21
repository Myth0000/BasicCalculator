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

namespace BasicCalculator
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

        private void NumbersWPButtonClick(object sender, RoutedEventArgs e)
        {
            var Button = sender as Button;

            if (Button != null)
            {
                var SelectedNumber = Button.Content;
                OutputTB.Text += SelectedNumber.ToString();
            }
            
        }
        
        private void OperatorsSPButtonClick(object sender, RoutedEventArgs e)
        {
            var Button = sender as Button;

            if (Button != null && !string.IsNullOrWhiteSpace(OutputTB.Text))
            {
                var SelectedNumber = Button.Content;
                OutputTB.Text += SelectedNumber.ToString();
            }
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            var OutputText = OutputTB.Text;
            OutputTB.Text = OutputText.Remove(0, OutputText.Length);
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            var OutputText = OutputTB.Text;
            OutputTB.Text = !string.IsNullOrWhiteSpace(OutputText) ? OutputText.Remove(OutputText.Length-1) : OutputText;
        }
    }
}
