using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

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
                } else if (coords[x + 1] == coords[x + 3])
                {
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
                else
                {
                    // skip this for part 1
                    // diagonal
                    var startX = coords[x];
                    var startY = coords[x + 1];
                    var endX = coords[x + 2];
                    var endY = coords[x + 3];

                    int dx = Math.Sign(endX - startX);
                    int dy = Math.Sign(endY - startY);
                    int steps = Math.Max(Math.Abs(endX - startX), Math.Abs(endY - startY)) + 1; 

                    int sX = startX;
                    int sY = startY;

                    grid[sY][sX]++;
                    for (int i = 1; i < steps; ++i) {
                        sX = sX == endX ? endX : sX + dx;
                        sY = sY == endY ? endY : sY + dy;
                        grid[sY][sX]++;
                    }
                }
            }
            var point = grid.Sum(t => t.Count(t1 => t1 >= 2));

            Console.WriteLine($"Part 1: {point}");
        }
    }
}