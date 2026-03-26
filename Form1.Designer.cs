namespace SimpleCalculator
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtinput = new System.Windows.Forms.TextBox();
            this.txtoutput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCE = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnNum7 = new System.Windows.Forms.Button();
            this.btnNum8 = new System.Windows.Forms.Button();
            this.btnNum9 = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnNum4 = new System.Windows.Forms.Button();
            this.btnNum5 = new System.Windows.Forms.Button();
            this.btnNum6 = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnNum1 = new System.Windows.Forms.Button();
            this.btnNum2 = new System.Windows.Forms.Button();
            this.btnNum3 = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPlusMinus = new System.Windows.Forms.Button();
            this.btnNum0 = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtinput
            // 
            this.txtinput.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtinput.Location = new System.Drawing.Point(20, 101);
            this.txtinput.Name = "txtinput";
            this.txtinput.ReadOnly = true;
            this.txtinput.Size = new System.Drawing.Size(340, 42);
            this.txtinput.TabIndex = 1;
            this.txtinput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtoutput
            // 
            this.txtoutput.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtoutput.Location = new System.Drawing.Point(20, 49);
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.ReadOnly = true;
            this.txtoutput.Size = new System.Drawing.Size(340, 42);
            this.txtoutput.TabIndex = 0;
            this.txtoutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(280, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 48);
            this.button1.TabIndex = 22;
            this.button1.Text = "=";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 23;
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCE
            // 
            this.btnCE.Font = new System.Drawing.Font("굴림", 14F);
            this.btnCE.Location = new System.Drawing.Point(20, 152);
            this.btnCE.Name = "btnCE";
            this.btnCE.Size = new System.Drawing.Size(80, 48);
            this.btnCE.TabIndex = 2;
            this.btnCE.Text = "CE";
            this.btnCE.UseVisualStyleBackColor = true;
            // 
            // btnC
            // 
            this.btnC.Font = new System.Drawing.Font("굴림", 14F);
            this.btnC.Location = new System.Drawing.Point(106, 152);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(80, 48);
            this.btnC.TabIndex = 3;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("굴림", 14F);
            this.btnDel.Location = new System.Drawing.Point(192, 152);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(80, 48);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "del";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnDivide
            // 
            this.btnDivide.Font = new System.Drawing.Font("굴림", 14F);
            this.btnDivide.ForeColor = System.Drawing.Color.Red;
            this.btnDivide.Location = new System.Drawing.Point(278, 152);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(80, 48);
            this.btnDivide.TabIndex = 5;
            this.btnDivide.Text = "÷";
            this.btnDivide.UseVisualStyleBackColor = true;
            // 
            // btnNum7
            // 
            this.btnNum7.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum7.ForeColor = System.Drawing.Color.Blue;
            this.btnNum7.Location = new System.Drawing.Point(20, 206);
            this.btnNum7.Name = "btnNum7";
            this.btnNum7.Size = new System.Drawing.Size(80, 48);
            this.btnNum7.TabIndex = 6;
            this.btnNum7.Text = "7";
            this.btnNum7.UseVisualStyleBackColor = true;
            // 
            // btnNum8
            // 
            this.btnNum8.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum8.ForeColor = System.Drawing.Color.Blue;
            this.btnNum8.Location = new System.Drawing.Point(106, 206);
            this.btnNum8.Name = "btnNum8";
            this.btnNum8.Size = new System.Drawing.Size(80, 48);
            this.btnNum8.TabIndex = 7;
            this.btnNum8.Text = "8";
            this.btnNum8.UseVisualStyleBackColor = true;
            // 
            // btnNum9
            // 
            this.btnNum9.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum9.ForeColor = System.Drawing.Color.Blue;
            this.btnNum9.Location = new System.Drawing.Point(192, 206);
            this.btnNum9.Name = "btnNum9";
            this.btnNum9.Size = new System.Drawing.Size(80, 48);
            this.btnNum9.TabIndex = 8;
            this.btnNum9.Text = "9";
            this.btnNum9.UseVisualStyleBackColor = true;
            // 
            // btnMultiply
            // 
            this.btnMultiply.Font = new System.Drawing.Font("굴림", 14F);
            this.btnMultiply.ForeColor = System.Drawing.Color.Red;
            this.btnMultiply.Location = new System.Drawing.Point(278, 206);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(80, 48);
            this.btnMultiply.TabIndex = 9;
            this.btnMultiply.Text = "x";
            this.btnMultiply.UseVisualStyleBackColor = true;
            // 
            // btnNum4
            // 
            this.btnNum4.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum4.ForeColor = System.Drawing.Color.Blue;
            this.btnNum4.Location = new System.Drawing.Point(20, 260);
            this.btnNum4.Name = "btnNum4";
            this.btnNum4.Size = new System.Drawing.Size(80, 48);
            this.btnNum4.TabIndex = 10;
            this.btnNum4.Text = "4";
            this.btnNum4.UseVisualStyleBackColor = true;
            // 
            // btnNum5
            // 
            this.btnNum5.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum5.ForeColor = System.Drawing.Color.Blue;
            this.btnNum5.Location = new System.Drawing.Point(106, 260);
            this.btnNum5.Name = "btnNum5";
            this.btnNum5.Size = new System.Drawing.Size(80, 48);
            this.btnNum5.TabIndex = 11;
            this.btnNum5.Text = "5";
            this.btnNum5.UseVisualStyleBackColor = true;
            // 
            // btnNum6
            // 
            this.btnNum6.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum6.ForeColor = System.Drawing.Color.Blue;
            this.btnNum6.Location = new System.Drawing.Point(192, 260);
            this.btnNum6.Name = "btnNum6";
            this.btnNum6.Size = new System.Drawing.Size(80, 48);
            this.btnNum6.TabIndex = 12;
            this.btnNum6.Text = "6";
            this.btnNum6.UseVisualStyleBackColor = true;
            // 
            // btnSubtract
            // 
            this.btnSubtract.Font = new System.Drawing.Font("굴림", 14F);
            this.btnSubtract.ForeColor = System.Drawing.Color.Red;
            this.btnSubtract.Location = new System.Drawing.Point(278, 260);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(80, 48);
            this.btnSubtract.TabIndex = 13;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = true;
            // 
            // btnNum1
            // 
            this.btnNum1.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum1.ForeColor = System.Drawing.Color.Blue;
            this.btnNum1.Location = new System.Drawing.Point(20, 314);
            this.btnNum1.Name = "btnNum1";
            this.btnNum1.Size = new System.Drawing.Size(80, 48);
            this.btnNum1.TabIndex = 14;
            this.btnNum1.Text = "1";
            this.btnNum1.UseVisualStyleBackColor = true;
            // 
            // btnNum2
            // 
            this.btnNum2.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum2.ForeColor = System.Drawing.Color.Blue;
            this.btnNum2.Location = new System.Drawing.Point(106, 314);
            this.btnNum2.Name = "btnNum2";
            this.btnNum2.Size = new System.Drawing.Size(80, 48);
            this.btnNum2.TabIndex = 15;
            this.btnNum2.Text = "2";
            this.btnNum2.UseVisualStyleBackColor = true;
            // 
            // btnNum3
            // 
            this.btnNum3.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum3.ForeColor = System.Drawing.Color.Blue;
            this.btnNum3.Location = new System.Drawing.Point(192, 314);
            this.btnNum3.Name = "btnNum3";
            this.btnNum3.Size = new System.Drawing.Size(80, 48);
            this.btnNum3.TabIndex = 16;
            this.btnNum3.Text = "3";
            this.btnNum3.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("굴림", 14F);
            this.btnAdd.ForeColor = System.Drawing.Color.Red;
            this.btnAdd.Location = new System.Drawing.Point(280, 314);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 48);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnPlusMinus
            // 
            this.btnPlusMinus.Font = new System.Drawing.Font("굴림", 14F);
            this.btnPlusMinus.Location = new System.Drawing.Point(20, 380);
            this.btnPlusMinus.Name = "btnPlusMinus";
            this.btnPlusMinus.Size = new System.Drawing.Size(80, 48);
            this.btnPlusMinus.TabIndex = 18;
            this.btnPlusMinus.Text = "+/-";
            this.btnPlusMinus.UseVisualStyleBackColor = true;
            // 
            // btnNum0
            // 
            this.btnNum0.Font = new System.Drawing.Font("굴림", 14F);
            this.btnNum0.ForeColor = System.Drawing.Color.Blue;
            this.btnNum0.Location = new System.Drawing.Point(106, 380);
            this.btnNum0.Name = "btnNum0";
            this.btnNum0.Size = new System.Drawing.Size(80, 48);
            this.btnNum0.TabIndex = 19;
            this.btnNum0.Text = "0";
            this.btnNum0.UseVisualStyleBackColor = true;
            // 
            // btnDot
            // 
            this.btnDot.Font = new System.Drawing.Font("굴림", 14F);
            this.btnDot.Location = new System.Drawing.Point(192, 380);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(80, 48);
            this.btnDot.TabIndex = 20;
            this.btnDot.Text = ".";
            this.btnDot.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 470);
            this.Controls.Add(this.btnDot);
            this.Controls.Add(this.btnNum0);
            this.Controls.Add(this.btnPlusMinus);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnNum3);
            this.Controls.Add(this.btnNum2);
            this.Controls.Add(this.btnNum1);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btnNum6);
            this.Controls.Add(this.btnNum5);
            this.Controls.Add(this.btnNum4);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnNum9);
            this.Controls.Add(this.btnNum8);
            this.Controls.Add(this.btnNum7);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btnCE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtoutput);
            this.Controls.Add(this.txtinput);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Simple Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtinput;
        private System.Windows.Forms.TextBox txtoutput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCE;
        private System.Windows.Forms.Button btnC;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnNum7;
        private System.Windows.Forms.Button btnNum8;
        private System.Windows.Forms.Button btnNum9;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btnNum4;
        private System.Windows.Forms.Button btnNum5;
        private System.Windows.Forms.Button btnNum6;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Button btnNum1;
        private System.Windows.Forms.Button btnNum2;
        private System.Windows.Forms.Button btnNum3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPlusMinus;
        private System.Windows.Forms.Button btnNum0;
        private System.Windows.Forms.Button btnDot;
    }
}

