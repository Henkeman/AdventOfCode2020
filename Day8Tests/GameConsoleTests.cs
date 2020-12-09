using Day8;
using NUnit.Framework;

namespace Day8Tests
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
            Assert.AreEqual(5, actual);
        }
    }
}