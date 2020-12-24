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
            var seatGrid = new SeatGrid(inputs);
            seatGrid.RunAllRounds();
            Console.WriteLine(seatGrid.CountFullSeats(seatGrid.Grids.Last()));
        }
    }
}
