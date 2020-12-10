using Day9;
using NUnit.Framework;

namespace Day9Tests
{
    public class CryptTests
    {
        XMAS xmas;

        [Test]
        public void Test1()
        {
            // Arrange
            var input = new string[]
            {
                "35",
                "20",
                "15",
                "25",
                "47",
                "40",
                "62",
                "55",
                "65",
                "95",
                "102",
                "117",
                "150",
                "182",
                "127",
                "219",
                "299",
                "277",
                "309",
                "576"
            };
            xmas = new XMAS(input);

            // Act
            var actual = xmas.Hack(5);

            // Assert
            Assert.AreEqual(127, actual);
        }
    }
}