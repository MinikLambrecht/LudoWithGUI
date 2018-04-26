using System;

namespace Ludo.Library
{
    // FieldType Enum
    public enum FieldType { Home, Safe, InPlay, Finish };

    public class Field
    {
        // Class Fields
        private GameColor color;
        private int fieldId;
        private Token[] tokens = new Token[2];

        // Constructor
        public Field(int id, GameColor color)
        {
            this.fieldId = id;
            this.color = color;
        }

        //public bool PlaceToken(Token tkn)
        //{
        //    if (tokens.Any())
        //    { // Field has Token objects on it




        //    }
        //    else
        //    {
        //        // No tokens, place token
        //        tokens[0] = tkn;
        //    }

        ////}
    }
}