using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void regularButtonClick(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text == "Error!") { txtInput.Text = null; }
            txtInput.Text = $"{txtInput.Text}{((Button)sender).Content.ToString()}";
        }

        private void operationButton_Click(object sender, RoutedEventArgs e)
        { txtInput.Text += ((Button)sender).Content.ToString(); }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result();
            }
            catch (Exception)
            {
                txtInput.Text = "Error!";
            }
        }

        private void result()
        {
            String op;
            int iOp = 0;
            if (txtInput.Text.Contains("+"))
                iOp = txtInput.Text.IndexOf("+");

            else if (txtInput.Text.Contains("-"))
                iOp = txtInput.Text.IndexOf("-");

            else if (txtInput.Text.Contains("*"))
                iOp = txtInput.Text.IndexOf("*");

            else if (txtInput.Text.Contains("/"))
                iOp = txtInput.Text.IndexOf("/");
            else
            {
                //error    
            }

            op = txtInput.Text.Substring(iOp, 1);
            decimal op1 = Convert.ToDecimal(txtInput.Text.Substring(0, iOp));
            decimal op2 = Convert.ToDecimal(txtInput.Text.Substring(iOp + 1, txtInput.Text.Length - iOp - 1));
            txtInput.Text = null;

            if (op == "+")
            {
                txtInput.Text = $"{op1 + op2}";
            }
            else if (op == "-")
            {
                txtInput.Text = $"{op1 - op2}";
            }
            else if (op == "*")
            {
                txtInput.Text = $"{op1 * op2}";
            }
            else 
            {
                txtInput.Text = $"{op1 / op2}";
            }
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        { txtInput.Text = null; }

        private void btnClearEntry_Click(object sender, RoutedEventArgs e)
        { txtInput.Text = txtInput.Text.Remove(txtInput.Text.Length - 1); }

        private void btnRoot_Click(object sender, RoutedEventArgs e)
        { txtInput.Text = $"{Math.Sqrt(double.Parse(txtInput.Text))}"; }

        private void btnSquare_Click(object sender, RoutedEventArgs e)
        { txtInput.Text = $"{decimal.Parse(txtInput.Text) * decimal.Parse(txtInput.Text)}"; }
    }
}
