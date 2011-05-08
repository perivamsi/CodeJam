using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam
{
    /*
     * Google Code Jam - Qualification Round Africa 2010 - Problem A
     * http://code.google.com/codejam/contest/dashboard?c=351101#s=p0
     */
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
