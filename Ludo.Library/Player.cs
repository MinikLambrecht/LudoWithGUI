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
        // Constructor
        public Player(string PlayerID, string playerName, GameColor clr)
        {
            this.GetID = PlayerID;
            this.GetName = playerName;
            this.GetColor = clr;
        }

        // Returns The Name Saved In The Constructors Parameters
        public string GetName { get; }

        // Returns The Color Saved In The Constructors Parameters
        public GameColor GetColor { get; }

        // Returns The PlayerID Saved In the Constructors Parameters
        public string GetID { get; }
    }
}
