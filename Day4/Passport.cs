using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    /*
    byr (Birth Year)
    iyr(Issue Year)
    eyr(Expiration Year)
    hgt(Height)
    hcl(Hair Color)
    ecl(Eye Color)
    pid(Passport ID)
    cid(Country ID)
    */
    class Passport
    {
        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        public Passport(string passportInput)
        {
            var passport = new Dictionary<string, string>();
            var kvps = passportInput.Split(' ');
            foreach (var kvp in kvps)
            {
                var asdf = kvp.Split(':');
                passport.Add(asdf[0].Trim(), asdf[1].Trim());
            }
        }
    }
}
