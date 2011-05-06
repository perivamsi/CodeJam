using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeJam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //StoreCredit.Run("A-small-practice.in", "A-small-practice.out");
            //StoreCredit.Run("A-large-practice.in", "A-large-practice.out");
            //ReverseWords.Run("B-small-practice.in", "B-small-practice.out");
            //ReverseWords.Run("B-large-practice.in", "B-large-practice.out");
            //T9Spelling.Run("C-large-practice.in", "C-large-practice.out");
            //AlienLanguage.Run("A-small-practice.in","A-small-practice.out");
            //AlienLanguage.Run("A-large-practice.in", "A-large-practice.out");
        }
    }

    public static class ClosingTheLoop
    {
        public static void Run(string inputfile, string outputfile)
        {
            StringBuilder output = new StringBuilder();
            using (TextReader textReader = new StreamReader(inputfile))
            {
                int n = Int32.Parse(textReader.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    output.Append("Case #").Append(i).Append(": ");

                    int s = Int32.Parse(textReader.ReadLine());
                    string[] ropes = textReader.ReadLine().Split(' ');

                    ISet<string> ropesSet = new SortedSet<string>();

                    output.Append("\n");

                }

                Console.WriteLine(output);

                using (TextWriter textWriter = new StreamWriter(outputfile))
                {
                    textWriter.Write(output);
                }
            }
        }
    }

    public static class AlienLanguage
    {
        public static void Run(string inputfile, string outputfile)
        {
            List<string> words = new List<string>();
            StringBuilder output = new StringBuilder();
            using (TextReader textReader = new StreamReader(inputfile))
            {
                string[] input = textReader.ReadLine().Split(' ');
                int l = Int32.Parse(input[0]);
                int d = Int32.Parse(input[1]);
                int n = Int32.Parse(input[2]);

                for (int x = 0; x < d; x++)
                {
                    words.Add(textReader.ReadLine());
                }

                for (int i = 1; i <= n; i++)
                {
                    output.Append("Case #").Append(i).Append(": ");

                    string pattern = textReader.ReadLine();
                    pattern = pattern.Replace("(", "[");
                    pattern = pattern.Replace(")", "]");

                    int count = words.Count(word => Regex.IsMatch(word, pattern));

                    output.Append(count).Append("\n");

                }

                Console.WriteLine(output);

                using (TextWriter textWriter = new StreamWriter(outputfile))
                {
                    textWriter.Write(output);
                }
            }
        }
    }

    public static class T9Spelling
    {
        private static Dictionary<char, string> dict = new Dictionary<char, string>();

        public static void Run(string inputfile, string outputfile)
        {
            dict.Add('a', "2");
            dict.Add('b', "22");
            dict.Add('c', "222");
            dict.Add('d', "3");
            dict.Add('e', "33");
            dict.Add('f', "333");
            dict.Add('g', "4");
            dict.Add('h', "44");
            dict.Add('i', "444");
            dict.Add('j', "5");
            dict.Add('k', "55");
            dict.Add('l', "555");
            dict.Add('m', "6");
            dict.Add('n', "66");
            dict.Add('o', "666");
            dict.Add('p', "7");
            dict.Add('q', "77");
            dict.Add('r', "777");
            dict.Add('s', "7777");
            dict.Add('t', "8");
            dict.Add('u', "88");
            dict.Add('v', "888");
            dict.Add('w', "9");
            dict.Add('x', "99");
            dict.Add('y', "999");
            dict.Add('z', "9999");
            dict.Add(' ', "0");

            StringBuilder output = new StringBuilder();
            using (TextReader textReader = new StreamReader(inputfile))
            {
                int n = Int32.Parse(textReader.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    string message = textReader.ReadLine();
                    output.Append("Case #").Append(i).Append(": ");
                    for (int x = 0; x < message.Length; x++)
                    {
                        char current = message[x];

                        if (x > 0 && dict[message[x - 1]][0].Equals(dict[message[x]][0]))
                        {
                            output.Append(" ");
                        }
                        output.Append(dict[current]);
                    }
                    output.Append("\n");
                }

                Console.WriteLine(output);

                using (TextWriter textWriter = new StreamWriter(outputfile))
                {
                    textWriter.Write(output);
                }
            }
        }
    }

    public static class ReverseWords
    {
        public static void Run(string inputfile, string outputfile)
        {
            StringBuilder output = new StringBuilder();
            using (TextReader textReader = new StreamReader(inputfile))
            {
                int n = Int32.Parse(textReader.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    string[] words = textReader.ReadLine().Split(' ');
                    output.Append("Case #").Append(i).Append(": ");
                    for (int x = words.Count() - 1; x >= 0; x--)
                    {
                        output.Append(words[x]).Append(" ");
                    }
                    output.Append("\n");

                }

                Console.WriteLine(output);

                using (TextWriter textWriter = new StreamWriter(outputfile))
                {
                    textWriter.Write(output);
                }
            }
        }
    }

    public static class StoreCredit
    {
        public static void Run(string inputfile, string outputfile)
        {
            StringBuilder output = new StringBuilder();
            using (TextReader textReader = new StreamReader(inputfile))
            {
                int n = Int32.Parse(textReader.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    int credit = Int32.Parse(textReader.ReadLine());
                    int itemCount = Int32.Parse(textReader.ReadLine());
                    string[] itemPriceStr = textReader.ReadLine().Split(' ');
                    int[] itemPrice = itemPriceStr.Select(x => int.Parse(x)).ToArray();

                    bool stayinLoop = true;

                    for (int x = 0; x < itemCount && stayinLoop; x++)
                    {
                        for (int y = x + 1; y < itemCount && stayinLoop; y++)
                        {
                            if (itemPrice[x] + itemPrice[y] == credit)
                            {
                                output.Append("Case #").Append(i).Append(": ").Append(x + 1).Append(" ").Append(y + 1).Append("\n");
                                stayinLoop = false;
                            }
                        }
                    }
                }

                Console.WriteLine(output);

                using (TextWriter textWriter = new StreamWriter(outputfile))
                {
                    textWriter.Write(output);
                }
            }
        }
    }
}
