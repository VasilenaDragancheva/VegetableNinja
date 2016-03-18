using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableNinja
{
    public class ConsoleReader:IReader
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}
