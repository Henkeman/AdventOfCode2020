using NUnit.Framework;
using Day07;
using Shouldly;

namespace Day07.Tests
{
    public class BagFinderTests
    {
        [Test]
        public void Part1_ShinyGoldIsIn_4()
        {
            // Arrange
            var input = new string[] {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."};

            var bagFinder = new BagFinder(input);
            
            // Act
            var actual = bagFinder.CountInAllBags("shiny gold");

            //Assert
            actual.ShouldBe(4);
        }
        [Test]
        public void Part2_ShinyGoldBag_Contain_126()
        {
            // Arrange
            var input = new string[] {
            "shiny gold bags contain 2 dark red bags.",
            "dark red bags contain 2 dark orange bags.",
            "dark orange bags contain 2 dark yellow bags.",
            "dark yellow bags contain 2 dark green bags.",
            "dark green bags contain 2 dark blue bags.",
            "dark blue bags contain 2 dark violet bags.",
            "dark violet bags contain no other bags."};

            var bagFinder = new BagFinder(input);
            // Act
            var actual = bagFinder.CountAllBagsIn("shiny gold");
            actual--; // don't count the shiny gold bag...
            //Assert

            actual.ShouldBe(126);
        }

        [Test]
        public void Part2_DarkBlueBag_Contain_2()
        {
            // Arrange
            var input = new string[] {
            "shiny gold bags contain 2 dark red bags.",
            "dark red bags contain 2 dark orange bags.",
            "dark orange bags contain 2 dark yellow bags.",
            "dark yellow bags contain 2 dark green bags.",
            "dark green bags contain 2 dark blue bags.",
            "dark blue bags contain 2 dark violet bags.",
            "dark violet bags contain no other bags."};

            var bagFinder = new BagFinder(input);
            // Act
            var actual = bagFinder.CountAllBagsIn("dark blue");
            actual--; // don't count the dark blue bag...
            //Assert

            actual.ShouldBe(2);
        }
    }
}