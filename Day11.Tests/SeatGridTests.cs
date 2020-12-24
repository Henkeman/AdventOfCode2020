using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace Day11.Tests
{
    public class SeatGridTests
    {
        [Test]
        public void Should_Be_37_Full_Seats()
        {
            var input = new string[] {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL" };
            var seatGrid = new SeatGrid(input);
            seatGrid.RunAllRounds();

            seatGrid.CountFullSeats(seatGrid.Grids.Last()).ShouldBe(37);
        }
    }
}