using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    public class ReversePolishNotation
    {
        private char[] _arrayExpression;
        private List<string> _outputList;
        private Stack<string> _stackOperations;
        private float _result;

        public ReversePolishNotation(string expression)
        {
            _arrayExpression = StringConversation(expression);
            _outputList = new List<string>();
            _stackOperations = new Stack<string>();
        }

        private char[] StringConversation(string expression)
        {
            return expression.Replace(" ", "").ToCharArray();
        }

        public void StartEvaluate()
        {
            Decomposition();
            GetOutputList();
            Сomputation();
        }

        private void Decomposition()
        {
            string fullNum = "";

            foreach(char character in _arrayExpression)
            {
                string ch = char.ToString(character);

                if(!ch.IsDigit() && ch != ".")
                {
                    AddList(fullNum);
                    fullNum = "";
                    AddStack(ch);
                    continue;
                }

                fullNum += ch;
            }

            AddList(fullNum);
            CleanStack();
        }

        private void AddList(string character)
        {
            if (!String.IsNullOrEmpty(character))
            {
                _outputList.Add(character);
            }
        }

        private void AddStack(string mathSign)
        {
            if(_stackOperations.Count > 0)
            {
                if(mathSign == ")")
                {
                    CleanStack();
                    return;
                }

                if ((GetPriority(_stackOperations.Peek()) >= GetPriority(mathSign)) && _stackOperations.Peek() != "(")
                    _outputList.Add(_stackOperations.Pop());
            }

            _stackOperations.Push(mathSign);
        }

        private void CleanStack()
        {
            while(true)
            {
                if (_stackOperations.Count == 0)
                    break;

                if(_stackOperations.Peek() == "(")
                {
                    _stackOperations.Pop();
                    break;
                }

                _outputList.Add(_stackOperations.Pop());
            }
        }

        private int GetPriority(string mathSign)
        {
            if (mathSign == "+" || mathSign == "-")
                return -1;

            if (mathSign == "*" || mathSign == "/")
                return 0;

            return 1;
        }

        private void Сomputation()
        {
            Stack<string> calculateStack = new Stack<string>();
            foreach (string character in _outputList)
            {
                if (!character.IsDigit())
                {
                    float value2 = float.Parse(calculateStack.Pop());
                    float value1 = (calculateStack.Count > 0) ? float.Parse(calculateStack.Pop()) : 0;

                    Calculator calculator = new Calculator(value1, value2, character);
                    calculator.Calculate();

                    calculateStack.Push(calculator.GetResult().ToString());
                    continue;
                }

                calculateStack.Push(character);
            }

            _result = float.Parse(calculateStack.Pop());
        }

        public float GetResult()
        {
            return _result;
        }

        private void GetOutputList()
        {
            foreach(string character in _outputList)
            {
                Console.WriteLine(character);
            }
        }
    }
}
