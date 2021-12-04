using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace day4
{
    internal class Board
    {
        private List<int> _board;
        private List<int> _numbers = new List<int>();
        public int Win = -1;
        public int Answer = -1;
        
        public Board(List<int> board)
        {
            _board = board;
        }

        public Boolean CheckNumber(int number)
        {
            _numbers.Add(number);
            
            // lets check if we have a winner:
            // rows:
            for (var r = 0; r < _board.Count; r += 5)
            {
                var rowWin = 0;
                for (var c = r; c < r + 5; c++)
                {
                    if (_numbers.Contains(_board[c])) rowWin++;
                }

                if (rowWin == 5) return true;
            }
            
            // cols:
            for (var c = 0; c < 5; c++)
            {
                var colWin = 0;
                for (var r = c; r < _board.Count; r += 5)
                {
                    if (_numbers.Contains(_board[r])) colWin++;
                }

                if (colWin == 5) return true;
            }
            
            return false;
        }

        public int GetSum()
        {
            return _board.Where(b => !_numbers.Contains(b)).Sum();
        }
    }
    class Program
    {
        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var lines = System.IO.File.ReadAllLines(@"../../../day4.txt");
            var boards = new List<Board>();

            // grab the first line and parse them to numbers:
            var numbers = lines[0].Split(",").Select(n => Convert.ToInt32(n)).ToList();

            // grab the boards:
            for (var x = 2; x < lines.Length - 4; x += 6)
            {
                var totalRow = new List<int>();
                for (var y = x; y < x + 5; y++)
                {
                    // remove some extra spaces:
                    var row = lines[y].Trim().Replace("  ", " ");
                    totalRow.AddRange(row.Split(" ").Select(n => Convert.ToInt32(n)).ToList());
                }
                
                // add the full board to the list of boards:
                boards.Add(new Board(totalRow));
            }
            
            // lets check for a winner:
            var count = 0;
            foreach (var number in numbers)
            {
                // check all the boards:
                foreach (var board in boards.Where(board => board.CheckNumber(number)))
                {
                    // lets play all the boards:
                    if (board.Win == -1)
                    {
                        board.Win = count;
                        board.Answer = board.GetSum() * number;
                    }
                    count++;
                }
            }
            // part #1
            var p1 = boards.First(board => board.Win == 0);
            Console.WriteLine($"Part 1: {p1.Answer}");
            
            // part #2
            var p2 = boards.First(board => board.Win == boards.Max(b => b.Win));
            Console.WriteLine($"Part 2: {p2.Answer}");
            
            sw.Stop();
            Console.WriteLine($"Running time: {sw.ElapsedMilliseconds}ms");
        }
    }
}