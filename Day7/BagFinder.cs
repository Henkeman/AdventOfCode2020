using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class BagFinder
    {
        public Dictionary<string, List<Bag>> AllBags { get; internal set; }

        public BagFinder(string[] input)
        {
            AllBags = GetBagDictionary(input);
        }

        private Dictionary<string, List<Bag>> GetBagDictionary(string[] input)
        {
            var dict = new Dictionary<string, List<Bag>>();
            foreach (var row in input)
            {
                var bagrow = row.Replace(" bags", "").Replace(" bag", "").Replace(".", ""); //row cleanup
                var bagContent = new List<Bag>();

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
                        bagContent.Add(new Bag(color, count));
                    }
                }
                dict.Add(bagName, bagContent);
            }
            return dict;
        }
        private bool FindBag(string bag, string color)
        {
            var bagQueue = new Queue<Bag>();
            GetChildBags(bag).ToList().ForEach(bagQueue.Enqueue);

            while (bagQueue.Count > 0)
            {
                var queuedBag = bagQueue.Dequeue();
                if (queuedBag.Color == color)
                {
                    return true;
                }
                else
                {
                    GetChildBags(queuedBag.Color).ToList().ForEach(bagQueue.Enqueue);
                }
            }

            return false;
        }

        private List<Bag> GetChildBags(string color)
        {
            AllBags.TryGetValue(color, out var childBags);
            return childBags;
        }

        internal int CountInAllBags(string color)
        {
            var count = 0;

            foreach (var bag in AllBags.Keys)
            {
                if (FindBag(bag, color))
                {
                    count++;
                }
            }

            return count;
        }

        public class Bag
        {
            public string Color { get; set; }
            public int Count { get; set; }
            public Bag(string color, int count)
            {
                Color = color;
                Count = count;
            }
        }
    }
}
