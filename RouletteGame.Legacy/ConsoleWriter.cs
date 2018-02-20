using System;

namespace RouletteGame.Legacy
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteString(string s)
        {
            Console.WriteLine(s);
        }
    }
}