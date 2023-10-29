using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace CounterAdvanced
{
    internal class ZliczLitery
    {
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
            Console.WriteLine("Podaj tekst:");
            string inputText = Console.ReadLine();

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

            try
            {
                SaveHistogramToFile(filePath, charFrequency);
                Console.WriteLine($"Histogram został zapisany do pliku: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas zapisywania pliku: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}