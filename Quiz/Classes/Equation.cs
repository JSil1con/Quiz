using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Classes
{
    internal class Equation
    {
        public char Sign { get; set; }
        public int[] Numbers { get; set; }
        public Equation(char sign, int[] numbers)
        {
            Sign = sign;
            Numbers = numbers;
        }

        public string ToString()
        {
            return Numbers[0].ToString() + Sign + Numbers[1].ToString();
        }
    }
}
