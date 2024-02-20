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
        public float CorrectAnswer { get; set; }
        DataTable dt = new DataTable();
        Random rnd = new Random();
        public Equation(char sign, int[] numbers)
        {
            Sign = sign;
            Numbers = numbers;
            CorrectAnswer = CalculateCorrectAnswer();
        }

        public string ToString()
        {
            return Numbers[0].ToString() + Sign + Numbers[1].ToString();
        }

        public float CalculateCorrectAnswer()
        {
            return float.Parse(dt.Compute(Numbers[0].ToString() + Sign + Numbers[1].ToString(), "").ToString());
        }

        public float CalculateWrongAnswer(char sign)
        {
            float randomNumber = rnd.Next(8);
            float result = float.NaN;
            switch (sign)
            {
                case '+':
                    result = CorrectAnswer + randomNumber;
                    break;
                case '-':
                    result = CorrectAnswer - randomNumber;
                    break;
                case '*':
                    result = CorrectAnswer * randomNumber;
                    break;
                case '/':
                    result = CorrectAnswer / randomNumber;
                    break;
            }
            return result;
        }

        public float[] CalculateWrongAnswers(int countWrongAnswers)
        {
            List<float> wrongAnswers = new List<float>();
            List<char> signs = new List<char> { '+',  '-' };
            signs.Remove(Sign);


            for (int i = 0; i < 2; i++)
            {
                char randomSign = signs[rnd.Next(signs.Count)];
                wrongAnswers.Add(CalculateWrongAnswer(randomSign));
                signs.Remove(randomSign);
            }

            return wrongAnswers.ToArray();
        }
    }
}
