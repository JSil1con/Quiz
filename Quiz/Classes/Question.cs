using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Classes
{
    internal class Question
    {
        public int CorrectAnswer { get; set; }
        public Equation Equation { get; set; }
        public int[] Answers { get; set; }

        public Question(Equation equation)
        {
            Equation = equation;
        }
    }
}
