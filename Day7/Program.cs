using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    class Program
    {        
        static void Main(string[] args)
        {
            // dark purple bags contain 4 dim salmon bags, 4 faded maroon bags, 2 drab red bags, 1 clear bronze bag.
            // dim green bags contain no other bags.
            //var input = File.ReadAllLines("input.txt");
            var input = new string[] {"red bags contain 1 blue bag, 2 green bags", "shiny gold bag contain 1 red bag", "green bag contain no other bags", "blue bag contain no other bag" };
            var bagFinder = new BagFinder(input);
            var c = bagFinder.CountAllBagsIn("shiny gold");
            c++; // count the shiny gold bag.

            Console.WriteLine(c);
        }
    }
}
