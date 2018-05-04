using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Ludo.Library;


namespace Ludo
{
    public partial class MenuWindow : Window
    {
        // Class Fields
        public PlayerCount playerCount { get; set; }
        private Player[] players = new Player[4];        
        List<GameColor> gameColorArr = Enum.GetValues(typeof(GameColor)).Cast<GameColor>().ToList();

        // Constructor
        public MenuWindow()
        {
            InitializeComponent();

            // Utilizing The SharedItemSource Method To Share The ItemsSource For Each Color Picker ComboBox
            SharedColorItemSource(cb_ColorP1);
            SharedColorItemSource(cb_ColorP2);
            SharedColorItemSource(cb_ColorP3);
            SharedColorItemSource(cb_ColorP4);

            

            // Populating ComboBox With Enum Values
            //cb_PlayerCount.ItemsSource = Enum.GetValues(typeof(PlayerCount)).Cast<PlayerCount>();
        }

        #region Events
        // Button Click event
        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            // Simple Shutdown Code To Exit The Program With The Click Of A Button
            Application.Current.Shutdown();
        }

        // Button Click Event
        private void btn_StartGame_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            
            //CreatePlayers();

            //TestCreatePlayers();
            
            //SetPlayerColors();
            

            this.Close();
            gameWindow.ShowDialog();
        }

        // ComboBox Selection Change Event
        //private void cb_PlayerCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    switch (cb_PlayerCount.SelectedItem)
        //    {
        //        case PlayerCount.One:
        //            txt_NameP1.IsReadOnly = false;
        //            txt_NameP2.IsReadOnly = true;
        //            txt_NameP2.Clear();
        //            txt_NameP3.IsReadOnly = true;
        //            txt_NameP3.Clear();
        //            txt_NameP4.IsReadOnly = true;
        //            txt_NameP4.Clear();
        //            break;

        //        case PlayerCount.Two:
        //            txt_NameP1.IsReadOnly = false;
        //            txt_NameP2.IsReadOnly = false;
        //            txt_NameP3.IsReadOnly = true;
        //            txt_NameP3.Clear();
        //            txt_NameP4.IsReadOnly = true;
        //            txt_NameP4.Clear();
        //            break;

        //        case PlayerCount.Three:
        //            txt_NameP1.IsReadOnly = false;
        //            txt_NameP2.IsReadOnly = false;
        //            txt_NameP3.IsReadOnly = false;
        //            txt_NameP4.IsReadOnly = true;
        //            txt_NameP4.Clear();
        //            break;

        //        case PlayerCount.Four:
        //            txt_NameP1.IsReadOnly = false;
        //            txt_NameP2.IsReadOnly = false;
        //            txt_NameP3.IsReadOnly = false;
        //            txt_NameP4.IsReadOnly = false;
        //            break;
        //    }
        //}

        // ComboBox Selection Change Event
        private void cb_ColorP1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(gameColorArr[0].ToString() + "\n"
                          + gameColorArr[1].ToString() + "\n"
                          + gameColorArr[2].ToString() + "\n"
                          + gameColorArr[3].ToString() + "\n" + "\n"
                          + "Selected Index/Item Is" + " " + cb_ColorP1.SelectedIndex.ToString() + " " + cb_ColorP1.SelectedItem.ToString());
            cb_ColorP1.Items.Remove(cb_ColorP1.SelectedItem);
            cb_ColorP1.ItemsSource = null;
            cb_ColorP1.ItemsSource = gameColorArr;
        }

        // ComboBox Selection Change Event
        private void cb_ColorP2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckForDuplicates(cb_ColorP2, cb_ColorP1, cb_ColorP3, cb_ColorP4);
        }

        // ComboBox Selection Change Event
        private void cb_ColorP3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckForDuplicates(cb_ColorP3, cb_ColorP2, cb_ColorP1, cb_ColorP4);
        }

        // ComboBox Selection Change Event
        private void cb_ColorP4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckForDuplicates(cb_ColorP4, cb_ColorP3, cb_ColorP2, cb_ColorP1);
        }

        // Textbox Text Change Event
        private void txt_NameP1_TextChanged(object sender, TextChangedEventArgs e)
        {
            cb_ColorP1.IsEnabled = true;
        }

        // Textbox Text Change Event
        private void txt_NameP2_TextChanged(object sender, TextChangedEventArgs e)
        {
            cb_ColorP2.IsEnabled = true;
        }

        // Textbox Text Change Event
        private void txt_NameP3_TextChanged(object sender, TextChangedEventArgs e)
        {
            cb_ColorP3.IsEnabled = true;
        }

        // Textbox Text Change Event
        private void txt_NameP4_TextChanged(object sender, TextChangedEventArgs e)
        {
            cb_ColorP4.IsEnabled = true;
        }
        #endregion

        #region Methods
        // This Method Creates The Player Colors In-Game Depending On How Many Players There Will Be On The Board
        //private void SetPlayerColors()
        //{
        //    GameWindow gameWindow = new GameWindow();

        //    switch (cb_PlayerCount.SelectedItem)
        //    {
        //        case PlayerCount.One:
        //            var clr1 = (Color)ColorConverter.ConvertFromString(players[0].GetColor.ToString());

        //            Brush p1_clr = new SolidColorBrush(clr1);
        //            Brush p2_none = new SolidColorBrush(Colors.Black);
        //            Brush p3_none = new SolidColorBrush(Colors.Black);
        //            Brush p4_none = new SolidColorBrush(Colors.Black);

        //            TestColors(p1_clr, p2_none, p3_none, p4_none);

        //            gameWindow.lbl_PlayerOne.Content = players[0].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p1_clr;
        //            break;

        //        case PlayerCount.Two:
        //            var clr1_1 = (Color)ColorConverter.ConvertFromString(players[0].GetColor.ToString());
        //            var clr2 = (Color)ColorConverter.ConvertFromString(players[1].GetColor.ToString());

        //            Brush p1_clr_1 = new SolidColorBrush(clr1_1);
        //            Brush p2_clr = new SolidColorBrush(clr2);
        //            Brush p3_none_1 = new SolidColorBrush(Colors.Black);
        //            Brush p4_none_1 = new SolidColorBrush(Colors.Black);

        //            TestColors(p1_clr_1, p2_clr, p3_none_1, p4_none_1);

        //            gameWindow.lbl_PlayerOne.Content = players[0].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p1_clr_1;

        //            gameWindow.lbl_PlayerTwo.Content = players[1].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p2_clr;
        //            break;

        //        case PlayerCount.Three:
        //            var clr1_2 = (Color)ColorConverter.ConvertFromString(players[0].GetColor.ToString());
        //            var clr2_1 = (Color)ColorConverter.ConvertFromString(players[1].GetColor.ToString());
        //            var clr3 = (Color)ColorConverter.ConvertFromString(players[2].GetColor.ToString());

        //            Brush p1_clr_2 = new SolidColorBrush(clr1_2);
        //            Brush p2_clr_1 = new SolidColorBrush(clr2_1);
        //            Brush p3_clr = new SolidColorBrush(clr3);
        //            Brush p4_none_2 = new SolidColorBrush(Colors.Black);

        //            TestColors(p1_clr_2, p2_clr_1, p3_clr, p4_none_2);


        //            gameWindow.lbl_PlayerOne.Content = players[0].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p1_clr_2;

        //            gameWindow.lbl_PlayerTwo.Content = players[1].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p2_clr_1;

        //            gameWindow.lbl_PlayerThree.Content = players[2].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p3_clr;
        //            break;

        //        case PlayerCount.Four:
        //            var clr1_3 = (Color)ColorConverter.ConvertFromString(players[0].GetColor.ToString());
        //            var clr2_2 = (Color)ColorConverter.ConvertFromString(players[1].GetColor.ToString());
        //            var clr3_1 = (Color)ColorConverter.ConvertFromString(players[2].GetColor.ToString());
        //            var clr4 = (Color)ColorConverter.ConvertFromString(players[3].GetColor.ToString());

        //            Brush p1_clr_3 = new SolidColorBrush(clr1_3);
        //            Brush p2_clr_2 = new SolidColorBrush(clr2_2);
        //            Brush p3_clr_1 = new SolidColorBrush(clr3_1);
        //            Brush p4_clr = new SolidColorBrush(clr4);

        //            TestColors(p1_clr_3, p2_clr_2, p3_clr_1, p4_clr);

        //            gameWindow.lbl_PlayerOne.Content = players[0].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p1_clr_3;

        //            gameWindow.lbl_PlayerTwo.Content = players[1].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p2_clr_2;

        //            gameWindow.lbl_PlayerThree.Content = players[2].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p3_clr_1;

        //            gameWindow.lbl_PlayerFour.Content = players[3].GetName;
        //            gameWindow.lbl_PlayerOne.Foreground = p4_clr;
        //            break;
        //    }
        //}

        // This Method Outputs The Hex Code Of An Players Color To Check If It Corresponds To What The Player Chose
        private void TestColors(Brush p1, Brush p2, Brush p3, Brush p4)
        {
            var clr1 = (Color)ColorConverter.ConvertFromString(players[0].GetColor.ToString());
            var clr2 = (Color)ColorConverter.ConvertFromString(players[1].GetColor.ToString());
            var clr3 = (Color)ColorConverter.ConvertFromString(players[2].GetColor.ToString());
            var clr4 = (Color)ColorConverter.ConvertFromString(players[3].GetColor.ToString());

            Brush p1_clr = new SolidColorBrush(clr1);
            Brush p2_clr = new SolidColorBrush(clr2);
            Brush p3_clr = new SolidColorBrush(clr3);
            Brush p4_clr = new SolidColorBrush(clr4);

            string testcl1 = p1.ToString();
            string testcl2 = p2.ToString();
            string testcl3 = p3.ToString();
            string testcl4 = p4.ToString();

            MessageBox.Show("P1 Clr: " + p1 + "\n" +
                            "P2 Clr: " + p2 + "\n" +
                            "P3 Clr: " + p3 + "\n" +
                            "P4 Clr: " + p4);

        }

        // This Method Tests If The CreatePlayers Method Is Working As It's Supposed To
        //private void TestCreatePlayers()
        //{
        //    switch (cb_PlayerCount.SelectedItem)
        //    {
        //        case PlayerCount.One:
        //            MessageBox.Show(players[0].GetID + " " + players[0].GetName + " " + players[0].GetColor + " " + players[0]);
        //            break;

        //        case PlayerCount.Two:
        //            MessageBox.Show(players[0].GetID + " " + players[0].GetName + " " + players[0].GetColor + " " + players[0] + "\n" +
        //                            players[1].GetID + " " + players[1].GetName + " " + players[1].GetColor + " " + players[1]);
        //            break;

        //        case PlayerCount.Three:
        //            MessageBox.Show(players[0].GetID + " " + players[0].GetName + " " + players[0].GetColor + " " + players[0] + "\n" +
        //                            players[1].GetID + " " + players[1].GetName + " " + players[1].GetColor + " " + players[1] + "\n" +
        //                            players[2].GetID + " " + players[2].GetName + " " + players[2].GetColor + " " + players[2]);
        //            break;

        //        case PlayerCount.Four:
        //            MessageBox.Show(players[0].GetID + " " + players[0].GetName + " " + players[0].GetColor + " " + players[0] + "\n" +
        //                            players[1].GetID + " " + players[1].GetName + " " + players[1].GetColor + " " + players[1] + "\n" +
        //                            players[2].GetID + " " + players[2].GetName + " " + players[2].GetColor + " " + players[2] + "\n" +
        //                            players[3].GetID + " " + players[3].GetName + " " + players[3].GetColor + " " + players[3]);
        //            break;
        //    }
        //}

        // This Method takes the chosen ComboBox and sets it ItemsSource. Afterwards it'll set it's selected value to -1 (Null)
        private void SharedColorItemSource(ComboBox cb)
        {
            cb.ItemsSource = gameColorArr;
            cb.SelectedIndex = -1;
        }

        // Incomplete but works somewhat like I wanted, this method checks if any of the color ComboBoxes has the same color chosen
        private void CheckForDuplicates(ComboBox cb1, ComboBox cb2, ComboBox cb3, ComboBox cb4)
        {

            if (cb1.SelectedIndex == 0 && cb2.SelectedIndex == cb1.SelectedIndex || cb3.SelectedIndex == cb1.SelectedIndex || cb4.SelectedIndex == cb1.SelectedIndex)
            {
                MessageBox.Show(cb1.SelectedItem + " Has already been picked, please choose another color!");
                cb1.SelectedIndex = -1;
            }
            else
            {

            }

            if (cb1.SelectedIndex == 1 && cb2.SelectedIndex == cb1.SelectedIndex || cb3.SelectedIndex == cb1.SelectedIndex || cb4.SelectedIndex == cb1.SelectedIndex)
            {
                MessageBox.Show(cb1.SelectedItem + " Has already been picked, please choose another color!");
                cb1.SelectedIndex = -1;
            }
            else
            {

            }

            if (cb1.SelectedIndex == 2 && cb2.SelectedIndex == cb1.SelectedIndex || cb3.SelectedIndex == cb1.SelectedIndex || cb4.SelectedIndex == cb1.SelectedIndex)
            {
                MessageBox.Show(cb1.SelectedItem + " Has already been picked, please choose another color!");
                cb1.SelectedIndex = -1;
            }
            else
            {

            }

            if (cb1.SelectedIndex == 3 && cb2.SelectedIndex == cb1.SelectedIndex || cb3.SelectedIndex == cb1.SelectedIndex || cb4.SelectedIndex == cb1.SelectedIndex)
            {
                MessageBox.Show(cb1.SelectedItem + " Has already been picked, please choose another color!");
                cb1.SelectedIndex = -1;
            }
            else
            {

            }
        }

        // Creates the players with the information the users has chosen
        //private void CreatePlayers()
        //{
        //    switch (cb_PlayerCount.SelectedItem)
        //    {
        //        case PlayerCount.One:
        //            GameColor p1_Color_One = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP1.SelectedItem.ToString());
        //            this.players[0] = new Player("#1", txt_NameP1.Text, p1_Color_One);
        //            break;

        //        case PlayerCount.Two:
        //            GameColor p1_Color_Two = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP1.SelectedItem.ToString());
        //            this.players[0] = new Player("#1", txt_NameP1.Text, p1_Color_Two);

        //            GameColor p2_Color_One = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP2.SelectedItem.ToString());
        //            this.players[1] = new Player("#2", txt_NameP2.Text, p2_Color_One);
        //            break;

        //        case PlayerCount.Three:
        //            GameColor p1_Color_Three = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP1.SelectedItem.ToString());
        //            this.players[0] = new Player("#1", txt_NameP1.Text, p1_Color_Three);

        //            GameColor p2_Color_Two = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP2.SelectedItem.ToString());
        //            this.players[1] = new Player("#2", txt_NameP2.Text, p2_Color_Two);

        //            GameColor p3_Color_One = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP3.SelectedItem.ToString());
        //            this.players[2] = new Player("#3", txt_NameP3.Text, p3_Color_One);
        //            break;

        //        case PlayerCount.Four:
        //            GameColor p1_Color_Four = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP1.SelectedItem.ToString());
        //            this.players[0] = new Player("#1", txt_NameP1.Text, p1_Color_Four);

        //            GameColor p2_Color_Three = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP2.SelectedItem.ToString());
        //            this.players[1] = new Player("#2", txt_NameP2.Text, p2_Color_Three);

        //            GameColor p3_Color_Two = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP3.SelectedItem.ToString());
        //            this.players[2] = new Player("#3", txt_NameP3.Text, p3_Color_Two);

        //            GameColor p4_Color = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP4.SelectedItem.ToString());
        //            this.players[3] = new Player("#4", txt_NameP4.Text, p4_Color);
        //            break;
        //    }
        //}
        #endregion
    }
}