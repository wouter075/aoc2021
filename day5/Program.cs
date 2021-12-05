using System;
using System.Collections.Generic;
using System.Linq;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"day5.txt");
            var coords = new List<int>();

            foreach (var line in lines)
            {
                var c1 = line.Split(" -> ")[0].Split(',').Select(x => Convert.ToInt32(x)).ToList();
                var c2 = line.Split(" -> ")[1].Split(',').Select(x => Convert.ToInt32(x)).ToList();
                coords.AddRange(c1);
                coords.AddRange(c2);
            }
            
            // get the max grid value:
            var maxGrid = coords.Max(x => x);
            
            // lets build the grid:
            var grid = new List<List<int>>();
            for (var g = 0; g <= maxGrid; g++)
            {
                var gridRow = new List<int>();
                for (var gr = 0; gr <= maxGrid; gr++)
                {
                    gridRow.Add(0);
                }
                grid.Add(gridRow);
            }
            
            // Console.WriteLine($"Grid: {grid.Count}");
            // Parse input
            for (var x = 0; x < coords.Count; x += 4)
            {   
                // vertical
                if (coords[x] == coords[x + 2])
                {
                    // grab the y:
                    var y1 = coords[x + 1];
                    var y2 = coords[x + 3];
                    if (y1 >= y2)
                    {
                        // reverse:
                        y1 = coords[x + 3];
                        y2 = coords[x + 1];
                    }
                    for (var yCount = y1; yCount <= y2; yCount++)
                    {
                        grid[yCount][coords[x]]++;
                    }
                }
                
                // horizontal
                if (coords[x + 1] != coords[x + 3]) continue;
                var x1 = coords[x];
                var x2 = coords[x + 2];

                if (x1 >= x2)
                {
                    x1 = coords[x + 2];
                    x2 = coords[x];
                }

                for (var xCount = x1; xCount <= x2; xCount++)
                {
                    grid[coords[x + 1]][xCount]++;
                }
            }
            
            var point = grid.Sum(t => t.Count(t1 => t1 > 1));

            Console.WriteLine($"Part 1: {point}");
        }
    }
}