using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class CalculatorWindow : Window
    {
        private string input = string.Empty;

        public string Input
        {
            get { return input; }
            set
            {
                input = value;
                InputBox.Text = input;
            }
        }

        public CalculatorWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string number = ((Button)sender).Content.ToString();
            Input += number;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            string operation = ((Button)sender).Content.ToString();
            Input += " " + operation + " ";
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataTable = new System.Data.DataTable();
                var result = dataTable.Compute(Input, "");
                Input = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            Input = string.Empty;
        }

        private void ClearEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Input))
            {
                Input = Input.Substring(0, Input.Length - 1);
            }
        }

        private void BackspaceButton_Click(object sender, RoutedEventArgs e)
        {
            Input = string.Empty;
        }

        private void NegateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Input) && Input[0] == '-')
            {
                Input = Input.Substring(1);
            }
            else
            {
                Input = "-" + Input;
            }
        }
    }
}
