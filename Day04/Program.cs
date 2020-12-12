using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day04
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
                bool isValid = true;
                //Console.WriteLine(string.Join(Environment.NewLine, passport));
                if (passport.Count == 8 || (passport.Count == 7 && !passport.ContainsKey("cid")))
                {
                    try
                    {
                        foreach (var item in passport)
                        {
                            switch (item.Key)
                            {
                                case "byr": //four digits; at least 1920 and at most 2002.
                                    if (!(int.Parse(item.Value) >= 1920 && int.Parse(item.Value) <= 2002)) isValid = false;
                                    break;
                                case "iyr": //four digits; at least 2010 and at most 2020.
                                    if (!(int.Parse(item.Value) >= 2010 && int.Parse(item.Value) <= 2020)) isValid = false;
                                    break;
                                case "eyr": //four digits; at least 2020 and at most 2030.
                                    if (!(int.Parse(item.Value) >= 2020 && int.Parse(item.Value) <= 2030)) isValid = false;
                                    break;
                                case "hgt": //a number followed by either cm or in:
                                    //If cm, the number must be at least 150 and at most 193.
                                    //If in, the number must be at least 59 and at most 76.
                                    if (item.Value.EndsWith("cm"))
                                    {
                                        int height = int.Parse(item.Value.Remove(item.Value.LastIndexOf("cm")));
                                        if (!(height >= 150 && height <= 193)) isValid = false;
                                    }
                                    else if (item.Value.EndsWith("in"))
                                    {
                                        int height = int.Parse(item.Value.Remove(item.Value.LastIndexOf("in")));
                                        if (!(height >= 59 && height <= 76)) isValid = false;
                                    }
                                    else
                                    {
                                        isValid = false;
                                    }
                                    break;
                                case "hcl": //a # followed by exactly six characters 0-9 or a-f.
                                    if (!(Regex.Match(item.Value, @"^#[0-9a-f]{6}$")).Success) isValid = false;
                                    break;
                                case "ecl": //exactly one of: amb blu brn gry grn hzl oth.
                                    var colors = new List<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                    var ecl = colors.Contains(item.Value);
                                    if (!ecl) isValid = false;
                                    break;
                                case "pid": //a nine-digit number, including leading zeroes.

                                    if (!(Regex.Match(item.Value, "^[0-9]{9}$")).Success) isValid = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    catch
                    {
                        isValid = false;
                    }
                }
                else isValid = false;

                if (isValid) count++;
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
