using System;

namespace Ludo.Library
{
    public class Dice : Game
    {
        // Class Fields
        private int diceValue;

        // Derrived Int Creates A New Random Between 1 - 7 For Each Time It's Activated And Returns The Cumber
        public override int DiceThrow
        {
            get
            {
                Random rnd = new Random();

                this.diceValue = rnd.Next(1, 7);

                return this.diceValue;
            }
        }
    }
}