using System;

namespace Reverse_Polish_Notation
{
    class Program
    {
        static void Main(string[] args)
        {
            ReversePolishNotation rpn = new ReversePolishNotation("(123.45*(678.90 / (-2.5+ 11.5)-(((80 -(19))) *33.25)) / 20) - (123.45*(678.90 / (-2.5+ 11.5)-(((80 -(19))) *33.25)) / 20) + (13 - 2)/ -(-11)");
            rpn.Start();
            Console.WriteLine(rpn.Result);
        }
    }
}
