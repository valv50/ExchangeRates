using Exchange.ConsoleProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;

            while (true)
            {
                line = Console.ReadLine();

                Console.WriteLine(ConsoleProcessor.ProcessLine(line));
            }
        }
    }
}
