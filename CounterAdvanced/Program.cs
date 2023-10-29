using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;


namespace CounterAdvanced
{
    internal class ZliczLitery
    {

        static string WczytajTekst()
        {
            Console.WriteLine("Wybierz źródło tekstu:");
            Console.WriteLine("1. Wczytaj tekst z klawiatury");
            Console.WriteLine("2. Wczytaj tekst z URLa");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
            }

            if (choice == 1)
            {
                Console.WriteLine("Podaj tekst:");
                return Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Podaj adres URL:");
                string url = Console.ReadLine();
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        return client.DownloadString(url);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Wystąpił błąd podczas pobierania tekstu: {ex.Message}");
                    return null;
                }
            }
        }


        static Dictionary<char, int> CalculateCharFrequency(string inputText, List<char> lettersToCheck)
        {
            Dictionary<char, int> charFrequency = new Dictionary<char, int>();

            foreach (char c in inputText)
            {
                if (Char.IsLetter(c) && lettersToCheck.Contains(c))
                {
                    char lowercaseChar = Char.ToLower(c);
                    if (charFrequency.ContainsKey(lowercaseChar))
                    {
                        charFrequency[lowercaseChar]++;
                    }
                    else
                    {
                        charFrequency[lowercaseChar] = 1;
                    }
                }
            }

            return charFrequency;
        }

        static void DisplayHistogram(Dictionary<char, int> charFrequency)
        {
            Console.WriteLine("Histogram częstości występowania liter:");

            foreach (var entry in charFrequency)
            {
                Console.WriteLine($"{entry.Key}: {new string('*', entry.Value)}");
            }
        }

        static void SaveHistogramToFile(string filePath, Dictionary<char, int> charFrequency)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Histogram częstości występowania liter:");

                foreach (var entry in charFrequency)
                {
                    writer.WriteLine($"{entry.Key}: {new string('*', entry.Value)}");
                }
            }
        }

        static void Main(string[] args)
        {
            string inputText = WczytajTekst();


            if (inputText != null)
            {
                Console.WriteLine("Podaj zestaw liter do sprawdzenia (oddzielone przecinkami, np. a,b,c):");
                string lettersInput = Console.ReadLine();

                string[] lettersArray = lettersInput.Split(',');
                List<char> lettersToCheck = new List<char>();
                foreach (string letter in lettersArray)
                {
                    char singleLetter = Convert.ToChar(letter.Trim());
                    lettersToCheck.Add(singleLetter);
                }

            Console.WriteLine("Podaj zestaw liter do sprawdzenia (oddzielone przecinkami, np. a,b,c):");
            string lettersInput = Console.ReadLine();

            // Rozdziel podane litery przy użyciu przecinka jako separatora
            string[] lettersArray = lettersInput.Split(',');

            // Konwertuj tablicę stringów na listę char
            List<char> lettersToCheck = new List<char>();
            foreach (string letter in lettersArray)
            {
                char singleLetter = Convert.ToChar(letter.Trim()); // Usuń spacje wokół litery
                lettersToCheck.Add(singleLetter);
            }

            Dictionary<char, int> charFrequency = CalculateCharFrequency(inputText, lettersToCheck);
            DisplayHistogram(charFrequency);

            //Console.WriteLine("Podaj ścieżkę do pliku, w którym chcesz zapisać histogram:");
            string filePath = "C:\\Users\\phant\\OneDrive\\Pulpit\\CAdv\\wynik.txt";


                Dictionary<char, int> charFrequency = CalculateCharFrequency(inputText, lettersToCheck);
                DisplayHistogram(charFrequency);
            DisplayHistogram(charFrequency);
                string filePath = "C:\\Users\\kamil\\Desktop\\Wynik\\wynik.txt";
            string filePath = "C:\\Users\\phant\\OneDrive\\Pulpit\\CAdv\\wynik.txt";

                try
                {
                    SaveHistogramToFile(filePath, charFrequency);
                    Console.WriteLine($"Histogram został zapisany do pliku: {filePath}");
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