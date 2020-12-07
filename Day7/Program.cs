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

            var allBags = GetBagDictionary(input);

            var c = 0;

            Console.WriteLine(c);
        }

        private static Dictionary<string, Dictionary<string, int>> GetBagDictionary(string[] input)
        {
            var dict = new Dictionary<string, Dictionary<string, int>>();
            foreach (var row in input)
            {
                var bagrow = row.Replace(" bags", "").Replace(" bag", "").Replace(".", ""); //row cleanup
                var bagContent = new Dictionary<string, int>();

                var bagSplit = bagrow.Split(" contain ");
                var bagName = bagSplit[0];

                if (bagSplit[1] != "no other")
                {
                    var contents = bagSplit[1].Split(", ");
                    foreach (var item in contents)
                    {
                        var pos = item.IndexOf(' ');
                        var count = Int32.Parse(item.Substring(0, pos));
                        var color = item.Substring(pos).Trim();
                        bagContent.Add(color, count);
                    }
                }
                dict.Add(bagName, bagContent);
            }
            return dict;
        }
    }
}
