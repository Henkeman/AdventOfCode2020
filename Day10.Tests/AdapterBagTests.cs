using NUnit.Framework;
using Shouldly;

namespace Day10.Tests
{
    public class AdapterBagTests
    {
        AdapterBag adapterBag;

        [Test]
        public void Part1_Example1_Should_Be_35()
        {
            // Arrange
            var inputs = new string[] {
            "16",
            "10",
            "15",
            "5",
            "1",
            "11",
            "7",
            "19",
            "6",
            "12",
            "4" };

            // Act
            adapterBag = new AdapterBag(inputs);
            var steps = adapterBag.CountSteps();
            var actual = steps[1] * steps[3];

            // Assert
            actual.ShouldBe(35);
        }
        [Test]
        public void Part1_Example2_Should_Be_220()
        {
            // Arrange
            var inputs = new string[] {
            "28",
            "33",
            "18",
            "42",
            "31",
            "14",
            "46",
            "20",
            "48",
            "47",
            "24",
            "23",
            "49",
            "45",
            "19",
            "38",
            "39",
            "11",
            "1",
            "32",
            "25",
            "35",
            "8",
            "17",
            "7",
            "9",
            "4",
            "2",
            "34",
            "10",
            "3" };

            // Act
            adapterBag = new AdapterBag(inputs);
            var steps = adapterBag.CountSteps();
            var actual = steps[1] * steps[3];

            // Assert
            actual.ShouldBe(220);
        }
        [Test]
        public void Part2_Example1_Arrangements_Should_Be_8()
        {
            // Arrange
            var inputs = new string[] {
            "16",
            "10",
            "15",
            "5",
            "1",
            "11",
            "7",
            "19",
            "6",
            "12",
            "4" };

            // Act
            adapterBag = new AdapterBag(inputs);
            var actual = adapterBag.CountArrangements();

            // Assert
            actual.ShouldBe(8);
        }
        [Test]
        public void Part2_Example2_Arrangements_Should_Be_19208()
        {
            // Arrange
            var inputs = new string[] {
            "28",
            "33",
            "18",
            "42",
            "31",
            "14",
            "46",
            "20",
            "48",
            "47",
            "24",
            "23",
            "49",
            "45",
            "19",
            "38",
            "39",
            "11",
            "1",
            "32",
            "25",
            "35",
            "8",
            "17",
            "7",
            "9",
            "4",
            "2",
            "34",
            "10",
            "3" };

            // Act
            adapterBag = new AdapterBag(inputs);
            var actual = adapterBag.CountArrangements();

            // Assert
            actual.ShouldBe(19208);
        }
    }
}