using System;
using System.Linq;

namespace day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"day8.txt");
            var easyDigits = lines.Select(line => line.Split(" | ")[1].Split(" ")).ToList();
            var firstDigits = lines.Select(line => line.Split(" | ")[0].Split(" ")).ToList();
            var knownDigits = new int[] {2, 3, 4, 7};
            var part1 = easyDigits.Sum(easyDigit => easyDigit.Count(ed => knownDigits.Contains(ed.Length)));
            int[] knownSegments = new int[8];
            knownSegments[2] = 1;
            knownSegments[4] = 4;
            knownSegments[3] = 7;
            knownSegments[7] = 8;
/*
	segments
		a				0
	b		c		1		2
		d				3
	e		f		4		5
		g				6
								
	number	unique	a	b	c	d	e	f	g	seg:
	0		        0	1	2		4	5	6	6
	1	        v			2			5		2
	2		        0		2	3	4		6	5
	3		        0		2	3		5	6	5
	4	        v       1	2	3		5		4
	5		        0	1		3		5	6	5
	6		        0	1		3	4	5	6	6
	7	        v	0		2			5		3
	8	        v	0	1	2	3	4	5	6	7
	9		        0	1	2	3		5	6	6

*/            

            var sum = "";

            for (var index = 0; index < easyDigits.Count; index++)
            {
	            var easyDigit = easyDigits[index];
                // sort all
                // firstDigit
                var firstDigit = firstDigits[index];
                for (var i = 0; i < firstDigit.Length; i++)
                {
	                firstDigit[i] = string.Concat(firstDigit[i].OrderBy(x => x));
                }

                // easyDigit
                for (var i = 0; i < easyDigit.Length; i++)
                {
	                easyDigit[i] = string.Concat(easyDigit[i].OrderBy(x => x));
                }

                foreach (var ed in easyDigit)
                {
	                // Known segments:
	                if (knownDigits.Contains(ed.Length))
	                {
		                sum += knownSegments[ed.Length];
	                }
	                else
	                {
		                // need all with the same lenght:
		                sum += "_";
	                }
                }
                sum += " ";
            }
            
            Console.WriteLine($"Part 1: {part1}");
            Console.WriteLine($"Part 2: {sum}");

        }
    }
}