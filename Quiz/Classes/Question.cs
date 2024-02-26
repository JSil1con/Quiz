using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Classes
{
    internal class Question
    {
        public BigInteger CorrectAnswer { get; set; }
        public Equation Equation { get; set; }
        public BigInteger[] Answers { get; set; }

        public Question(Equation equation, BigInteger correctAnswer, BigInteger[] answers)
        {
            Equation = equation;
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }
    }
}
