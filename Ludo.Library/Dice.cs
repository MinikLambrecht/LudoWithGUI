using System;

namespace Ludo.Library
{
    public class Dice
    {
        // Field dice value
        private int diceValue;

        // Throw dice method
        public int ThrowDice()
        {
            Random rnd = new Random();

            this.diceValue = rnd.Next(1, 7);

            return this.diceValue;
        }
    }
}