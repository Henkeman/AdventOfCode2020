using System;
using System.IO;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var gameConsole = new GameConsole(input);
            gameConsole.Boot();
            Console.WriteLine(gameConsole.Accumulator);
        }
    }
}
