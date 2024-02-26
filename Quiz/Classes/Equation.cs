using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Classes
{
    internal class Equation
    {
        public char[] Signs { get; set; }
        public int[] Numbers { get; set; }
        public BigInteger CorrectAnswer { get; set; }
        public string EquationString { get; set; }
        DataTable dt = new DataTable();
        Random rnd = new Random();
        public Equation(char[] signs, int[] numbers)
        {
            Signs = signs;
            Numbers = numbers;
            EquationString = PrepareEquation();
            if (CanCalculate())
            {
                CorrectAnswer = CalculateCorrectAnswer();
            }
        }

        public string GetEquationString()
        {
            string equationString = Numbers[0].ToString();
            for (int i = 0; i < Signs.Length; i++)
            {
                equationString += " " + Signs[i] + " " + Numbers[i + 1].ToString();
            }
            return equationString;
        }

        public string PrepareEquation()
        {
            string expression = Numbers[0].ToString();
            for (int i = 0; i < Signs.Length; i++)
            {
                expression += Signs[i] + Numbers[i + 1].ToString();
            }
            return expression;
        }

        public bool CanCalculate()
        {
            try
            {
                CalculateCorrectAnswer();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public BigInteger CalculateCorrectAnswer()
        {
            return BigInteger.Parse(dt.Compute(EquationString, "").ToString());
        }

        public BigInteger CalculateWrongAnswer(char sign)
        {
            BigInteger randomNumber = rnd.Next(8);
            BigInteger result = 0;
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

        public BigInteger[] CalculateWrongAnswers(int countWrongAnswers)
        {
            List<BigInteger> wrongAnswers = new List<BigInteger>();

            //Signs to calculate wrong answers
            char[] signs = { '+', '-' };


            for (int i = 0; i < countWrongAnswers; i++)
            {
                char randomSign = signs[rnd.Next(signs.Length)];
                BigInteger wrongAnswer = CalculateWrongAnswer(randomSign);

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
