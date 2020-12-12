using System;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardingPasses = File.ReadAllLines("input.txt").Select(s => new BoardingPass(s)).ToArray();
                       
            var mySeat = FindEmptySeat(boardingPasses);

            Console.WriteLine(mySeat);
        }

        private static int FindEmptySeat(BoardingPass[] boardingPasses)
        {
            var seatIds = boardingPasses.Select(s => s.SeatId).ToHashSet();

            var firstSeatId = boardingPasses.Select(s => s.SeatId).OrderBy(s => s).First();
            var lastSeatId = boardingPasses.Select(s => s.SeatId).OrderByDescending(s => s).First();

            firstSeatId++; // we're not in the first seat
            lastSeatId--; // we're not in the last seat

            for (int i = firstSeatId; i < lastSeatId; i++)
            {
                if (seatIds.Contains(i-1) && !seatIds.Contains(i) && seatIds.Contains(i+1))
                {
                    return i;
                }
            }
            return -1;
        }
    }

    class BoardingPass
    {
        public string Code { get; set; }
        public int Row { get; }
        public int Column { get; }
        public int SeatId { get; }

        public BoardingPass(string code)
        {
            Code = code;
            var rowCode = code.Substring(0, 7);
            var colCode = code.Substring(7, 3);
            var rowBin = ConvertRowCodeToBinary(rowCode);
            var colBin = ConvertColumnCodeToBinary(colCode);

            Row = Convert.ToInt32(rowBin,2);
            Column = Convert.ToInt32(colBin,2);
            SeatId = Row * 8 + Column;
        }

        private string ConvertRowCodeToBinary(string code)
        {
            code = code.Replace('F', '0').Replace('B', '1');
            return code;
        }
        private string ConvertColumnCodeToBinary(string code)
        {
            code = code.Replace('L', '0').Replace('R', '1');
            return code;
        }
    }
}
