using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    public class XMAS
    {
        public long[] Stream { get; set; }

        public XMAS(string[] input)
        {
            Stream = input.Select(s => Int64.Parse(s)).ToArray();
        }

        public long Hack(int preamble)
        {
            for (int i = preamble; i < Stream.Length; i++)
            {
                if (!Checksum(Stream[i], new Span<long>(Stream, i - preamble, preamble)))
                {
                    return Stream[i];
                }
            }
            return -1;
        }

        private bool Checksum(long value, Span<long> source)
        {
            for (int i = 0; i < source.Length-1; i++)
            {
                for (int j = i+1; j < source.Length; j++)
                {
                    if (source[i] != source[j] && source[i] + source[j] == value)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public long Hack2(long target)
        {
            for (int i = 0; i < Stream.Length - 1; i++)
            {
                for (int j = i + 1; j < Stream.Length; j++)
                {
                    var span = new Span<long>(Stream, i, j-i).ToArray();
                    if (span.Sum() == target)
                    {
                        return span.Min() + span.Max();
                    }
                }
            }
            return -1;
        }
    }
}
