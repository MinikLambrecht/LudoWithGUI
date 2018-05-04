using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Ludo.Library;

namespace Ludo
{
    public partial class GameWindow : Window
    {
        // Class 
        Dice dice = new Dice();
        public Player[] players = new Player[4];
        
        BitmapImage RedPiece = new BitmapImage(new Uri(@"\resources\redpiece.png", UriKind.Relative));
        BitmapImage GreenPiece = new BitmapImage(new Uri(@"\resources\greenpiece.png", UriKind.Relative));
        BitmapImage BluePiece = new BitmapImage(new Uri(@"\resources\bluepiece.png", UriKind.Relative));
        BitmapImage YellowPiece = new BitmapImage(new Uri(@"\resources\yellowpiece.png", UriKind.Relative));

        // Constructor
        public GameWindow()
        {
            InitializeComponent();
        }

        // Button Click Event
        private void btn_RollDice_Click(object sender, RoutedEventArgs e)
        {
            dice_Result.Content = dice.DiceThrow;
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
