using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class SeatGrid
    {
        public List<char[,]> Grids { get; private set; }
        public SeatGrid(string[] inputs)
        {
            var xSize = inputs[0].Length;
            var ySize = inputs.Length;
            var grid = new char[xSize, ySize];
            Grids = new List<char[,]>();

            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    grid[x, y] = inputs[y][x];
                }
            }
            Grids.Add(grid);
        }
        public bool NewRound()
        {
            var changed = false;
            var grid = Grids.Last();
            var newGrid = new char[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    newGrid[i, j] = GetChar(i, j);
                }
            }

            Grids.Add(newGrid);

            return changed;

            char GetChar(int x, int y)
            {
                if (grid[x, y] == '.') return '.';

                var count = 0;

                var xMin = x == 0 ? x : x - 1;
                var xMax = x == grid.GetLength(0) - 1 ? x : x + 1;
                var yMin = y == 0 ? y : y - 1;
                var yMax = y == grid.GetLength(1) - 1 ? y : y + 1;

                for (int posX = xMin; posX <= xMax; posX++)
                {
                    for (int posY = yMin; posY <= yMax; posY++)
                    {
                        if (grid[posX, posY] == '#') count++;
                    }
                }

                if (grid[x, y] == 'L' && count == 0) { changed = true; return '#'; }
                if (grid[x, y] == '#' && count > 4) { changed = true; return 'L'; }
                return grid[x, y];
            }
        }

        public void RunAllRounds()
        {
            var count = 0;

            while (NewRound()) count++;
        }

        public int CountFullSeats(char[,] grid)
        {
            var count = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == '#') count++;
                }
            }
            return count;
        }
    }
}
