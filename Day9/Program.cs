using System;
using System.IO;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var crypt = new XMAS(input);
            var target = crypt.Hack(25);
            var output = crypt.Hack2(target);
            Console.WriteLine(output);
        }
    }
}
