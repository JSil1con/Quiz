using System;
using System.Collections.Generic;
using System.Data;
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

        public int CalculateCorrectAnswer()
        {
            DataTable dt = new DataTable();
            return Int32.Parse(dt.Compute(this.ToString(), "").ToString());
        }
    }
}
