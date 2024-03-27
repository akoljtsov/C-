using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class TicTacToeWindow : Window
    {
        private bool xTurn = true; // Черга хрестиків (true - хрестики, false - нулики)
        private Button[,] buttons; // Масив кнопок для керування грою
        private const int BoardSize = 3; // Розмір ігрового поля

        public TicTacToeWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            buttons = new Button[BoardSize, BoardSize];
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Button button = new Button
                    {
                        Content = " ",
                        FontSize = 24,
                        Tag = new Tuple<int, int>(i, j)
                    };
                    button.Click += Button_Click;
                    TicTacToeGrid.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    buttons[i, j] = button;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Tuple<int, int> position = (Tuple<int, int>)button.Tag;
            if (button.Content.ToString() == " " && !IsGameOver())
            {
                button.Content = xTurn ? "X" : "O";
                xTurn = !xTurn;
                if (IsGameOver())
                {
                    string winner = xTurn ? "O" : "X";
                    MessageBox.Show($"Game over! Winner: {winner}");
                }
            }
        }

        private bool IsGameOver()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                if (AreEqual(buttons[i, 0], buttons[i, 1], buttons[i, 2]))
                    return true;

                if (AreEqual(buttons[0, i], buttons[1, i], buttons[2, i]))
                    return true;
            }

            if (AreEqual(buttons[0, 0], buttons[1, 1], buttons[2, 2]) ||
                AreEqual(buttons[0, 2], buttons[1, 1], buttons[2, 0]))
            {
                return true;
            }

            return false;
        }

        private bool AreEqual(Button b1, Button b2, Button b3)
        {
            return b1.Content.ToString() != " " && b1.Content == b2.Content && b2.Content == b3.Content;
        }

        private void ResetGame_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button button in TicTacToeGrid.Children)
            {
                button.Content = " ";
            }
            xTurn = true;
        }
    }
}
