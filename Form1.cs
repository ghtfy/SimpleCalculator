using System;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string expression = textBox1.Text;
            string[] parts = expression.Split('+');

            if (parts.Length != 2)
            {
                MessageBox.Show("수식은 a+b 형식으로 입력하세요.");
                return;
            }

            int firstOperand;
            int secondOperand;

            if (!int.TryParse(parts[0], out firstOperand) || !int.TryParse(parts[1], out secondOperand))
            {
                MessageBox.Show("정수를 입력하세요.");
                return;
            }

            int result = firstOperand + secondOperand;
            textBox2.Text = result.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
