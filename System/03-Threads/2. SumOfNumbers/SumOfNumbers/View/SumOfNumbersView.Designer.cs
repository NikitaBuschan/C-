namespace sumOfNumbers.View
{
    partial class SumOfNumbersView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTwoStart = new System.Windows.Forms.Button();
            this.btnOneStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "0";
            // 
            // btnTwoStart
            // 
            this.btnTwoStart.Location = new System.Drawing.Point(223, 85);
            this.btnTwoStart.Name = "btnTwoStart";
            this.btnTwoStart.Size = new System.Drawing.Size(98, 23);
            this.btnTwoStart.TabIndex = 17;
            this.btnTwoStart.Text = "Start";
            this.btnTwoStart.UseVisualStyleBackColor = true;
            this.btnTwoStart.Click += new System.EventHandler(this.btnTwoStart_Click);
            // 
            // btnOneStart
            // 
            this.btnOneStart.Location = new System.Drawing.Point(35, 85);
            this.btnOneStart.Name = "btnOneStart";
            this.btnOneStart.Size = new System.Drawing.Size(98, 23);
            this.btnOneStart.TabIndex = 18;
            this.btnOneStart.Text = "Start";
            this.btnOneStart.UseVisualStyleBackColor = true;
            this.btnOneStart.Click += new System.EventHandler(this.btnOneStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 20);
            this.textBox1.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(199, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 20);
            this.textBox2.TabIndex = 16;
            // 
            // SumOfNumbersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 128);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTwoStart);
            this.Controls.Add(this.btnOneStart);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SumOfNumbersView";
            this.Text = "Sum of number";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTwoStart;
        private System.Windows.Forms.Button btnOneStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}