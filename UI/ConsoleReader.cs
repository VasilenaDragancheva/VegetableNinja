namespace VegetableNinja.UI
{
    using System;

    using Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}