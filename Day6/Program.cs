using System;
using System.Collections.Generic;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            int count = CountAnswers(input);
            Console.WriteLine(count);
        }

        private static int CountAnswers(string[] input)
        {
            int count = 0;
            var set = new HashSet<char>();

            foreach (var line in input)
            {
                if (line.Trim().Length > 0)
                {
                    foreach (var ch in line)
                    {
                        set.Add(ch);
                    }
                }
                else
                {
                    count += set.Count;
                    set.Clear();
                }
            }
            count += set.Count;

            return count;
        }
    }
}
