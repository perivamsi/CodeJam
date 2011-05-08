using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeJam
{
    /*
     * Google Code Jam solutions
     */
    public class CodeJam
    {
        public static void Main(string[] args)
        {
            // Qualification Round 2011 - Problem A
            // http://code.google.com/codejam/contest/dashboard?c=975485#s=p0&a=3
            BotTrust.Run("sampleA.in", "sampleA.out");

            // Qualification Round 2011 - Problem B
            // http://code.google.com/codejam/contest/dashboard?c=975485#s=p1&a=3
            Magicka.Run("sampleB.in", "sampleB.out");

            // Qualification Round 2011 - Problem C
            // http://code.google.com/codejam/contest/dashboard?c=975485#s=p2&a=3
            CandySplitting.Run("sampleC.in", "sampleC.out");
        }
    }
}
