using System;
using System.Linq;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"../../../day1.txt").Select(x => int.Parse(x)).ToArray();
            var solve1 = 0;
            
            for (var i = 0; i < lines.Length - 1; i++)
            {
                if (lines[i] < lines[i + 1])
                {
                    solve1++;
                }
                
            }
            Console.WriteLine($"Part 1: {solve1}");

            var solve2 = 0;
            
            for (var i = 0; i < lines.Length - 3; i++)
            {
                if ((lines[i] + lines[i + 1] + lines[i + 2]) < lines[i + 1] + lines[i + 2] + lines[i + 3])
                {
                    solve2++;
                }
            }
            Console.WriteLine($"Part 2: {solve2}");
        }
    }
}