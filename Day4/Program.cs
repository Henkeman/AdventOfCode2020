using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            int result = CountValidPassports(input);
            Console.WriteLine(result);
        }

        private static int CountValidPassports(string[] input)
        {
            var passportRows = SeparatePassportRows(input);
            var passports = CreatePassportDictionaries(passportRows);
            var validPassports = ValidatePassports(passports);

            return validPassports;
        }

        private static int ValidatePassports(List<Dictionary<string, string>> passports)
        {
            var count = 0;

            foreach (var passport in passports)
            {
                //Console.WriteLine(string.Join(Environment.NewLine, passport));
                if (passport.Count == 8 || (passport.Count == 7 && !passport.ContainsKey("cid")))
                {
                    count++;
                }
            }

            return count;
            
        }

        private static List<Dictionary<string, string>> CreatePassportDictionaries(IEnumerable<string> passportsInput)
        {
            var passports = new List<Dictionary<string, string>>();

            foreach (var item in passportsInput)
            {
                var passport = new Dictionary<string, string>();
                var kvps = item.Split(' ');
                foreach (var kvpRow in kvps)
                {
                    if (kvpRow.Contains(':'))
                    {
                        var kvp = kvpRow.Split(':');
                        passport.Add(kvp[0].Trim(), kvp[1].Trim());
                    }
                }

                passports.Add(passport);
            }

            return passports;
        }

        private static IEnumerable<string> SeparatePassportRows(string[] input)
        {
            var passportStrings = new List<string>();
            var passportRows = new StringBuilder();

            foreach (var row in input)
            {
                if (string.IsNullOrWhiteSpace(row))
                {
                    passportStrings.Add(passportRows.ToString());
                    passportRows.Clear();
                }
                else
                {
                    passportRows.Append(" " + row);
                }
            }
            passportStrings.Add(passportRows.ToString());

            return passportStrings;
        }
    }
}
