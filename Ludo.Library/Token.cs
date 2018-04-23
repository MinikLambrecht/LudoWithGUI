using System;

namespace Ludo.Library
{
    public class Token
    {
        // Class fields
        private GameColor color;

        // Constructor
        public Token(GameColor clr)
        {
            this.color = clr;
        }

        // Returns Token Color
        public GameColor GetColor()
        {
            return this.color;
        }
    }
}
