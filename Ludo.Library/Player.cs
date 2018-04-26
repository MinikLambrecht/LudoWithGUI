using System;

namespace Ludo.Library
{
    // PlayerCount Enum
    public enum PlayerCount
    {
        One,
        Two,
        Three,
        Four
    }

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
            this.PID = PlayerID;
            this.name = playerName;
            this.color = clr;
            CreateTokens(clr);
        }

        // Method To Create Tokens
        private void CreateTokens(GameColor clr)
        {
            // Simple For Loop Creating A New Token As Long as I Is Less Than Or Equals To 3
            for (int i = 0; i <= 3; i++)
            {
                this.tokens[i] = new Token(clr);
            }
        }

        // Returns The Name Saved In The Class Fields
        public string GetName
        {
            get
            {
                return this.name;
            }
        }

        // Returns The Color Saved In The Class Fields
        public GameColor GetColor
        {
            get
            {
                return this.color;
            }
        }

        // Returns The Token Saved In The Class Fields
        public Token[] GetTokens
        {
            get
            {
                return this.tokens;
            }
        }

        // Returns The PlayerID Saved In the Class Fields
        public string GetID
        {
            get
            {
                return this.PID;
            }
        }
    }
}
