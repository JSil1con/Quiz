using Quiz.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
        public MainWindow()
        {
            InitializeComponent();
            CreateEquation();
        }

        private void CreateEquation()
        {
            char[] signs = { '+', '-', '*', '/' };

            int[] numbers = { rnd.Next(100), rnd.Next(100) };
            char selectedSign = signs[rnd.Next(4)];

            _equation = new Equation(selectedSign, numbers);

            EquationLabel.Content = _equation.ToString();

            Button[] buttons = {ButtonOne,  ButtonTwo, ButtonThree};

            Button[] shuffledButtons = ShuffleButtons(buttons);


            float correctAnswer = _equation.CalculateCorrectAnswer();
            float[] wrongAnswers = _equation.CalculateWrongAnswers(2);
            float[] answers = { wrongAnswers[0], wrongAnswers[1], correctAnswer };


            _question = new Question(_equation, correctAnswer, answers);

            shuffledButtons[0].Content = correctAnswer.ToString();
            shuffledButtons[1].Content = wrongAnswers[0].ToString();
            shuffledButtons[2].Content = wrongAnswers[1].ToString();
        }

        private Button[] ShuffleButtons(Button[] buttons)
        {
            return buttons.OrderBy(x => rnd.Next()).ToArray();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            string answer = (e.Source as Button).Content.ToString();

            if (float.Parse(answer) == _equation.CorrectAnswer)
            {
                CreateEquation();
            }
        }
    }
}
