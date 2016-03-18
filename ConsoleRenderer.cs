using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableNinja
{
    public class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
