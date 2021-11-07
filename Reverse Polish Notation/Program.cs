using System;

namespace Reverse_Polish_Notation
{
    class Program
    {
        static void Main(string[] args)
        {
            ReversePolishNotation rpn = new ReversePolishNotation("12*-1");
            rpn.StartEvaluate();
            Console.WriteLine(rpn.GetResult());
        }
    }
}
