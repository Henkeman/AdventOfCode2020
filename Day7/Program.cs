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

        private static Dictionary<string, List<(int, string)>> GetBagDictionary(string[] input)
        {
            var dict = new Dictionary<string, List<(int, string)>>();
            foreach (var row in input)
            {
                var bagrow = row.Replace(" bags", "").Replace(" bag", "").Replace(".", ""); //row cleanup
                var bagContent = new List<(int, string)>();

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
                        bagContent.Add((count, color));
                    }
                }
                dict.Add(bagName, bagContent);
            }
            return dict;
        }
    }

    class Bag
    {
        public string Color { get; }
        public List<(int, string)> ContainedBags { get; }
        private List<Bag> _source;

        public Bag(string color, List<(int, string)> bags, List<Bag> source)
        {
            Color = color;
            ContainedBags = bags;
            _source = source;
        }

        public bool Contains(string search)
        {
            if (ContainedBags.Any(s => s.Item2 == search)) return true;

            List<Bag> searchBags = new List<Bag>();
            foreach (var bag in ContainedBags)
            {
                searchBags.Add(_source.Find(c => c.Color == search));
            }

            return searchBags.Any(b => b.Contains(search));
        }

        public Bag Search(string name)
        {
            return _source.Find(b => b.Color == name);
        }
    }
}
