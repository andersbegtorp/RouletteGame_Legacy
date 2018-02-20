using System;

namespace RouletteGame.Legacy
{
    public class FieldException : Exception
    {
        public FieldException(string s) : base(s)
        {
        }
    }
}