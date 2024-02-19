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
        private Question _question;
        public MainWindow()
        {
            InitializeComponent();
            CreateEquation();
        }

        private void CreateEquation()
        {
            char[] signs = { '+', '-', '*', '/' };

            Random rnd = new Random();
            int[] numbers = { rnd.Next(100), rnd.Next(100) };
            char selectedSign = signs[rnd.Next(4)];

            Equation equation = new Equation(selectedSign, numbers);

            _question = new Question(equation);

            EquationLabel.Content = equation.ToString();

            SelectButtonOne.Content = equation.Calculate();
        }
    }
}
