using System;
using System.Collections.Generic;
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
            var part2 = 0;

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
                        // Console.WriteLine($"{l}, {c}: {grid[l, c]}");
                        // part 2:
                        // x axis (col):
                        var basinCount = 1; // Start at 1, because the middle is also a part
                        var check = grid[l, c];
                        // -->
                        for (var x = c + 1; x < maxCol; x++)
                        {
                            // Console.WriteLine($"--> {grid[l, x]}, ");
                            if (grid[l, x] < 9)
                            {
                                basinCount++;
                            }
                            else
                            {
                                break;
                            }
                            
                            // Up:
                            for (var y = l + 1; y < maxRow; y++)
                            {
                                if (grid[y, x] < 9)
                                {
                                    basinCount++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            // Down:
                            for (var y = l - 1; y >= 0; y--)
                            {
                                if (grid[y, x] < 9)
                                {
                                    basinCount++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        // <--
                        for (var x = c - 1; x >= 0; x--)
                        {
                            // Console.WriteLine($"<-- {grid[l, x]}, ");
                            if (grid[l, x] < 9)
                            {
                                basinCount++;
                            }
                            else
                            {
                                break;
                            }
                            
                            // Up:
                            for (var y = l + 1; y < maxRow; y++)
                            {
                                if (grid[y, x] < 9)
                                {
                                    basinCount++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            // Down:
                            for (var y = l - 1; y >= 0; y--)
                            {
                                if (grid[y, x] < 9)
                                {
                                    basinCount++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        Console.WriteLine($"basinCount: {basinCount}");
                    }
                }
            }

            Console.WriteLine($"Part 1: {part1}");

        }
    }
}