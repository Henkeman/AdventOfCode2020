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
            var steps = adapterBag.CountSteps();

            Console.WriteLine(steps[1] * steps[3]);
        }
    }
}
