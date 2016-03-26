namespace VegetableNinja.UI
{
    using System;

    using Contracts;

    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}