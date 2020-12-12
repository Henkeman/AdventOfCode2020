using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{    public class Instruction
    {
        public string Operation { get; set; }
        public int Argument { get; set; }

        public Instruction(string input)
        {
            var instruction = input.Split(" ");
            Operation = instruction[0].Trim();
            Argument = Int32.Parse(instruction[1].Replace("+", "").Trim());
        }

        public void Fix()
        {
            if (Operation.Contains("nop"))
            {
                Operation = "jmp";
            }
            else if (Operation.Contains("jmp"))
            {
                Operation = "nop";
            }
        }
    }
}
