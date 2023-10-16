using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterAdvanced
{
    internal class ZliczLitery
    {
        public static int Zlicz(string napis)
        {
            int suma = 0;
            suma = napis.Length;
            return suma;
        }
        public static char PierwszyZnak(string napis)
        {
            return napis[0];
        }
        static void Main(string[] args)
        {
            string napis;
            Console.WriteLine("Podaj napis: ");
            napis = Console.ReadLine();
            Console.WriteLine($"Długość napisu: {Zlicz(napis)} znaków");
            Console.WriteLine($"Pierwszy znak: {PierwszyZnak(napis)}");
            Console.ReadKey();
        }
    }
}
