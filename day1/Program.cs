using System;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* // PART 1
            //Part1Tests();
            var lines = System.IO.File.ReadAllLines("input.txt");
            var total = 0;
            foreach (var l in lines) {
                total += FuelRequired(int.Parse(l));
            }
            Console.WriteLine($"Total is {total}");
            */

            // PART 2
            //Part2Tests();
            var lines = System.IO.File.ReadAllLines("input.txt");
            var total = 0;
            foreach (var l in lines) {
                total += ActualFuelRequired(int.Parse(l));
            }
            Console.WriteLine($"Total is {total}");
        }

        static void Part1Tests() {
            Console.WriteLine($"12     -->    {FuelRequired(12)}");
            Console.WriteLine($"14     -->    {FuelRequired(14)}");
            Console.WriteLine($"1969   -->    {FuelRequired(1969)}");
            Console.WriteLine($"100756 -->    {FuelRequired(100756)}");
        }

        static void Part2Tests() {
            Console.WriteLine($"1969     -->  {ActualFuelRequired(1969)}");
            Console.WriteLine($"100756   -->  {ActualFuelRequired(100756)}");
        }

        static int FuelRequired(int mass) {
            return (int)Math.Floor((decimal)mass / 3) - 2;
        }

        static int ActualFuelRequired(int mass) {
            var total = 0;
            int fuelFuel = FuelRequired(mass);
            while (fuelFuel > 0) {
                total += fuelFuel;
                fuelFuel = FuelRequired(fuelFuel);
            }
            return total;
        }
    }
}
