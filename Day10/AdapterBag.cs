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
        public AdapterBag(string[] inputs)
        {
            Adapters = inputs.Select(s => Int32.Parse(s)).OrderBy(i => i).ToArray();
        }

        public Dictionary<int, int> CountSteps()
        {
            var steps = new Dictionary<int, int>();

            for (int i = 0; i < Adapters.Length; i++)
            {
                var previous = i > 0 ? Adapters[i - 1] : 0;
                var step = Adapters[i] - previous;

                if (!steps.TryAdd(step, 1))
                {
                    steps[step]++;
                }
            }

            steps[3]++; // Built in adapter

            return steps;
        }
    }
}
