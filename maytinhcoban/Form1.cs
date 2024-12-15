using ArtanAcademy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maytinhcoban
{
    public partial class Form1 : Form
    {
        Double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnMathOperation_Click(object sender, EventArgs e)
        {
            if (result != 0) BtnEquals.PerformClick();
            else result = Double.Parse(TxtDisplay1.Text);

            ArtanButton button = (ArtanButton)sender;
            operation = button.Text;
            enterValue = true;
            if (TxtDisplay1.Text != "0")
            {
                TxtDisplay2.Text = fstNum = $"{result}{operation}";
                TxtDisplay1.Text = string.Empty;
            }
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            secNum = TxtDisplay1.Text;
            TxtDisplay2.Text = $"{TxtDisplay2.Text}{secNum}=";
            if (TxtDisplay1.Text != string.Empty)
            {
                switch (operation)
                {
                    case "+":
                        result += Double.Parse(TxtDisplay1.Text);
                        TxtDisplay1.Text = result.ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "-":
                        result -= Double.Parse(TxtDisplay1.Text);
                        TxtDisplay1.Text = result.ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "×":
                        result *= Double.Parse(TxtDisplay1.Text);
                        TxtDisplay1.Text = result.ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "÷":
                        result /= Double.Parse(TxtDisplay1.Text);
                        TxtDisplay1.Text = result.ToString();
                        RtBoxDisplayHistory.AppendText($"{fstNum}{secNum} = {TxtDisplay1.Text}\n");
                        break;
                    case "x^y":
                        TxtDisplay1.Text = Convert.ToString(Math.Pow(result, Double.Parse(secNum)));
                        RtBoxDisplayHistory.AppendText($"{result} ^ {secNum} = {TxtDisplay1.Text}\n");
                        break;
                    default:
                        TxtDisplay2.Text = $"{TxtDisplay1.Text}=";
                        break;
                }
                result = Double.Parse(TxtDisplay1.Text);
                operation = string.Empty; // Reset operation sau khi tính toán
            }
        }


        private void BtnClearHistory_Click(object sender, EventArgs e)
        {
            RtBoxDisplayHistory.Clear();
            if (RtBoxDisplayHistory.Text == string.Empty)
                RtBoxDisplayHistory.Text = "there's no history yet";
        }

        private void BtnBackSpace_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text.Length > 0)
                TxtDisplay1.Text = TxtDisplay1.Text.Remove(TxtDisplay1.Text.Length - 1, 1);
            if (TxtDisplay1.Text == string.Empty) TxtDisplay1.Text = "0";
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
            TxtDisplay2.Text = string.Empty;
            result = 0;
        }

        private void BtnCE_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
        }

        private void BtnOperation(object sender, EventArgs e)
        {
            ArtanButton button = (ArtanButton)sender;
            if (!string.IsNullOrEmpty(operation) && operation != "x^y") // Thực hiện phép toán trước đó
            {
                BtnEquals.PerformClick();
            }

            operation = button.Text;
            switch (operation)
            {
                case "√x":
                    TxtDisplay2.Text = $"√({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Math.Sqrt(Double.Parse(TxtDisplay1.Text)));
                    RtBoxDisplayHistory.AppendText($"{TxtDisplay2.Text}={TxtDisplay1.Text}\n");
                    break;
                case "x^y":
                    result = Double.Parse(TxtDisplay1.Text);
                    TxtDisplay2.Text = $"{result}^";
                    TxtDisplay1.Text = string.Empty;
                    enterValue = true;
                    break;
                case "1⁄x":
                    TxtDisplay2.Text = $"1/({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(1.0 / Convert.ToDouble(TxtDisplay1.Text));
                    RtBoxDisplayHistory.AppendText($"{TxtDisplay2.Text}={TxtDisplay1.Text}\n");
                    break;
                case "%":
                    TxtDisplay2.Text = $"%({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Convert.ToDouble(TxtDisplay1.Text) / 100);
                    RtBoxDisplayHistory.AppendText($"{TxtDisplay2.Text}={TxtDisplay1.Text}\n");
                    break;
                case "±":
                    double currentValue = Convert.ToDouble(TxtDisplay1.Text);
                    double toggledValue = -currentValue;
                    TxtDisplay2.Text = $"{currentValue} → {toggledValue}";
                    TxtDisplay1.Text = toggledValue.ToString();
                    RtBoxDisplayHistory.AppendText($"{TxtDisplay2.Text}\n");
                    break;
            }
        }



        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text == "0" || enterValue) TxtDisplay1.Text = string.Empty;
            enterValue = false;
            ArtanButton button = (ArtanButton)sender;
            if (button.Text == ".")
            {
                if (!TxtDisplay1.Text.Contains("."))
                    TxtDisplay1.Text = TxtDisplay1.Text + button.Text;
            }
            else TxtDisplay1.Text = TxtDisplay1.Text + button.Text;
        }
    }
}


