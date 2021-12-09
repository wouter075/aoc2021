using System;
using System.Collections.Specialized;

namespace day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"day9.txt");
            var maxCol = lines[0].Length;
            var maxRow = lines.Length;
            var grid = new int[maxRow, maxCol];
            var part1 = 0;
            ListDictionary basinLocations = new ListDictionary();

            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                for (var col = 0; col < line.Length; col++)
                {
                    grid[index, col] = int.Parse(line.Substring(col, 1));
                }
            }

            for (var l = 0; l < lines.Length; l++)
            {
                for (var c = 0; c < lines[0].Length; c++)
                {
                    // check surroundings:
                    var maxSurrounding = 4;
                    var checkLower = 0;
                    if (c == 0 || c == lines[0].Length - 1)
                    {
                        maxSurrounding -= 1;
                    }

                    if (l == 0 || l == lines.Length - 1)
                    {
                        maxSurrounding -= 1;
                    }

                    try
                    {
                        if (grid[l, c] < grid[l - 1, c])
                        {
                            checkLower++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }

                    try
                    {
                        if (grid[l, c] < grid[l + 1, c])
                        {
                            checkLower++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }

                    try
                    {
                        if (grid[l, c] < grid[l, c - 1])
                        {
                            checkLower++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }

                    try
                    {
                        if (grid[l, c] < grid[l, c + 1])
                        {
                            checkLower++;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }

                    if (maxSurrounding == checkLower)
                    {
                        part1 += grid[l, c] + 1;
                        basinLocations.Add(l, c);
                    }
                }
            }

            Console.WriteLine($"Part 1: {part1}");
            
        }
    }
}