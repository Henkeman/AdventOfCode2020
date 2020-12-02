using System;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var passwords = File.ReadAllLines("input.txt").Select(s => new Password(s)).ToList();
            Console.WriteLine(passwords.Where(s => s.IsValid()).Count());
        }
    }

    class Password
    {
        public int Min { get; }
        public int Max { get; }
        public char Character { get; }
        public string Pass { get; }

        public Password(string input) //input = 2-12 k: kkktrkwrbtck
        {
            var numberDividerPos = input.IndexOf('-');
            var passwordDividerPos = input.IndexOf(':');

            Min = Int32.Parse(input.Substring(0,numberDividerPos));
            Max = Int32.Parse(input.Substring(numberDividerPos+1, passwordDividerPos-numberDividerPos-2));
            Character = input[passwordDividerPos-1];
            Pass = input.Substring(passwordDividerPos +1, input.Length-passwordDividerPos-1);
        }

        public bool IsValid()
        {
            var count = Pass.Count(f => f == Character);
            return ((count >= Min) && (count <= Max));
        }
    }
}
