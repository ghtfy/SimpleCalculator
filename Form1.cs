using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private const int MaxDigitCount = 16;

        private readonly Random random = new Random();
        private readonly List<string> expressionTokens = new List<string>();

        private int equalsClickCount;
        private bool isResultDisplayed;
        private bool isAwaitingNextValue;

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

            btnOpenParen.Click += btnOpenParen_Click;
            btnCloseParen.Click += btnCloseParen_Click;

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

            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            AppendDigit(button.Text);
            UpdateExpressionDisplay();
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            char op;
            switch (button.Text)
            {
                case "+":
                    op = '+';
                    break;
                case "-":
                    op = '-';
                    break;
                case "x":
                    op = '*';
                    break;
                case "÷":
                    op = '/';
                    break;
                default:
                    return;
            }

            if (isResultDisplayed)
            {
                isResultDisplayed = false;
            }

            if (!isAwaitingNextValue)
            {
                if (!AppendCurrentInputToken())
                {
                    MessageBox.Show("숫자를 입력하세요.");
                    return;
                }
            }

            if (expressionTokens.Count == 0)
            {
                return;
            }

            if (IsOperatorToken(expressionTokens[expressionTokens.Count - 1]))
            {
                expressionTokens[expressionTokens.Count - 1] = op.ToString();
            }
            else if (expressionTokens[expressionTokens.Count - 1] != "(")
            {
                expressionTokens.Add(op.ToString());
            }

            txtinput.Text = "0";
            isAwaitingNextValue = true;
            UpdateExpressionDisplay();
        }

        private void btnOpenParen_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            if (isResultDisplayed)
            {
                expressionTokens.Clear();
                txtinput.Text = "0";
                isResultDisplayed = false;
                isAwaitingNextValue = false;
            }

            if (!isAwaitingNextValue)
            {
                if (txtinput.Text != "0")
                {
                    if (!AppendCurrentInputToken())
                    {
                        MessageBox.Show("숫자를 입력하세요.");
                        return;
                    }

                    expressionTokens.Add("*");
                }
            }
            else if (expressionTokens.Count > 0 && expressionTokens[expressionTokens.Count - 1] == ")")
            {
                expressionTokens.Add("*");
            }

            expressionTokens.Add("(");
            txtinput.Text = "0";
            isAwaitingNextValue = true;
            UpdateExpressionDisplay();
        }

        private void btnCloseParen_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            if (CountOpenParentheses() <= 0)
            {
                return;
            }

            if (!isAwaitingNextValue)
            {
                if (!AppendCurrentInputToken())
                {
                    MessageBox.Show("숫자를 입력하세요.");
                    return;
                }
            }

            if (expressionTokens.Count == 0)
            {
                return;
            }

            string last = expressionTokens[expressionTokens.Count - 1];
            if (IsOperatorToken(last) || last == "(")
            {
                return;
            }

            expressionTokens.Add(")");
            txtinput.Text = "0";
            isAwaitingNextValue = true;
            UpdateExpressionDisplay();
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
                expressionTokens.Clear();
                isResultDisplayed = true;
                isAwaitingNextValue = false;
                return;
            }

            List<string> tokensToEvaluate = new List<string>(expressionTokens);
            if (!isAwaitingNextValue)
            {
                double currentNumber;
                if (!TryParseNumber(txtinput.Text, out currentNumber))
                {
                    MessageBox.Show("숫자를 입력하세요.");
                    return;
                }

                tokensToEvaluate.Add(FormatNumber(currentNumber));
            }

            if (tokensToEvaluate.Count == 0)
            {
                return;
            }

            if (IsOperatorToken(tokensToEvaluate[tokensToEvaluate.Count - 1]))
            {
                return;
            }

            if (CountOpenParentheses(tokensToEvaluate) != 0)
            {
                MessageBox.Show("괄호가 올바르지 않습니다.");
                return;
            }

            double result;
            if (!EvaluateTokens(tokensToEvaluate, out result))
            {
                return;
            }

            string expressionText = BuildDisplayExpression(tokensToEvaluate);
            string formattedResult = FormatNumber(result);
            txtoutput.Text = string.Format("{0} = {1}", expressionText, formattedResult);
            txtinput.Text = formattedResult;

            if (IsRepeatedNineDigits(formattedResult))
            {
                MessageBox.Show("대단한 결과값이 나오셨네요!");
            }

            expressionTokens.Clear();
            isResultDisplayed = true;
            isAwaitingNextValue = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            if (isResultDisplayed)
            {
                txtinput.Text = "0";
                expressionTokens.Clear();
                isResultDisplayed = false;
                isAwaitingNextValue = false;
            }

            if (isAwaitingNextValue)
            {
                txtinput.Text = "0";
                isAwaitingNextValue = false;
            }

            if (!txtinput.Text.Contains("."))
            {
                txtinput.AppendText(".");
                UpdateExpressionDisplay();
            }
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            if (isAwaitingNextValue)
            {
                txtinput.Text = "0";
                isAwaitingNextValue = false;
            }

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

            UpdateExpressionDisplay();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();

            if (isResultDisplayed)
            {
                txtinput.Text = "0";
                expressionTokens.Clear();
                isResultDisplayed = false;
                isAwaitingNextValue = false;
                UpdateExpressionDisplay();
                return;
            }

            if (isAwaitingNextValue)
            {
                if (expressionTokens.Count > 0)
                {
                    expressionTokens.RemoveAt(expressionTokens.Count - 1);
                }

                isAwaitingNextValue = false;
                txtinput.Text = "0";
                UpdateExpressionDisplay();
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

            UpdateExpressionDisplay();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();
            txtinput.Text = "0";
            isResultDisplayed = false;
            if (!isAwaitingNextValue)
            {
                isAwaitingNextValue = expressionTokens.Count > 0;
            }
            UpdateExpressionDisplay();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            ResetEqualsClickCount();
            txtinput.Text = "0";
            txtoutput.Clear();
            expressionTokens.Clear();
            isResultDisplayed = false;
            isAwaitingNextValue = false;
            UpdateExpressionDisplay();
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
                expressionTokens.Clear();
                txtinput.Text = "0";
                isResultDisplayed = false;
                isAwaitingNextValue = false;
            }

            if (isAwaitingNextValue)
            {
                txtinput.Text = "0";
                isAwaitingNextValue = false;
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

        private bool AppendCurrentInputToken()
        {
            double value;
            if (!TryParseNumber(txtinput.Text, out value))
            {
                return false;
            }

            expressionTokens.Add(FormatNumber(value));
            return true;
        }

        private void UpdateExpressionDisplay()
        {
            if (expressionTokens.Count == 0)
            {
                txtoutput.Text = txtinput.Text;
                return;
            }

            List<string> displayTokens = new List<string>(expressionTokens);
            if (!isAwaitingNextValue)
            {
                double value;
                if (TryParseNumber(txtinput.Text, out value))
                {
                    displayTokens.Add(FormatNumber(value));
                }
            }

            txtoutput.Text = BuildDisplayExpression(displayTokens);
        }

        private string BuildDisplayExpression(List<string> tokens)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (i > 0)
                {
                    builder.Append(' ');
                }

                string token = tokens[i];
                if (token == "*")
                {
                    builder.Append("x");
                }
                else if (token == "/")
                {
                    builder.Append("÷");
                }
                else
                {
                    builder.Append(token);
                }
            }

            return builder.ToString();
        }

        private bool IsOperatorToken(string token)
        {
            return token == "+" || token == "-" || token == "*" || token == "/";
        }

        private int CountOpenParentheses()
        {
            return CountOpenParentheses(expressionTokens);
        }

        private int CountOpenParentheses(List<string> tokens)
        {
            int openCount = 0;
            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] == "(")
                {
                    openCount++;
                }
                else if (tokens[i] == ")")
                {
                    openCount--;
                }
            }

            return openCount;
        }

        private int GetPrecedence(string op)
        {
            if (op == "*" || op == "/")
            {
                return 2;
            }

            return 1;
        }

        private bool EvaluateTokens(List<string> tokens, out double result)
        {
            result = 0;
            Stack<double> values = new Stack<double>();
            Stack<string> operators = new Stack<string>();

            for (int i = 0; i < tokens.Count; i++)
            {
                string token = tokens[i];
                double number;
                if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
                {
                    values.Push(number);
                    continue;
                }

                if (token == "(")
                {
                    operators.Push(token);
                    continue;
                }

                if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                    {
                        if (!ApplyTopOperation(values, operators.Pop(), out result))
                        {
                            return false;
                        }
                    }

                    if (operators.Count == 0 || operators.Peek() != "(")
                    {
                        MessageBox.Show("괄호가 올바르지 않습니다.");
                        return false;
                    }

                    operators.Pop();
                    continue;
                }

                if (!IsOperatorToken(token))
                {
                    MessageBox.Show("수식을 확인해주세요.");
                    return false;
                }

                while (operators.Count > 0 && operators.Peek() != "(" && GetPrecedence(operators.Peek()) >= GetPrecedence(token))
                {
                    if (!ApplyTopOperation(values, operators.Pop(), out result))
                    {
                        return false;
                    }
                }

                operators.Push(token);
            }

            while (operators.Count > 0)
            {
                string op = operators.Pop();
                if (op == "(")
                {
                    MessageBox.Show("괄호가 올바르지 않습니다.");
                    return false;
                }

                if (!ApplyTopOperation(values, op, out result))
                {
                    return false;
                }
            }

            if (values.Count != 1)
            {
                MessageBox.Show("수식을 확인해주세요.");
                return false;
            }

            result = values.Pop();
            return true;
        }

        private bool ApplyTopOperation(Stack<double> values, string op, out double result)
        {
            result = 0;

            if (values.Count < 2)
            {
                MessageBox.Show("수식을 확인해주세요.");
                return false;
            }

            double right = values.Pop();
            double left = values.Pop();

            if (op == "+")
            {
                result = left + right;
            }
            else if (op == "-")
            {
                result = left - right;
            }
            else if (op == "*")
            {
                result = left * right;
            }
            else if (op == "/")
            {
                if (right == 0)
                {
                    MessageBox.Show("0으로 나눌 수 없습니다.");
                    return false;
                }

                result = left / right;
            }
            else
            {
                MessageBox.Show("수식을 확인해주세요.");
                return false;
            }

            values.Push(result);
            return true;
        }
    }
}
