using System;

namespace Ludo.Library
{
    // Color Enum
    public enum GameColor { Yellow, Blue, Red, Green };

    public class Game
    {
        // Class fields
        private int numberOfPlayers;
        private Player[] players;

        // Constructor of Game Class
        public Game()
        {
            MainMenu();
        }

        // Create MainMenu
        private void MainMenu()
        {
            Console.WriteLine("Welcome to Ludo");
            SetNumberOfPlayers();
            CreatePlayers();
            ShowPlayers();
            Console.ReadKey();
        }

        // Set's the value for minimum and maximum players allowed
        private void SetNumberOfPlayers()
        {
            Console.Write("How many players?: ");

            while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out this.numberOfPlayers))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid value, pick a number between 2 & 4");
                }
            }
        }

        // Creates the players and their objects
        private void CreatePlayers()
        {
            this.players = new Player[this.numberOfPlayers];

            for (int i = 0; i < this.numberOfPlayers; i++)
            {
                Console.WriteLine();
                Console.Write("Name of player {0}: ", (i + 1));
                string name = Console.ReadLine();
                string id = ("#" + (i + 1));
                GameColor clr = GameColor.Red;

                switch (i)
                {
                    case 0:
                        clr = GameColor.Red;
                        break;
                    case 1:
                        clr = GameColor.Blue;
                        break;
                    case 2:
                        clr = GameColor.Yellow;
                        break;
                    case 3:
                        clr = GameColor.Green;
                        break;
                }
                this.players[i] = new Player(id, name, clr);
            }
        }

        // Show Playername, PlayerID & PlayerColor
        private void ShowPlayers()
        {
            Console.WriteLine();
            Console.WriteLine("Okay, your players are here:");
            foreach (Player pl in this.players)
            {
                Console.WriteLine(pl.GetID + " " + pl.GetColor + " Player: " + pl.GetName);
            }
            Console.WriteLine();
        }
    }
}
