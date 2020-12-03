using System;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var xPos = 0;
            var treeCount = 0;

            foreach (var row in input)
            {
                xPos = xPos % row.Length;
                if (row[xPos] == '#')
                {
                    treeCount++;
                }
                xPos += 3;
            }

            Console.WriteLine(treeCount);
        }
    }
}
