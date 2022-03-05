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

        char[] Operators = { '+', '-', 'X', '/' };

        private void NumbersWPButtonClick(object sender, RoutedEventArgs e)
        {
            var Button = sender as Button;

            SendButtonContentToOutput(Button);
            
        }
        
        private void OperatorsSPButtonClick(object sender, RoutedEventArgs e)
        {
            var Button = sender as Button;

            if (!string.IsNullOrWhiteSpace(OutputTB.Text)) 
            {
                char[] OutputCharArray = OutputTB.Text.ToCharArray();
                int LastOutputCharIndex = OutputCharArray.Length - 1;

                // Makes it so there can only be one Operator in the output
                int Operator_Count = 0;
                foreach(char character in OutputCharArray)
                {
                    if (character == '+' || character == '-' || character == 'X' || character == '/')
                    {
                        Operator_Count++;
                    }
                    if (Operator_Count >= 1 && (OutputCharArray[LastOutputCharIndex] != '+' && OutputCharArray[LastOutputCharIndex] != '-' && OutputCharArray[LastOutputCharIndex] != 'X' && OutputCharArray[LastOutputCharIndex] != '/')) { return; }
                }

                // Changes the current operator to the new operator if 2 operators are placed next to each other ex.I pressed "-" so 1+- --> 1-
                for (int index = 0; index < Operators.Length; index++)
                {
                    if (OutputCharArray[LastOutputCharIndex] == Operators[index])
                    {
                        OutputTB.Text = OutputTB.Text.Remove(LastOutputCharIndex);
                        OutputTB.Text += Button.Content;
                        return;
                    }
                }
            }

            SendButtonContentToOutput(Button, true);
        }

        private void SendButtonContentToOutput( Button button, bool checkOutputForNullOrWhiteSpace=false)
        {

            if (checkOutputForNullOrWhiteSpace) 
            {
                if(string.IsNullOrWhiteSpace(OutputTB.Text)) { return;  }
            }

            if (button != null)
            {
                var SelectedNumber = button.Content;
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

        private void EnterButtonClick(object sender, RoutedEventArgs e)
        {
            if(!OutputHasOperators()) { return; }

            string OutputText = OutputTB.Text;

            if (OutputText.Contains('+')) {Calculate('+'); }
            else if (OutputText.Contains('-')) { Calculate('-'); }
            else if (OutputText.Contains('X')) { Calculate('X'); }
            else if (OutputText.Contains ('/')) { Calculate('/'); }

            void Calculate(char Operator)
            {
                if (OutputText.Contains(Operator))
                {
                    string[] Values = OutputText.Split(Operator);
                    decimal Value1 = Convert.ToInt64(Values[0]);
                    decimal Value2 = Convert.ToInt64(Values[1]);
                   

                    if(Operator == '+') { OutputTB.Text = Convert.ToString(Value1 + Value2); }
                    if (Operator == '-') { OutputTB.Text = Convert.ToString(Value1 - Value2); }
                    if (Operator == 'X') { OutputTB.Text = Convert.ToString(Value1 * Value2); }
                    if (Operator == '/') { OutputTB.Text = Convert.ToString(Value1 / Value2); }
                }
            }


            bool OutputHasOperators()
            {
                foreach (char character in OutputTB.Text)
                {
                    if (character == Operators[0] || character == Operators[1] || character == Operators[2] || character == Operators[3])
                    {
                        return true;
                    }
                }
                return false;
            }
            
        }

        

        
    }
}
