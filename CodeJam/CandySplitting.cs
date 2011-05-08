using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam
{
    /*
     * Google Code Jam - Qualification Round 2011 - Problem C
     * http://code.google.com/codejam/contest/dashboard?c=975485#s=p2&a=3
     */
    public static class CandySplitting
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

                    int t = Int32.Parse(textReader.ReadLine());
                    if (t < 1)
                    {
                        continue;
                    }

                    int[] candy = textReader.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
                    int result = candy.Aggregate((current, next) => current ^ next);
                    string str = (result == 0) ? (candy.Sum() - candy.Min()).ToString() : "NO";

                    output.Append(str).Append("\n");
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
