using System;

namespace Ludo.Library
{
    // Color Enum
    public enum GameColor { Yellow, Blue, Red, Green };

    public abstract class Game
    {
        public abstract int DiceThrow { get; }
    }
}
