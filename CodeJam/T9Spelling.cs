using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam
{
    /*
     * Google Code Jam - Qualification Round Africa 2010 - Problem C
     * http://code.google.com/codejam/contest/dashboard?c=351101#s=p2
     */
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
}
