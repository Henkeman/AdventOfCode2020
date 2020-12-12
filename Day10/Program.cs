using System;
using System.IO;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines("input.txt");
            var adapterBag = new AdapterBag(inputs);
            var count = adapterBag.CountArrangements();

            Console.WriteLine(count);
        }
    }
}
