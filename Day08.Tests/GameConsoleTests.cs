using Day08;
using NUnit.Framework;
using Shouldly;

namespace Day08.Tests
{
    public class GameConsoleTests
    {
        
        GameConsole gameConsole;

        [SetUp]
        public void Setup()
        {
            var input = new string[] {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"};

            gameConsole = new GameConsole(input);
        }

        [Test]
        public void Part1_GameConsoleBoot_Acc_Should_Be_5()
        {
            // Arrange

            // Act
            gameConsole.Boot();

            var actual = gameConsole.Accumulator;
            // Assert
            actual.ShouldBe(5);
        }

        [Test]
        public void Part2_GameConsoleBoot_Acc_Should_Be_8()
        {
            // Arrange

            // Act
            gameConsole.FixBoot();

            var actual = gameConsole.Accumulator;
            // Assert
            actual.ShouldBe(8);
        }
    }
}