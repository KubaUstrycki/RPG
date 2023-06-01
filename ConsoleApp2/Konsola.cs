using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    internal class Konsola
    {
        public void komunikat(string x)
        {

            Console.Clear();
            Console.WriteLine("\n◄►─────────────────────────────────────────────────────────────────────◄►");
            Console.WriteLine($"{x}  ");
            Console.WriteLine("◄►─────────────────────────────────────────────────────────────────────◄►");
            Console.ReadKey();
            Console.Clear();
        }
        public static int getIntFromConsole()
        {
            int x = -1;
            while (x == -1)
            {
                try
                {
                    x = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wpisz cyfrę.");
                }
            }
            return x;

        }
    }
}
