using System;
using System.Collections.Generic;
using System.IO;

namespace Day06
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
            var firstLine = true;

            foreach (var line in input)
            {
                if (line.Trim().Length > 0)
                {
                    if (firstLine)
                    {
                        foreach (var ch in line) set.Add(ch);
                        firstLine = false;
                    }
                    else
                    {
                        foreach (var ch in set)
                        {
                            if (!line.Contains(ch))
                            {
                                set.Remove(ch);
                            }
                        }
                    }
                }
                else
                {
                    count += set.Count;
                    set.Clear();
                    firstLine = true;
                }
            }
            count += set.Count;

            return count;
        }
    }
}
