using System;
using System.Linq;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"../../../day2.txt")
                .Select(x => x.Split(" "));

            string direction = "";
            int move = 0;
            int horizontal = 0;
            int depth = 0;

            foreach (var instruction in lines)
            {
                direction = instruction[0];
                move = int.Parse(instruction[1]);
                switch(direction)
                {
                    case "down":
                        depth += move;
                        break;
                    case "up":
                        depth -= move;
                        break;
                    case "forward":
                        horizontal += move;
                        break;
                }
            }
            Console.WriteLine($"Part 1: {depth * horizontal}");

            int aim = 0;
            horizontal = 0;
            depth = 0;
            
            foreach (var instruction in lines)
            {
                direction = instruction[0];
                move = int.Parse(instruction[1]);
                switch(direction)
                {
                    case "down":
                        aim += move;
                        break;
                    case "up":
                        aim -= move;
                        break;
                    case "forward":
                        horizontal += move;
                        depth += move * aim;
                        break;
                }
            }
            Console.WriteLine($"Part 2: {depth * horizontal}");
        }
    }
}