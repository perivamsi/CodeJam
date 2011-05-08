using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam
{
    /*
     * Google Code Jam - Qualification Round Africa 2010 - Problem B
     * http://code.google.com/codejam/contest/dashboard?c=351101#s=p1
     */
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
}
