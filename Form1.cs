using System;
using System.Globalization;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private const int MaxDigitCount = 16;

        private readonly Random random = new Random();
        private int equalsClickCount;

        private double firstOperand;
        private char currentOperator = '\0';
        private bool hasFirstOperand;
        private bool isResultDisplayed;

        public Form1()
        {
            InitializeComponent();
            txtinput.Text = "0";
            KeyPreview = true;
            KeyDown += Form1_KeyDown;
            WireEvents();
        }

        private void WireEvents()
        {
            btnNum0.Click += NumberButton_Click;
            btnNum1.Click += NumberButton_Click;
            btnNum2.Click += NumberButton_Click;
            btnNum3.Click += NumberButton_Click;
            btnNum4.Click += NumberButton_Click;
            btnNum5.Click += NumberButton_Click;
            btnNum6.Click += NumberButton_Click;
            btnNum7.Click += NumberButton_Click;
            btnNum8.Click += NumberButton_Click;
            btnNum9.Click += NumberButton_Click;

            btnAdd.Click += OperatorButton_Click;
            btnSubtract.Click += OperatorButton_Click;
            btnMultiply.Click += OperatorButton_Click;
            btnDivide.Click += OperatorButton_Click;

            btnDot.Click += btnDot_Click;
            btnPlusMinus.Click += btnPlusMinus_Click;
            btnDel.Click += btnDel_Click;
            btnCE.Click += btnCE_Click;
            btnC.Click += btnC_Click;
            button1.Click += button1_Click;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            AppendDigit(button.Text);
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            double value;
            if (!TryParseNumber(txtinput.Text, out value))
            {
                MessageBox.Show("숫자를 입력하세요.");
                return;
            }

            firstOperand = value;
            hasFirstOperand = true;
            isResultDisplayed = false;

            switch (button.Text)
            {
                case "+":
                    currentOperator = '+';
                    break;
                case "-":
                    currentOperator = '-';
                    break;
                case "x":
                    currentOperator = '*';
                    break;
                case "÷":
                    currentOperator = '/';
                    break;
                default:
                    currentOperator = '\0';
                    break;
            }

            txtoutput.Text = string.Format("{0} {1}", FormatNumber(firstOperand), button.Text);
            txtinput.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            equalsClickCount++;
            if (equalsClickCount >= 3)
            {
                int randomNumber = random.Next(1, 101);
                txtoutput.Text = "랜덤 숫자 생성";
                txtinput.Text = randomNumber.ToString();
                MessageBox.Show(string.Format("랜덤 숫자: {0}", randomNumber));

                equalsClickCount = 0;
                hasFirstOperand = false;
                currentOperator = '\0';
                isResultDisplayed = true;
                return;
            }

            if (!hasFirstOperand || currentOperator == '\0')
            {
                return;
            }

            double secondOperand;
            if (!TryParseNumber(txtinput.Text, out secondOperand))
            {
                MessageBox.Show("숫자를 입력하세요.");
                return;
            }

            double result;
            switch (currentOperator)
            {
                case '+':
                    result = firstOperand + secondOperand;
                    break;
                case '-':
                    result = firstOperand - secondOperand;
                    break;
                case '*':
                    result = firstOperand * secondOperand;
                    break;
                case '/':
                    if (secondOperand == 0)
                    {
                        MessageBox.Show("0으로 나눌 수 없습니다.");
                        return;
                    }
                    result = firstOperand / secondOperand;
                    break;
                default:
                    return;
            }

            string formattedResult = FormatNumber(result);
            string opText = currentOperator == '*' ? "x" : currentOperator == '/' ? "÷" : currentOperator.ToString();
            txtoutput.Text = string.Format("{0} {1} {2} = {3}", FormatNumber(firstOperand), opText, FormatNumber(secondOperand), formattedResult);
            txtinput.Text = formattedResult;

            if (IsRepeatedNineDigits(formattedResult))
            {
                MessageBox.Show("대단한 결과값이 나오셨네요!");
            }

            hasFirstOperand = false;
            currentOperator = '\0';
            isResultDisplayed = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            if (isResultDisplayed)
            {
                txtinput.Text = "0";
                isResultDisplayed = false;
            }

            if (!txtinput.Text.Contains("."))
            {
                txtinput.AppendText(".");
            }
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            if (txtinput.Text == "0")
            {
                return;
            }

            if (txtinput.Text.StartsWith("-"))
            {
                txtinput.Text = txtinput.Text.Substring(1);
            }
            else
            {
                txtinput.Text = "-" + txtinput.Text;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            if (isResultDisplayed)
            {
                txtinput.Text = "0";
                isResultDisplayed = false;
                return;
            }

            if (string.IsNullOrEmpty(txtinput.Text) || txtinput.Text == "0")
            {
                return;
            }

            txtinput.Text = txtinput.Text.Substring(0, txtinput.Text.Length - 1);
            if (txtinput.Text.Length == 0 || txtinput.Text == "-")
            {
                txtinput.Text = "0";
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();
            txtinput.Text = "0";
            isResultDisplayed = false;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();
            txtinput.Text = "0";
            txtoutput.Clear();
            firstOperand = 0;
            currentOperator = '\0';
            hasFirstOperand = false;
            isResultDisplayed = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                AppendDigit(((int)(e.KeyCode - Keys.D0)).ToString());
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                AppendDigit(((int)(e.KeyCode - Keys.NumPad0)).ToString());
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Delete)
            {
                btnCE_Click(btnCE, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                btnC_Click(btnC, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Back)
            {
                btnDel_Click(btnDel, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void AppendDigit(string digit)
        {
            if (isResultDisplayed)
            {
                txtinput.Text = "0";
                isResultDisplayed = false;
            }

            string current = txtinput.Text.Replace("-", string.Empty).Replace(".", string.Empty);
            if (current.Length >= MaxDigitCount)
            {
                MessageBox.Show("그만 누르세요");
                return;
            }

            if (txtinput.Text == "0")
            {
                txtinput.Text = digit;
            }
            else
            {
                txtinput.AppendText(digit);
            }
        }

        private bool TryParseNumber(string text, out double value)
        {
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value))
            {
                return true;
            }

            return double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
        }

        private string FormatNumber(double value)
        {
            return value.ToString("0.############", CultureInfo.InvariantCulture);
        }

        private bool IsRepeatedNineDigits(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length != 9)
            {
                return false;
            }

            char first = value[0];
            if (!char.IsDigit(first))
            {
                return false;
            }

            for (int i = 1; i < value.Length; i++)
            {
                if (value[i] != first)
                {
                    return false;
                }
            }

            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void ResetEqualsClickCount()
        {
            equalsClickCount = 0;
        }
    }
}
