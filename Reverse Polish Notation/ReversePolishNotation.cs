using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    public class ReversePolishNotation
    {
        private string _expression;
        private List<Character> _expressionList;
        private List<Character> _outputList;
        private Stack<Character> _stackOperations;
        private float _result;

        public float Result => _result;

        public ReversePolishNotation(string expression)
        {
            _expression = expression;
            _expressionList = new List<Character>();
            _outputList = new List<Character>();
            _stackOperations = new Stack<Character>();
        }

        public void Start()
        {
            Сonvert();
            //GetExpressionList();
            Decompose();
            //GetOutputList();
            Compute();
        }

        private void Сonvert()
        {
            char[] characterArray = _expression.Replace(" ", "").ToCharArray();
            string number = String.Empty;

            for (int i = 0; i < characterArray.Length; i++)
            {
                if (char.ToString(characterArray[i]).IsDigit() || characterArray[i] == '.')
                {
                    number += characterArray[i];
                    continue;
                }
                
                if (!String.IsNullOrEmpty(number))
                    _expressionList.Add(GetCharacter(number, true));

                _expressionList.Add(GetCharacter(char.ToString(characterArray[i]), false));

                if (characterArray[i] == '-' && !char.ToString(characterArray[i - 1]).IsDigit()
                                             && characterArray[i - 1] != '.' 
                                             && characterArray [i - 1] != ')')
                {
                    Console.WriteLine("I work");
                    _expressionList[_expressionList.Count - 1].IncreasePriority();
                    _expressionList.Add(GetCharacter("0", true));
                }
                
                number = String.Empty;
            }

            if (!String.IsNullOrEmpty(number))
                _expressionList.Add(GetCharacter(number, true));
        }

        private Character GetCharacter(string letter, bool isDigit)
        => (isDigit) ? new Character(float.Parse(letter)) : new Character(letter);

        private void Decompose()
        {
            for (int i = 0; i < _expressionList.Count; i++)
            {
                if (string.IsNullOrEmpty(_expressionList[i].MathSign))
                {
                    _outputList.Add(_expressionList[i]);   
                }
                else
                {
                    if (_expressionList[i].MathSign == ")")
                    {
                        CleanStack();
                        continue;
                    }

                    if (_stackOperations.Count > 0)
                        if (_stackOperations.Peek().Priority >= _expressionList[i].Priority && _stackOperations.Peek().MathSign != "(")
                            _outputList.Add(_stackOperations.Pop());

                    _stackOperations.Push(_expressionList[i]);
                }
            }
            
            CleanStack();
        }

        private void CleanStack()
        {
            while (_stackOperations.Count > 0)
            {
                if (_stackOperations.Peek().MathSign == "(")
                {
                    _stackOperations.Pop();
                    continue;
                }

                _outputList.Add(_stackOperations.Pop());
            }
        }

        private void Compute()
        {
             Stack<Character> calculateStack = new Stack<Character>();
             
             foreach (Character value in _outputList)
             {
                 if (!String.IsNullOrEmpty(value.MathSign))
                 {
                     float number2 = calculateStack.Pop().Number;
                     float number1 = (calculateStack.Count > 0) ? calculateStack.Pop().Number : 0;

                     Calculator calculator = new Calculator(number1, number2, value.MathSign);
                     calculator.Calculate();

                     calculateStack.Push(new Character(calculator.GetResult()));
                     Console.WriteLine(calculateStack.Peek().Number);
                     continue;
                 }

                 calculateStack.Push(value);
                 
             }

            _result = calculateStack.Pop().Number;
         }
      
        private void GetOutputList()
        {
            
            foreach(Character character in _outputList)
            {
                if (!String.IsNullOrEmpty(character.MathSign))
                    Console.WriteLine(character.MathSign);
                else
                    Console.WriteLine(character.Number);
            }
        }
        
        private void GetExpressionList()
        {
            
            foreach(Character character in _expressionList)
            {
                if (!String.IsNullOrEmpty(character.MathSign))
                    Console.WriteLine(character.MathSign);
                else
                    Console.WriteLine(character.Number);
            }
        }
    }
}
