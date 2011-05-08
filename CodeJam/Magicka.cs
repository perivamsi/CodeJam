using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam
{
    /*
     * Google Code Jam - Qualification Round 2011 - Problem B
     * http://code.google.com/codejam/contest/dashboard?c=975485#s=p1&a=3
     */
    public static class Magicka
    {
        public static bool IsOpposed(Dictionary<HashSet<char>, bool> opposed, List<char> list, char ch)
        {
            foreach (char ch2 in list)
            {
                HashSet<char> set = new HashSet<char>() { ch, ch2 };
                foreach (HashSet<char> key in opposed.Keys)
                {
                    if (key.SetEquals(set))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static void Run(string inputfile, string outputfile)
        {
            StringBuilder output = new StringBuilder();
            using (TextReader textReader = new StreamReader(inputfile))
            {
                int n = Int32.Parse(textReader.ReadLine());

                for (int i = 1; i <= n; i++)
                {
                    output.Append("Case #").Append(i).Append(": ");
                    string[] inputLine = textReader.ReadLine().Split(' ');
                    int c = int.Parse(inputLine[0]);

                    Dictionary<HashSet<char>, char> combineDict = new Dictionary<HashSet<char>, char>();
                    for (int j = 1; j < c + 1; j++)
                    {
                        string s = inputLine[j];
                        combineDict.Add(new HashSet<char>() { s[0], s[1] }, s[2]);
                    }

                    int d = int.Parse(inputLine[c + 1]);
                    Dictionary<HashSet<char>, bool> opposed = new Dictionary<HashSet<char>, bool>();
                    for (int j = c + 2; j < c + d + 2; j++)
                    {
                        string s = inputLine[j];
                        opposed.Add(new HashSet<char>() { s[0], s[1] }, true);
                    }

                    string parse = inputLine[c + d + 3];
                    List<char> magik = new List<char>();
                    foreach (char ch in parse)
                    {
                        bool shouldBreak = false;

                        if (magik.Count > 0)
                        {
                            char last = magik[magik.Count - 1];
                            HashSet<char> combine = new HashSet<char>() { last, ch };
                            foreach (HashSet<char> combineKey in combineDict.Keys)
                            {
                                if (combineKey.SetEquals(combine))
                                {
                                    magik.RemoveAt(magik.Count - 1);
                                    magik.Add(combineDict[combineKey]);
                                    shouldBreak = true;
                                    break;
                                }
                            }

                            if (!shouldBreak && IsOpposed(opposed, magik, ch))
                            {
                                magik.Clear();
                                shouldBreak = true;
                                continue;
                            }
                        }

                        if (!shouldBreak) { magik.Add(ch); }

                    }

                    output.Append("[");

                    for (int j = 0; j < magik.Count; j++)
                    {
                        output.Append(magik[j]);
                        if (j != magik.Count - 1)
                        {
                            output.Append(", ");
                        }
                    }

                    output.Append("]\n");

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
