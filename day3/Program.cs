using System;
using System.Collections;
using System.Collections.Generic;

namespace day3
{
    class Program
    {
        public static Dictionary<(int X, int Y), (int Wire, int Steps)> grid = new Dictionary<(int, int), (int, int)>();
        public static List<(int X, int Y, int Steps)> crosses = new List<(int, int, int)>();
        static (int X, int Y) position = (X: 0, Y: 0);

        static void Main(string[] args)
        {
            // PART 1
            var wires = System.IO.File.ReadAllLines("input.txt");

            var wirenum = 0;
            foreach (var ws in wires)
            {
                wirenum++;
                position = (X: 0, Y: 0);
                var instructions = ws.Split(",", StringSplitOptions.RemoveEmptyEntries);
                var steps = 0;
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
                                steps++;
                                Move(wirenum, steps);
                            }
                            break;

                        case "R":
                            for (int i = 0; i < count; i++)
                            {
                                position.X++;
                                steps++;
                                Move(wirenum, steps);
                            }
                            break;

                        case "U":
                            for (int i = 0; i < count; i++)
                            {
                                position.Y++;
                                steps++;
                                Move(wirenum, steps);
                            }
                            break;

                        case "D":
                            for (int i = 0; i < count; i++)
                            {
                                position.Y--;
                                steps++;
                                Move(wirenum, steps);
                            }
                            break;

                        default:
                            throw new ArgumentException($"Invalid direction {dir}");
                    }
                }
            }

            // get min
            crosses.Sort((c, c2) => c.Steps.CompareTo(c2.Steps));
            Console.WriteLine(crosses[0]);
        }


        public static void Move(int wirenum, int steps)
        {
            if (grid.ContainsKey((position.X, position.Y)))
            {
                if (grid[(position.X, position.Y)].Wire == wirenum)
                {
                    // no need to do anything if it's this wire
                }
                else
                {
                    // zero means hit
                    var addedSteps = steps + grid[(position.X, position.Y)].Steps;
                    grid[(position.X, position.Y)] = (0, addedSteps);
                    crosses.Add((position.X, position.Y, addedSteps));
                }
            }
            else
            {
                grid[(position.X, position.Y)] = (wirenum, steps);
            }
        }
    }

}
