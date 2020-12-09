using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class GameConsole
    {
        public Instruction[] Instructions { get; set; }
        private List<int> InstructionsRun { get; set; } = new List<int>();
        public int Accumulator { get; private set; } = 0;

        public GameConsole(string[] input)
        {
            Instructions = ParseInstructions(input);
        }

        private Instruction[] ParseInstructions(string[] input)
        {
            return input.Select(s => new Instruction(s)).ToArray();
        }

        public void Boot()
        {
            int pointer = 0;

            while (!InstructionsRun.Contains(pointer))
            {
                InstructionsRun.Add(pointer);

                var instruction = Instructions[pointer];

                switch (instruction.Operation)
                {
                    case "nop":
                        pointer++;
                        break;
                    case "acc":
                        pointer++;
                        Accumulator += instruction.Argument;
                        break;
                    case "jmp":
                        pointer += instruction.Argument;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
