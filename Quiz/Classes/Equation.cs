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
        public char[] Signs { get; set; }
        public int[] Numbers { get; set; }
        public float CorrectAnswer { get; set; }
        DataTable dt = new DataTable();
        Random rnd = new Random();
        public Equation(char[] signs, int[] numbers)
        {
            Signs = signs;
            Numbers = numbers;
            CorrectAnswer = CalculateCorrectAnswer();
        }

        public string ToString()
        {
            string equationString = Numbers[0].ToString();
            for (int i = 0; i < Signs.Length; i++)
            {
                equationString += " " + Signs[i] + " " + Numbers[i + 1].ToString();
            }
            return equationString;
        }

        public float CalculateCorrectAnswer()
        {
            string expression = Numbers[0].ToString();
            for (int i = 0; i < Signs.Length; i++)
            {
                expression += Signs[i] + Numbers[i + 1].ToString();
            }
            return float.Parse(dt.Compute(expression, "").ToString());
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

            //Signs to calculate wrong answers
            char[] signs = { '+', '-' };


            for (int i = 0; i < countWrongAnswers; i++)
            {
                char randomSign = signs[rnd.Next(signs.Length)];
                float wrongAnswer = CalculateWrongAnswer(randomSign);

                //Calculate answer while answer is not the same as previous one + as correct answer
                while (wrongAnswers.Contains(wrongAnswer) || wrongAnswer == CorrectAnswer)
                {
                    wrongAnswer = CalculateWrongAnswer(randomSign);
                }
                wrongAnswers.Add(wrongAnswer);
            }

            return wrongAnswers.ToArray();
        }
    }
}
