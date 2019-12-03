using System;
using System.Collections;
using System.Collections.Generic;

namespace day3
{
    class Program
    {
        public static Dictionary<(int, int), int> grid = new Dictionary<(int, int), int>();
        public static List<(int,int)> crosses = new List<(int, int)>();
        static (int X, int Y) position = (X: 0, Y: 0);

        static void Main(string[] args)
        {
            // PART 1
            var input = System.IO.File.ReadAllText("input.txt");
            var wires = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

            var wirenum = 0;
            foreach (var ws in wires)
            {
                wirenum++;
                position = (X: 0, Y: 0);
                var instructions = ws.Split(",", StringSplitOptions.RemoveEmptyEntries);
                foreach (var w in instructions)
                {
                    var dir = w.Substring(0, 1);
                    var count = int.Parse(w.Substring(1).Trim());

                    switch (dir)
                    {
                        case "L":
                            for (int i = 0; i < count; i++)
                            {
                                position.X--;
                                Move(wirenum);
                            }
                            break;

                        case "R":
                            for (int i = 0; i < count; i++)
                            {
                                position.X++;
                                Move(wirenum);
                            }
                            break;

                        case "U":
                            for (int i = 0; i < count; i++)
                            {
                                position.Y++;
                                Move(wirenum);
                            }
                            break;

                        case "D":
                            for (int i = 0; i < count; i++)
                            {
                                position.Y--;
                                Move(wirenum);
                            }
                            break;

                        default:
                            throw new ArgumentException($"Invalid direction {dir}");
                    }
                }
            }

            // get min
            crosses.Sort((c,c2) => (Math.Abs(c.Item1)+Math.Abs(c.Item2)).CompareTo((Math.Abs(c2.Item1)+Math.Abs(c2.Item2))));
            Console.WriteLine(crosses[0]);
        }


        public static void Move(int wirenum)
        {
            if (grid.ContainsKey((position.X, position.Y)))
            {
                if (grid[(position.X, position.Y)] == wirenum)
                {
                    // no need to do anything
                }
                else
                {
                    grid[(position.X, position.Y)] = 0;
                    crosses.Add((position.X, position.Y));
                }
            }
            else
            {
                grid[(position.X, position.Y)] = wirenum;
            }
        }
    }

}
