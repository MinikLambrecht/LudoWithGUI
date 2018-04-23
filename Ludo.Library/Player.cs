using System;

namespace Ludo.Library
{
    public class Player
    {
        // Class fields
        private readonly string name;
        private readonly string PID;
        private readonly string TID;
        private GameColor color;
        private Token[] tokens = new Token[4];

        // Constructor
        public Player(string PlayerID, string playerName, GameColor clr)
        {
            // Set playername in class field name
            this.PID = PlayerID;
            this.name = playerName;
            this.color = clr;
            CreateTokens(clr);
        }

        // Method to create tokens
        private void CreateTokens(GameColor clr)
        {
            for (int i = 0; i <= 3; i++)
            {
                this.tokens[i] = new Token(clr);
            }
        }

        // Returns name
        public string GetName
        {
            get
            {
                return this.name;
            }
        }

        // Returns color
        public GameColor GetColor
        {
            get
            {
                return this.color;
            }
        }

        // Returns tokens
        public Token[] GetTokens
        {
            get
            {
                return this.tokens;
            }
        }

        // Returns PlayerID
        public string GetID
        {
            get
            {
                return this.PID;
            }
        }
    }
}
