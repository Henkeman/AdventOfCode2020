using System;
using System.Collections.Generic;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            Int64 treeCount = TreeCount(input, 1, 1);
            treeCount *= TreeCount(input, 3, 1);
            treeCount *= TreeCount(input, 5, 1);
            treeCount *= TreeCount(input, 7, 1);
            treeCount *= TreeCount(input, 1, 2);

            Console.WriteLine(treeCount);
        }

        static int TreeCount(string[] input, int xSpeed, int ySpeed)
        {
            var xPos = 0;
            var treeCount = 0;

            for (int y = 0; y < input.Length; y += ySpeed)
            {
                xPos = xPos % input[y].Length;
                if (input[y][xPos] == '#')
                {
                    treeCount++;
                }
                xPos += xSpeed;
            }

            return treeCount;
        }
    }
}
