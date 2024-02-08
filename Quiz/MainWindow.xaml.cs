using Quiz.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

            string equation = numbers[0].ToString() + signs[rnd.Next(4)] + numbers[1].ToString();

            EquationLabel.Content = equation;

            DataTable dt = new DataTable();
            var v = dt.Compute(equation, "");
            SelectButtonOne.Content = v.ToString();
        }
    }
}
