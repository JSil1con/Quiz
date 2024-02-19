using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Classes
{
    internal class Question
    {
        public float CorrectAnswer { get; set; }
        public Equation Equation { get; set; }
        public float[] Answers { get; set; }

        public Question(Equation equation, float correctAnswer, float[] answers)
        {
            Equation = equation;
            CorrectAnswer = correctAnswer;
            Answers = answers;
        }
    }
}
