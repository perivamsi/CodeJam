using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam
{
    /*
     * Google Code Jam - Qualification Round 2011 - Problem A
     * http://code.google.com/codejam/contest/dashboard?c=975485#s=p0&a=3
     */
    public static class BotTrust
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

                    string[] inputLine = textReader.ReadLine().Split(' ');
                    int bCurr = 1;
                    int oCurr = 1;
                    List<int> bMoves = new List<int>();
                    List<int> oMoves = new List<int>();

                    for (int j = 1; j < inputLine.Length; j += 2)
                    {
                        if (inputLine[j] == "B")
                        {
                            bMoves.Add(int.Parse(inputLine[j + 1]));
                        }
                        if (inputLine[j] == "O")
                        {
                            oMoves.Add(int.Parse(inputLine[j + 1]));
                        }
                    }

                    int totalTime = 0;
                    int bPos = 0;
                    int oPos = 0;

                    for (int j = 1; j < inputLine.Length; j += 2)
                    {
                        if (inputLine[j] == "B")
                        {
                            int timestep = Math.Abs(bMoves[bPos] - bCurr) + 1;
                            totalTime += timestep;
                            bCurr = bMoves[bPos];
                            bPos++;
                            if (oPos < oMoves.Count)
                            {
                                oCurr = (Math.Abs(oMoves[oPos] - oCurr) < timestep) ? oMoves[oPos] : (oMoves[oPos] > oCurr ? oCurr + timestep : oCurr - timestep);
                            }

                        }
                        if (inputLine[j] == "O")
                        {
                            int timestep = Math.Abs(oMoves[oPos] - oCurr) + 1;
                            totalTime += timestep;
                            oCurr = oMoves[oPos];
                            oPos++;
                            if (bPos < bMoves.Count)
                            {
                                bCurr = (Math.Abs(bMoves[bPos] - bCurr) < timestep) ? bMoves[bPos] : (bMoves[bPos] > bCurr ? bCurr + timestep : bCurr - timestep);
                            }

                        }
                    }
                    output.Append(totalTime).Append("\n");

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
