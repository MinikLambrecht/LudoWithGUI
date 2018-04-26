using System;

namespace Ludo.Library
{
    public class Dice
    {
        // Class Fields
        private int diceValue;

        // Constructor Creates A New Random Between 1 - 7 For Each Time It's Activated And Returns The Cumber
        public int ThrowDice()
        {
            Random rnd = new Random();

            this.diceValue = rnd.Next(1, 7);

            return this.diceValue;
        }
    }
}