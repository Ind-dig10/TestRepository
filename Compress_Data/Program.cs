using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Compress_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите число: ");
            //string input = Console.ReadLine();
            //ShannonFano sh = new ShannonFano();

            //sh.Execite(input);
            //var ssss = sh.Frequencies;


            //foreach (KeyValuePair<string, string> entry in myDictionary)
            //{
            //    // do something with entry.Value or entry.Key
            //}
            //{ }
            // Останавливаем внутренний таймер объекта Stopwatch


            Huffman huffmanTree = new Huffman();
            double entropy = 0.0d;

            Console.WriteLine("Введите число:");
            string input = Console.ReadLine();
            int lenght = input.Length;

            huffmanTree.Execute(input);
            Stopwatch stopwatch = new Stopwatch();
            // Запускаем внутренний таймер объекта Stopwatch
            stopwatch.Start();
            BitArray encoded = huffmanTree.Encode(input);
            stopwatch.Stop();
            Console.WriteLine("Потрачено тактов на выполнение: " + stopwatch.ElapsedTotalMilliseconds);
            string decoded = huffmanTree.Decode(encoded);

            Console.Write("Кодирование: ");

            foreach (bool bit in encoded)
            {
                Console.Write((bit ? 1 : 0) + "");
            }

            Console.WriteLine();
            Console.WriteLine("Декодирование: " + decoded);
            Console.WriteLine("Алфавит: " + RemoveDuplicates(input));
            Console.WriteLine("Длина: " + lenght);

            foreach (var symbol in GetFrequencySymbols(input))
            {
                double probability = (double)symbol.Value / lenght;
                entropy -= probability * Math.Log2(probability);
                Console.WriteLine("Частота символа " + symbol.Key + " - " + symbol.Value + " Вероятность появления: " + probability);
            }

            Console.WriteLine("Энтропия = " + entropy);

            Console.ReadLine();
        }

        public static Dictionary<char, int> GetFrequencySymbols(string text)
        {
            var result = text
                .GroupBy(c => c)
                .ToDictionary(g => g.Key, g => g.Count());

            return result;
        }

        public static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }

    }
}
