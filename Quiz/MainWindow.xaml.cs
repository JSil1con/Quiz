using Quiz.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rnd = new Random();
        private Question _question;
        private Equation _equation;
        private FileHandler _fileHandler;
        private int _score;
        private string _outputFilePath;

        public MainWindow()
        {
            InitializeComponent();

            _outputFilePath = "score.json";
            Dictionary<string, int> contentFile;


            //Checks if file exists
            if (File.Exists(_outputFilePath))
            {
                //File exists
                contentFile = JsonSerializer.Deserialize<Dictionary<string, int>>(File.ReadAllText(_outputFilePath));
                _score = contentFile["score"];
            }
            else
            {
                //File doesn't exist
                contentFile = new Dictionary<string, int>
                {
                    { "score", 0 }
                };
            }

            //Recreate the file + save score
            _fileHandler = new FileHandler(_outputFilePath);
            _fileHandler.Write(JsonSerializer.Serialize(contentFile));

            Score.Content = _score;

            CreateEquation();
        }

        private void CreateEquation()
        {
            char[] signs = { '+', '-', '*', '/' };

            //Min, max numbers in the equation + number of operands
            int minNumber = 0;
            int maxNumber = Math.Max(10, _score * 2);
            int numberOfOperands = Math.Max(2, _score / 15);

            //Numbers and signs in the equation
            int[] numbers = new int[numberOfOperands];
            char[] selectedSigns = new char[numberOfOperands - 1];

            for (int i = 0; i < numberOfOperands; i++)
            {
                //Select random number
                numbers[i] = rnd.Next(minNumber, maxNumber);

                //Count of signs - 1 than numbers
                if (i < numberOfOperands - 1)
                {
                    //Select random sign
                    selectedSigns[i] = signs[rnd.Next(signs.Length)];
                }
            }

            _equation = new Equation(selectedSigns, numbers);

            //Write equation to the label
            EquationLabel.Content = _equation.ToString();

            //Buttons and then shuffle them
            Button[] buttons = {ButtonOne,  ButtonTwo, ButtonThree};
            Button[] shuffledButtons = buttons.OrderBy(x => rnd.Next()).ToArray();

            //Answers
            float correctAnswer = _equation.CalculateCorrectAnswer();
            float[] wrongAnswers = _equation.CalculateWrongAnswers(2);
            float[] answers = { wrongAnswers[0], wrongAnswers[1], correctAnswer };


            _question = new Question(_equation, correctAnswer, answers);

            //Write content to buttons
            shuffledButtons[0].Content = correctAnswer.ToString();
            shuffledButtons[1].Content = wrongAnswers[0].ToString();
            shuffledButtons[2].Content = wrongAnswers[1].ToString();
        }

        //Function executed after button is clicked
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            //Get answer
            string answer = (e.Source as Button).Content.ToString();

            if (float.Parse(answer) == _equation.CorrectAnswer)
            {
                //Answer is correct
                _score += 10;
            }
            else
            {
                //Answer is not correct
                _score = 0;
            }

            CreateEquation();

            //Write score to the label
            Score.Content = _score;

            //Save the score to the file
            Dictionary<string, int> contentFile = new Dictionary<string, int>
            {
                { "score", _score }
            };

            _fileHandler.Write(JsonSerializer.Serialize(contentFile));
        }
    }
}
