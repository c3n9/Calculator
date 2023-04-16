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
using static System.Net.Mime.MediaTypeNames;

namespace Calc.Pages
{
    /// <summary>
    /// Логика взаимодействия для PMain.xaml
    /// </summary>
    public partial class PMain : Page
    {
        string mathAction = "";
        double num; 
        public PMain()
        {
            InitializeComponent();
        }

        private void AddNumberForLabel_Click(object sender, RoutedEventArgs e)
        {
            if (Label.Text.Length == 8)
                return;
            else
                Label.Text += ((Button)sender).Content;
        }

        private void BackSpace_Click(object sender, RoutedEventArgs e)
        {
            Label.Text =  string.Concat(Label.Text.Skip(0).Take(Label.Text.Length - 1));
        }

        private void BCLear_Click(object sender, RoutedEventArgs e)
        {
            Label.Text = "";
            num = 0;
        }
        private void MathsAction_Click(object sender, RoutedEventArgs e)
        {
            if(Validation() == false)
                return;
            mathAction = ((Button)sender).Content as string;
            num = double.Parse(Label.Text);
            Label.Text = "";
        }

        private void BResult_Click(object sender, RoutedEventArgs e)
        {
            if (num != null && Label.Text == "0")
            {
                MessageBox.Show("На ноль делить нельзя");
                return;
            }
            if (Validation() == false)
                return;
            if (mathAction == "×")
                Label.Text = Convert.ToString(num * double.Parse(Label.Text));
            if (mathAction == "/")
                Label.Text = Convert.ToString(num / double.Parse(Label.Text));
            if (mathAction == "-")
                Label.Text = Convert.ToString(num - double.Parse(Label.Text));
            if (mathAction == "+")
                Label.Text = Convert.ToString(num + double.Parse(Label.Text));
            if(Label.Text.Length > 8)
            {
                while (Label.Text.Length != 8)
                {
                    Label.Text = Label.Text.Substring(0, Label.Text.Length - 1);
                }
            }
            
        }

        private void PosOrNeg_Click(object sender, RoutedEventArgs e)
        {
            Label.Text = Convert.ToString(double.Parse(Label.Text) * (-1));
        }

        private bool Validation()
        {
            if (Label.Text == "" || Label.Text == ",")
                return false;
            return true;
        }
    }
}
