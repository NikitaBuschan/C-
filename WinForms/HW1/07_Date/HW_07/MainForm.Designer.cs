namespace HW_07
{
    partial class MainForm
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
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.makeLabel = new System.Windows.Forms.Label();
            this.TimeTolabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yearRadioButton = new System.Windows.Forms.RadioButton();
            this.secondRadioButton = new System.Windows.Forms.RadioButton();
            this.minuteRadioButton = new System.Windows.Forms.RadioButton();
            this.dayRadioButton = new System.Windows.Forms.RadioButton();
            this.monthRadioButton = new System.Windows.Forms.RadioButton();
            this.answerLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.CausesValidation = false;
            this.maskedTextBox.Location = new System.Drawing.Point(126, 24);
            this.maskedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.maskedTextBox.Mask = "00/00/0000";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(74, 20);
            this.maskedTextBox.TabIndex = 0;
            this.maskedTextBox.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox.TextChanged += new System.EventHandler(this.maskedTextBox_TextChanged);
            // 
            // makeLabel
            // 
            this.makeLabel.AutoSize = true;
            this.makeLabel.Location = new System.Drawing.Point(42, 27);
            this.makeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.makeLabel.Name = "makeLabel";
            this.makeLabel.Size = new System.Drawing.Size(62, 13);
            this.makeLabel.TabIndex = 1;
            this.makeLabel.Text = "Enter date: ";
            // 
            // TimeTolabel
            // 
            this.TimeTolabel.Location = new System.Drawing.Point(22, 69);
            this.TimeTolabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TimeTolabel.Name = "TimeTolabel";
            this.TimeTolabel.Size = new System.Drawing.Size(142, 19);
            this.TimeTolabel.TabIndex = 3;
            this.TimeTolabel.Text = "Время до указанной даты: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.yearRadioButton);
            this.groupBox1.Controls.Add(this.secondRadioButton);
            this.groupBox1.Controls.Add(this.minuteRadioButton);
            this.groupBox1.Controls.Add(this.dayRadioButton);
            this.groupBox1.Controls.Add(this.monthRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(25, 106);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(139, 152);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид отображения";
            // 
            // yearRadioButton
            // 
            this.yearRadioButton.AutoSize = true;
            this.yearRadioButton.Location = new System.Drawing.Point(20, 31);
            this.yearRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.yearRadioButton.Name = "yearRadioButton";
            this.yearRadioButton.Size = new System.Drawing.Size(47, 17);
            this.yearRadioButton.TabIndex = 6;
            this.yearRadioButton.Text = "Year";
            this.yearRadioButton.UseVisualStyleBackColor = true;
            this.yearRadioButton.CheckedChanged += new System.EventHandler(this.yearsRadioButton_CheckedChanged);
            // 
            // secondRadioButton
            // 
            this.secondRadioButton.AutoSize = true;
            this.secondRadioButton.Location = new System.Drawing.Point(20, 115);
            this.secondRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.secondRadioButton.Name = "secondRadioButton";
            this.secondRadioButton.Size = new System.Drawing.Size(62, 17);
            this.secondRadioButton.TabIndex = 6;
            this.secondRadioButton.Text = "Second";
            this.secondRadioButton.UseVisualStyleBackColor = true;
            this.secondRadioButton.CheckedChanged += new System.EventHandler(this.yearsRadioButton_CheckedChanged);
            // 
            // minuteRadioButton
            // 
            this.minuteRadioButton.AutoSize = true;
            this.minuteRadioButton.Location = new System.Drawing.Point(20, 94);
            this.minuteRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.minuteRadioButton.Name = "minuteRadioButton";
            this.minuteRadioButton.Size = new System.Drawing.Size(57, 17);
            this.minuteRadioButton.TabIndex = 5;
            this.minuteRadioButton.Text = "Minute";
            this.minuteRadioButton.UseVisualStyleBackColor = true;
            this.minuteRadioButton.CheckedChanged += new System.EventHandler(this.yearsRadioButton_CheckedChanged);
            // 
            // dayRadioButton
            // 
            this.dayRadioButton.AutoSize = true;
            this.dayRadioButton.Location = new System.Drawing.Point(20, 73);
            this.dayRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.dayRadioButton.Name = "dayRadioButton";
            this.dayRadioButton.Size = new System.Drawing.Size(44, 17);
            this.dayRadioButton.TabIndex = 4;
            this.dayRadioButton.Text = "Day";
            this.dayRadioButton.UseVisualStyleBackColor = true;
            this.dayRadioButton.CheckedChanged += new System.EventHandler(this.yearsRadioButton_CheckedChanged);
            // 
            // monthRadioButton
            // 
            this.monthRadioButton.AutoSize = true;
            this.monthRadioButton.Location = new System.Drawing.Point(20, 52);
            this.monthRadioButton.Margin = new System.Windows.Forms.Padding(2);
            this.monthRadioButton.Name = "monthRadioButton";
            this.monthRadioButton.Size = new System.Drawing.Size(55, 17);
            this.monthRadioButton.TabIndex = 3;
            this.monthRadioButton.Text = "Month";
            this.monthRadioButton.UseVisualStyleBackColor = true;
            this.monthRadioButton.CheckedChanged += new System.EventHandler(this.yearsRadioButton_CheckedChanged);
            // 
            // answerLabel
            // 
            this.answerLabel.Location = new System.Drawing.Point(168, 69);
            this.answerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(99, 19);
            this.answerLabel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 276);
            this.Controls.Add(this.answerLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TimeTolabel);
            this.Controls.Add(this.makeLabel);
            this.Controls.Add(this.maskedTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Time to date";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Label makeLabel;
        private System.Windows.Forms.Label TimeTolabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton secondRadioButton;
        private System.Windows.Forms.RadioButton minuteRadioButton;
        private System.Windows.Forms.RadioButton dayRadioButton;
        private System.Windows.Forms.RadioButton monthRadioButton;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.RadioButton yearRadioButton;
    }
}