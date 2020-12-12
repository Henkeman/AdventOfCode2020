using System;
using System.IO;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines("input.txt");
            var count = new AdapterBag(inputs).CountArrangements();

            Console.WriteLine(count);
        }
    }
}
