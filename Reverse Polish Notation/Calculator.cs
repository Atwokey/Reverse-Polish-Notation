using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    public class Calculator
    {
        private float _number1;
        private float _number2;
        private float _result;
        private string _mathSign;

        public Calculator(float number1, float number2, string mathSign)
        {
            _number1 = number1;
            _number2 = number2;
            _result = 0;
            _mathSign = mathSign;
        }

        public void Calculate()
        {
            if (_mathSign == "+")
                Add();
            if (_mathSign == "-")
                Subtract();
            if (_mathSign == "*")
                Multiply();
            if (_mathSign == "/")
                Divide();
        }

        private void Add()
        {
            _result = _number1 + _number2;
        }

        private void Subtract() 
        {
            _result = _number1 - _number2;
        }

        private void Multiply()
        {
            _result = _number1 * _number2;
        }

        private void Divide()
        {
            _result = _number1 / _number2;
        }

        public float GetResult()
        {
            return _result;
        }
    }
}
