using System;
using System.Linq;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"day7.txt");
            var values = lines[0].Split(",").Select(x => Convert.ToInt32(x)).ToList();

            var fuel1 = Int32.MaxValue;
            var fuel2 = Int32.MaxValue;
            for (var y = 1; y <= values.Count; y++)
            {
                var tmp1 = 0;
                var tmp2 = 0;
                foreach (var steps in values.Select(t => Math.Abs(t - y)))
                {
                    tmp1 += steps;
                    tmp2 += steps * (steps + 1) / 2;
                }
                if (tmp1 < fuel1) fuel1 = tmp1;
                if (tmp2 < fuel2) fuel2 = tmp2;
            }
            Console.WriteLine($"Part 1: {fuel1}\nPart 2: {fuel2}");
        }
    }
}