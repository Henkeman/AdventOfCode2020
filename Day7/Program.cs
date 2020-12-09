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
            var input = File.ReadAllLines("input.txt");
            var bagFinder = new BagFinder(input);
            
            var c = bagFinder.CountInAllBags("shiny gold");

            Console.WriteLine(c);
        }
    }
}
