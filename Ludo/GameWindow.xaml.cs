using System.Windows;
using Ludo.Library;

namespace Ludo
{
    public partial class GameWindow : Window
    {
        // Class Fields
        public Player[] players = new Player[4];
        Dice dice = new Dice();

        // Constructor
        public GameWindow()
        {
            InitializeComponent();
        }

        // Button Click Event
        private void btn_RollDice_Click(object sender, RoutedEventArgs e)
        {
            dice_Result.Content = dice.ThrowDice();
        }

        // Button Click Event
        private void btn_ExitGame_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Button Click Event
        private void btn_NewGame_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            this.Close();
            menuWindow.ShowDialog();
        }
    }
}
