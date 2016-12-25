using System;
using System.Collections.Generic;
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

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class FunctionInput
    {
        public double StartNum { get; set; }
        public double EndNum { get; set; }
        public double Step { get; set; }
        public double NValue { get; set; }
    }

    public class NumberRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo ci)
        {
            double num;
            if (!Double.TryParse((String)value, out num))
            {
                return new ValidationResult(false, "Input data must be a number");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            FunctionInput func = new FunctionInput();
            InitializeComponent();
            this.DataContext = func;
        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            textArea.Items.Clear();
            double start, step, end, number;
            if(Double.TryParse(startValue.Text, out start) &&
                Double.TryParse(endValue.Text, out end) &&
                Double.TryParse(stepValue.Text, out step) &&
                Double.TryParse(nValue.Text, out number))
                {
                    function(start, step, end, number);
                }
            else
            {
                textArea.Items.Add("Input data must be a number");
            }
        }

        private void function(double start, double step, double end, double number)
        {
            for (double x = start; x < end; x += step)
            {
                double s = 0;
                for (int k = 0; k < number; k++)
                {
                    s += Math.Pow(-1, k) * Math.Pow(x, 2 * k) / Factorial(2 * k);
                }
                double y = Math.Cos(x);
                string res = string.Format("x={0,-12:0.#}y={1,-12:0.####}s={2,-6:0.####}", x, y, s);
                textArea.Items.Add(res);
            }
        }

        public int Factorial(int k)
        {
            int f = 1;
            for (int i = 1; i <= k; i++)
            {
                f *= i;
            }
            return f;
        }
    }
}
