using System;
using System.Linq;
using System.Collections.Generic;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            // PART 1
            // get codes
            var input = System.IO.File.ReadAllText("input.txt");
            var split = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
            List<int> intCode = split.Select(l => int.Parse(l.Trim())).ToList();
            var intCodeReset = new List<int>(intCode);

            Console.WriteLine($"IN: \n{input}");
            var result = DoWork(intCode);
            Console.WriteLine($"OUT \n{string.Join(',', result)}");

            // PART 2
            // try some patterns
            Console.WriteLine("\n\nTarget: 19690720");

            Console.Write("Attempt?  ");
            string nounverb = Console.ReadLine();
            while (!string.IsNullOrEmpty(nounverb))
            {
                // reset list
                intCode = new List<int>(intCodeReset);
                List<int> nv = nounverb.Split(",").Select(s => int.Parse(s)).ToList();
                intCode[1] = nv[0];
                intCode[2] = nv[1];

                result = DoWork(intCode);

                Console.WriteLine($"Result: {result[0]}");
                Console.Write("Attempt?  ");
                nounverb = Console.ReadLine();
            }

        }


        static List<int> DoWork(List<int> intCode)
        {
            var finished = false;
            var index = 0;
            var step = 0;
            var len = intCode.Count;

            while (!finished)
            {
                var op = intCode[index];
                int[] nounverbtarget;

                switch (op)
                {
                    case 1:
                        nounverbtarget = new[] { intCode[(index + 1) % len], intCode[(index + 2) % len], intCode[(index + 3) % len] };
                        intCode[nounverbtarget[2]] = intCode[nounverbtarget[0]] + intCode[nounverbtarget[1]];
                        step = 4;
                        break;
                    case 2:
                        nounverbtarget = new[] { intCode[(index + 1) % len], intCode[(index + 2) % len], intCode[(index + 3) % len] };
                        intCode[nounverbtarget[2]] = intCode[nounverbtarget[0]] * intCode[nounverbtarget[1]];
                        step = 4;
                        break;
                    case 99:
                        finished = true;
                        break;
                    default:
                        throw new ArgumentException($"Invalid opcode: {op}");
                }
                index += step;
            }

            return intCode;
        }
    }


}

