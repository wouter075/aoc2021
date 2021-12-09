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
            var first = true;

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
                        
                        // part 2:
                        // x axis (col):
                        var basinCount = 1; // Start at 1, because the middle is also a part

                        for (var x = c + 1; x < maxCol; x++)
                        {
                            if (grid[l, x] < 9)
                            {
                                basinCount++;
                                Console.WriteLine($"a{l},{x} = {grid[l, x]}");
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
                                    Console.WriteLine($"b{y},{x} = {grid[y, x]}");
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
                                    Console.WriteLine($"c{y},{x} = {grid[y, x]}");
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
                            if (grid[l, x] < 9)
                            {
                                basinCount++;
                                Console.WriteLine($"d{l},{x} = {grid[l, x]}");
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
                                    Console.WriteLine($"e{y},{x} = {grid[y, x]}");
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
                                    Console.WriteLine($"f{y},{x} = {grid[y, x]}");
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Console.WriteLine();
                            
                        }

                        Console.WriteLine($"c: {c}");
                        // collumn stays the same:
                        // row(l) needs to change: y
                        // up:
                        for (var y = l + 1; y < maxRow; y++)
                        {
                            if (grid[y, c] < 9)
                            {
                                Console.WriteLine($"g{y}, {c}: {grid[y, c]}");
                                basinCount++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        // down:
                        for (var y = l - 1; y >= 0; y--)
                        {
                            if (grid[y, c] < 9)
                            {
                                Console.WriteLine($"h{y}, {c}: {grid[y, c]}");
                                basinCount++;
                            }
                            else
                            {
                                break;
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