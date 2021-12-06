using System;
using System.Linq;

namespace day6
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"day6.txt");
            var values = lines[0].Split(",").Select(x => Convert.ToInt32(x)).ToList();
            var fish = new long[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var days = 256; // change this for the other parts
            
            // init values:
            foreach (var f in values)
            {
                fish[f]++;
            }
            for (var d = 0; d < days; d++)
            {
                var f = fish[0];
                for (var i = 1; i < 9; i++) fish[i - 1] = fish[i];
                
                fish[6] += f;
                fish[8] = f;
            }
            
            Console.WriteLine($"Part: {fish.Sum()}");
        }
    }
}