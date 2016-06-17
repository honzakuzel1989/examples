using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(">Type expression or quit and press [Enter].");

            while (true)
            {
                Write(">");
                string input = ReadLine();
                input = input.Trim();

                if (input == "quit")
                    break;

                Expression exp = new Expression(input);
                Write("<");
                try { WriteLine(exp.Evaluate()); }
                catch (Exception ex) { WriteLine(ex.Message); }
            }
        }
    }
}
