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
        private FieldType fieldType;

        // Constructor
        public Field(int id, GameColor color, FieldType fieldType)
        {
            this.fieldId = id;
            this.color = color;
            this.fieldType = fieldType;
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