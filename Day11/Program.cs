using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines("input.txt");
            var grids = new List<char[,]>() { CreateGrid(inputs) };

            grids.Add(NewRound(grids.Last()));
        }

        private static char[,] NewRound(char[,] grid)
        {
            var newGrid = new char[grid.GetLength(0), grid.GetLength(1)];

            return newGrid;
        }

        private static char[,] CreateGrid(string[] inputs)
        {
            var xSize = inputs[0].Length;
            var ySize = inputs.Length;
            var grid =  new char[xSize, ySize];

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    grid[x, y] = inputs[y][x];
                }
            }

            return grid;
        }
    }
}
