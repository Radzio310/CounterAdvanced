using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;


namespace CounterAdvanced
{
    internal class zLiCzLiTeRy
    {
        static string WczytajTekst()
        {
            Console.WriteLine("Wybierz źródło tekstu:");
            Console.WriteLine("1. Wczytaj tekst z klawiatury");
            Console.WriteLine("2. Wczytaj tekst z uRla");

            int cHoIcE;
            while (!int.TryParse(Console.ReadLine(), out cHoIcE) || (cHoIcE != 1 && cHoIcE != 2))
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            }

            if (cHoIcE == 1)
            {
                Console.WriteLine("Podaj tekst:");
                return Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Podaj adres uRl:");
                string uRl = Console.ReadLine();
                try
                {
                    using (WebClient cLiEnT = new WebClient())
                    {
                        return cLiEnT.DownloadString(uRl);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd podczas pobierania tekstu: {ex.Message}");
                    return null;
                }
            }
        }


        static Dictionary<char, int> CalculatecHaRfReQuEnCy(string iNpUtTeXt, List<char> lEtTeRsToChEcK)
        {
            Dictionary<char, int> cHaRfReQuEnCy = new Dictionary<char, int>();

            foreach (char c in iNpUtTeXt)
            {
                if (Char.IsLetter(c) && lEtTeRsToChEcK.Contains(c))
                {
                    char lOwErCaSeChAr = Char.ToLower(c);
                    if (cHaRfReQuEnCy.ContainsKey(lOwErCaSeChAr))
                    {
                        cHaRfReQuEnCy[lOwErCaSeChAr]++;
                    }
                    else
                    {
                        cHaRfReQuEnCy[lOwErCaSeChAr] = 1;
                    }
                }
            }

            return cHaRfReQuEnCy;
        }

        static void DisplayHistogram(Dictionary<char, int> cHaRfReQuEnCy)
        {
            Console.WriteLine("Histogram częstości występowania liter:");

            foreach (var eNtRy in cHaRfReQuEnCy)
            {
                Console.WriteLine($"{eNtRy.Key}: {new string('*', eNtRy.Value)}");
            }
        }

        static void SaveHistogramToFile(string fIlEpAtH, Dictionary<char, int> cHaRfReQuEnCy)
        {
            using (StreamWriter wRiTeR = new StreamWriter(fIlEpAtH))
            {
                wRiTeR.WriteLine("Histogram częstości występowania liter:");

                foreach (var eNtRy in cHaRfReQuEnCy)
                {
                    wRiTeR.WriteLine($"{eNtRy.Key}: {new string('*', eNtRy.Value)}");
                }
            }
        }

        static void Main(string[] args)
        {
            string iNpUtTeXt = WczytajTekst();

            if (iNpUtTeXt != null)
            {
                Console.WriteLine("Podaj zestaw liter do sprawdzenia (oddzielone przecinkami, np. a,b,c):");
                string lEtTeRsInPuT = Console.ReadLine();

                string[] lEtTeRsArray = lEtTeRsInPuT.Split(',');
                List<char> lEtTeRsToChEcK = new List<char>();
                foreach (string lEtTeR in lEtTeRsArray)
                {
                    char singlelEtTeR = Convert.ToChar(lEtTeR.Trim());
                    lEtTeRsToChEcK.Add(singlelEtTeR);
                }

                Dictionary<char, int> cHaRfReQuEnCy = CalculatecHaRfReQuEnCy(iNpUtTeXt, lEtTeRsToChEcK);
                DisplayHistogram(cHaRfReQuEnCy);

                string fIlEpAtH = "C:\\Users\\kamil\\Desktop\\Wynik\\wynik.txt";

                try
                {
                    SaveHistogramToFile(fIlEpAtH, cHaRfReQuEnCy);
                    Console.WriteLine($"Histogram został zapisany do pliku: {fIlEpAtH}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd podczas zapisywania pliku: {ex.Message}");
                }
            }

            Console.ReadKey();
        }
    }
}