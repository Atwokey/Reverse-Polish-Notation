using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Polish_Notation
{
    public static class Extensions
    {
        public static bool IsDigit(this String s)
        {
            float result;
            return float.TryParse(s, out result);
        }
    }
}
