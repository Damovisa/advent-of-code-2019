using System;
using System.Collections;
using System.Collections.Generic;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"111122: {PassesRules(111122)}");
            Console.WriteLine($"223450: {PassesRules(223450)}");
            Console.WriteLine($"444778: {PassesRules(444778)}");
            Console.WriteLine($"111111: {PassesRules(111111)}");
            Console.WriteLine($"123789: {PassesRules(123789)}");
            Console.WriteLine($"334557: {PassesRules(334557)}");
            Console.WriteLine($"222456: {PassesRules(222456)}");
            Console.WriteLine($"123445: {PassesRules(123445)}");
            Console.WriteLine($"456777: {PassesRules(456777)}");
            
            var start = 278384;
            var end = 824795;
            var valid = new List<int>();

            for (int i=start; i<=end; i++) {
                if (PassesRules(i)) {
                    valid.Add(i);
                }
            }
            Console.WriteLine($"There are {valid.Count} passwords that match");
        }

        static bool PassesRules(int num) {
            var strNum = num.ToString();
            // Rule 1 - 6 digit number
            if (strNum.Length != 6)
                return false;
            
            var lastdouble = false;
            var moredouble = false;
            var rule2 = false;
            for (int i=0;i<strNum.Length-1;i++) {
                var n1 = strNum[i];
                var n2 = strNum[i+1];
                if (n1 == n2) {
                    // Part 2 rule - only two in a row
                    if (lastdouble)
                        moredouble = true;
                    lastdouble = true;
                }
                else {
                    if (lastdouble && !moredouble) {
                        rule2 = true;
                    }
                    lastdouble = false;
                    moredouble = false;
                }
                if ((int)n1 > (int)n2)
                    return false; 
            }
            return rule2 || (lastdouble && !moredouble);
        }
    }
}
