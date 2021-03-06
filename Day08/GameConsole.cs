﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    public class GameConsole
    {
        public Instruction[] Instructions { get; private set; }

        private readonly string[] _originalInstructions;

        private List<int> InstructionsRun { get; set; } = new List<int>();
        public int Accumulator { get; private set; } = 0;
        public int Pointer { get; set; }

        public GameConsole(string[] input)
        {
            Instructions = ParseInstructions(input);
            _originalInstructions = input;
        }

        private Instruction[] ParseInstructions(string[] input)
        {
            return input.Select(s => new Instruction(s)).ToArray();
        }

        public bool Boot()
        {
            while (!InstructionsRun.Contains(Pointer))
            {
                if (Pointer < 0 || Pointer >= Instructions.Length)
                {
                    return false;
                }

                InstructionsRun.Add(Pointer);

                var instruction = Instructions[Pointer];

                switch (instruction.Operation)
                {
                    case "nop":
                        Pointer++;
                        break;
                    case "acc":
                        Pointer++;
                        Accumulator += instruction.Argument;
                        break;
                    case "jmp":
                        Pointer += instruction.Argument;
                        break;
                    default:
                        break;
                }
                if (Pointer >= Instructions.Length) return true;
            }
            return false;
        }
        public void FixBoot()
        {
            int fixPos = 0;
            var finishedRun = false;
            while (!finishedRun)
            {
                Reset();
                Instructions[fixPos].Fix();
                fixPos++;

                finishedRun = Boot();
            }
        }
    public void Reset()
    {
        InstructionsRun.Clear();
        Accumulator = 0;
        Pointer = 0;
        Instructions = ParseInstructions(_originalInstructions);
    }
}
}
