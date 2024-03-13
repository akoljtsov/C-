using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MyApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new StudentPage());
        }

        private void PlayTicTacToe_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new TicTacToePage());
        }

        private void OpenCalculator_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new CalculatorPage());
        }

        private void DeveloperInfo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new DeveloperInfoPage());
        }
    }

    public class StudentPage : Page
    {
        public StudentPage()
        {
            TextBox studentDataTextBox = new TextBox();
            studentDataTextBox.AcceptsReturn = true;
            studentDataTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            studentDataTextBox.Margin = new Thickness(10);
            studentDataTextBox.FontSize = 16;

            Button addButton = new Button();
            addButton.Content = "Додати студента";
            addButton.Click += (sender, e) =>
            {
                using (StreamWriter writer = new StreamWriter("students.txt", true))
                {
                    writer.WriteLine(studentDataTextBox.Text);
                }

                MessageBox.Show("Дані студента успішно додано.");
            };
            addButton.Margin = new Thickness(10);
            addButton.FontSize = 16;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Children.Add(studentDataTextBox);
            stackPanel.Children.Add(addButton);

            Content = stackPanel;
        }
    }

    public class TicTacToePage : Page
    {
        public TicTacToePage()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "тут ми повинні погратися, але не зараз";
            textBlock.FontSize = 24;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;

            Content = textBlock;
        }
    }

    public class CalculatorPage : Page
    {
        public CalculatorPage()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Тут має бути калькулятор";
            textBlock.FontSize = 24;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;

            Content = textBlock;
        }
    }

    public class DeveloperInfoPage : Page
    {
        public DeveloperInfoPage()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Інформація про розробника:\n";
            textBlock.Text += "ПІП: Антон Кольцов\n";
            textBlock.Text += "Назва групи: КН - 21\n";
            textBlock.Text += "Рік створення: 2024";
            textBlock.FontSize = 16;
            textBlock.TextAlignment = TextAlignment.Center;
            textBlock.VerticalAlignment = VerticalAlignment.Center;

            Content = textBlock;
        }
    }
}
