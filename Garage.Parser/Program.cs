using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            // See https://aka.ms/new-console-template for more information
            var a = Parser.GetInfo();

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}
