using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ints = File.ReadAllLines("input.txt")
                    .Select(s => Int32.Parse(s)).ToList();

                var howManyIntsToSum = 3;
                var requiredSum = 2020;

                var solution = Solve(ints, howManyIntsToSum, requiredSum);
                Console.WriteLine(solution);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        // General-purpose recursive solution for finding the product of a set of integers
        // in a list that add up to a given sum.
        static int Solve(IEnumerable<int> ints, int howManyIntsToSum, int requiredSum)
        {
            if (howManyIntsToSum == 0 || !ints.Any()) return 0;

            var head = ints.First();
            var tail = ints.Skip(1);

            if (howManyIntsToSum == 1 && head == requiredSum) return (head);

            var result = head * Solve(tail, howManyIntsToSum - 1, requiredSum - head);

            if (result != 0) return result;

            return Solve(tail, howManyIntsToSum, requiredSum);
        }
    }
}
