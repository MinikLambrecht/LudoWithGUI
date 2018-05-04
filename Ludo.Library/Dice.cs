using System;
using System.Security.Cryptography;

namespace Ludo.Library
{
    public class Dice : Game
    {
        // Class Fields
        private int diceValue;
        CryptoRandom rng = new CryptoRandom();

        // Derrived Int Creates A New Random Between 1 - 7 For Each Time It's Activated And Returns The Cumber
        public override int DiceThrow
        {
            get
            {
                this.diceValue = rng.Next(1,7);

                return this.diceValue;
            }
        }
    }
}