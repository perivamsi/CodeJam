using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeJam
{
    /*
     * Google Code Jam - Qualification Round 2009 - Problem A
     * http://code.google.com/codejam/contest/dashboard?c=90101#s=p0
     */
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
}
