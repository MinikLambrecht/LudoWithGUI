﻿using System;
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
using Ludo.Library;
using Ludo;


namespace Ludo.MainMenu
{
    public partial class MenuWindow : Window
    {
        // Class fields
        private Player[] players = new Player[4];

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
            cb_PlayerCount.ItemsSource = Enum.GetValues(typeof(PlayerCount)).Cast<PlayerCount>();
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
            // Utilizing The CreatePlayers Method To Populate The Playerslots In The Game, Either with Real Life Players Or AI
            CreatePlayers();


            // Test Function To See If Our CreatePlayers Method Is Working As It's Supposed To (Select The Function And Press Ctrl + K, Ctrl + U To Uncomment it)
            //MessageBox.Show(players[0].GetID + " " + players[0].GetName + " " + players[0].GetColor + " " + players[0] + "\n" + 
            //                players[1].GetID + " " + players[1].GetName + " " + players[1].GetColor + " " + players[1] + "\n" +
            //                players[2].GetID + " " + players[2].GetName + " " + players[2].GetColor + " " + players[2] + "\n" +
            //                players[3].GetID + " " + players[3].GetName + " " + players[3].GetColor + " " + players[3]);
        }

        // ComboBox Selection Change Event
        private void cb_PlayerCount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cb_PlayerCount.SelectedItem)
            {
                case PlayerCount.One:
                    txt_NameP1.IsReadOnly = false;
                    txt_NameP2.IsReadOnly = true;
                    txt_NameP2.Clear();
                    txt_NameP3.IsReadOnly = true;
                    txt_NameP3.Clear();
                    txt_NameP4.IsReadOnly = true;
                    txt_NameP4.Clear();
                    break;

                case PlayerCount.Two:
                    txt_NameP1.IsReadOnly = false;
                    txt_NameP2.IsReadOnly = false;
                    txt_NameP3.IsReadOnly = true;
                    txt_NameP3.Clear();
                    txt_NameP4.IsReadOnly = true;
                    txt_NameP4.Clear();
                    break;

                case PlayerCount.Three:
                    txt_NameP1.IsReadOnly = false;
                    txt_NameP2.IsReadOnly = false;
                    txt_NameP3.IsReadOnly = false;
                    txt_NameP4.IsReadOnly = true;
                    txt_NameP4.Clear();
                    break;

                case PlayerCount.Four:
                    txt_NameP1.IsReadOnly = false;
                    txt_NameP2.IsReadOnly = false;
                    txt_NameP3.IsReadOnly = false;
                    txt_NameP4.IsReadOnly = false;
                    break;
            }
        }

        // ComboBox Selection Change Event
        private void cb_ColorP1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckForDuplicates(cb_ColorP1, cb_ColorP2, cb_ColorP3, cb_ColorP4);
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
        // This Method takes the chosen ComboBox and sets it ItemsSource. Afterwards it'll set it's selected value to -1 (Null)
        private void SharedColorItemSource(ComboBox cb)
        {
            cb.ItemsSource = Enum.GetValues(typeof(GameColor)).Cast<GameColor>();
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
        private void CreatePlayers()
        {
            GameColor p1_Color = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP1.SelectedItem.ToString());            
            this.players[0] = new Player("#1", txt_NameP1.Text, p1_Color);

            GameColor p2_Color = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP2.SelectedItem.ToString());
            this.players[1] = new Player("#2", txt_NameP2.Text, p2_Color);

            GameColor p3_Color = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP3.SelectedItem.ToString());
            this.players[2] = new Player("#3", txt_NameP3.Text, p3_Color);

            GameColor p4_Color = (GameColor)Enum.Parse(typeof(GameColor), cb_ColorP4.SelectedItem.ToString());
            this.players[3] = new Player("#4", txt_NameP4.Text, p4_Color);
        }
        #endregion
    }
}