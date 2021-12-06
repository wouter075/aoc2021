using System;
using System.Collections.Generic;
using System.Linq;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"../../../day3.txt").ToList();
            var gamma = "";
            var epsilon = "";
            var gammaCount = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (var line in lines)
            {
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == '1')
                    {
                        gammaCount[i] += 1;
                    }
                }
            }

            foreach (var gc in gammaCount)
            {
                if (gc > lines.Count / 2)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }

            var gammaDec = Convert.ToInt64(gamma, 2);
            var epsilonDec = Convert.ToInt64(epsilon, 2);
            Console.WriteLine($"Part 1: {gammaDec * epsilonDec}");

            List<string> newList = lines;

            while (newList.Count != 1)
            {
                for (int x = 0; x < lines[0].Length; x++)
                {
                    newList = PopOxygen(newList, x);
                }
            }
            var oxygenDec = Convert.ToInt64(newList[0], 2);

            newList = lines;
            while (newList.Count != 1)
            {
                for (int x = 0; x < lines[0].Length; x++)
                {
                    newList = PopCo2(newList, x);
                    if (newList.Count == 1) break;
                }
            }
            var o2Dec = Convert.ToInt64(newList[0], 2);
            
            Console.WriteLine($"Part 2: {oxygenDec * o2Dec}");
        }

        static List<string> PopOxygen(List<string> lines, int bit)
        {
            // count the numbers of the bit:
            var mostCommon = '0';
            var oneCount = lines.Count(line => line[bit] == '1');
            var zeroCount = lines.Count - oneCount;

            // determine the most common bit
            if (oneCount > zeroCount) mostCommon = '1';
            
            // if they are the same, 1 wins
            if (oneCount == zeroCount) mostCommon = '1';
            
            // filter the list and push back
            return lines.Where(line => line[bit] == mostCommon).ToList();
        }

        static List<string> PopCo2(List<string> lines, int bit)
        {
            var leastCommon = '0';
            var oneCount = lines.Count(line => line[bit] == '1');
            var zeroCount = lines.Count - oneCount;
            
            if (oneCount < zeroCount) leastCommon = '1';
            if (oneCount == zeroCount) leastCommon = '0';

            return lines.Where(line => line[bit] == leastCommon).ToList();
        }
    }
}