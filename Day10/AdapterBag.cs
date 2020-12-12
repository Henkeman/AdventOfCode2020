using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class AdapterBag
    {
        public int[] Adapters { get; set; }
        public AdapterBag(IEnumerable<string> inputs)
        {
            inputs = inputs.Append("0");
            Adapters = inputs.Select(s => Int32.Parse(s)).OrderBy(i => i).ToArray();
        }

        public Dictionary<int, int> CountSteps()
        {
            var steps = new Dictionary<int, int>();

            for (int i = 1; i < Adapters.Length; i++)
            {
                var previous = Adapters[i - 1];
                var step = Adapters[i] - previous;

                if (!steps.TryAdd(step, 1))
                {
                    steps[step]++;
                }
            }

            steps[3]++; // Built in adapter

            return steps;
        }
        

        public long CountArrangements(int pos = 0, Dictionary<int, long> cache = null)
        {
            if (cache == null)
            {
                cache = new Dictionary<int, long>();
            }

            long result = 0;

            if (pos == Adapters.Length -1)
                return 1; // reached the end
            if (cache.TryGetValue(pos, out result)) // found in cache
            {
                return result;
            }

            for (int i = pos + 1; i < Adapters.Length; i++)
            {
                if (Adapters[i] - Adapters[pos] <= 3)
                {
                    result += CountArrangements(i, cache);
                }
            }

            cache.Add(pos, result);

            return cache[pos];
        }
    }
}
