using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    public class Character
    {
        private float _number;
        private string _mathSign;
        private int _priority;

        public float Number => _number;
        public int Priority => _priority;
        public string MathSign => _mathSign;

        public Character(string value)
        {
            _mathSign = value;
            SetPriority();
        }

        public Character(float value)
        {
            _number = value;
        }
        
        private void SetPriority()
        {
            if(_mathSign == "+" || _mathSign == "-")
                _priority =  -1;
            else if (_mathSign == "*" || _mathSign == "/")
                _priority =  0;
            else
                _priority = 2;
        }

        public void IncreasePriority()
        {
            _priority += 2;
        }
    }
}
