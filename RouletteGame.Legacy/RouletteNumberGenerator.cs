using System;

namespace RouletteGame.Legacy
{
    public class RouletteNumberGenerator : IRouletteNumberGenerator
    {
        public uint GetNumber()
        {
            return (uint)new Random().Next(0, 37);
        }
    }
}