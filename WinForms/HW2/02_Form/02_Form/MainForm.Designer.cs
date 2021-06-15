namespace _02_Form
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.groupBoxFormWrite = new System.Windows.Forms.GroupBox();
            this.labelCityWrite = new System.Windows.Forms.Label();
            this.labelAgeWrite = new System.Windows.Forms.Label();
            this.labelSurnameWrite = new System.Windows.Forms.Label();
            this.labelNameWrite = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            this.groupBoxFormWrite.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 39);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(41, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name: ";
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Location = new System.Drawing.Point(6, 67);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(52, 13);
            this.labelSurname.TabIndex = 0;
            this.labelSurname.Text = "Surname:";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(6, 95);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(29, 13);
            this.labelAge.TabIndex = 0;
            this.labelAge.Text = "Age:";
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(8, 123);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(27, 13);
            this.labelCity.TabIndex = 0;
            this.labelCity.Text = "City:";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.textBoxAge);
            this.groupBox.Controls.Add(this.textBoxName);
            this.groupBox.Controls.Add(this.textBoxCity);
            this.groupBox.Controls.Add(this.textBoxSurname);
            this.groupBox.Controls.Add(this.labelName);
            this.groupBox.Controls.Add(this.labelCity);
            this.groupBox.Controls.Add(this.labelSurname);
            this.groupBox.Controls.Add(this.labelAge);
            this.groupBox.Location = new System.Drawing.Point(12, 11);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(226, 158);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Form";
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(67, 88);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(138, 20);
            this.textBoxAge.TabIndex = 2;
            this.textBoxAge.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(67, 32);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(138, 20);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(67, 116);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(138, 20);
            this.textBoxCity.TabIndex = 3;
            this.textBoxCity.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(67, 60);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(138, 20);
            this.textBoxSurname.TabIndex = 1;
            this.textBoxSurname.TextChanged += new System.EventHandler(this.textBox_Changed);
            // 
            // groupBoxFormWrite
            // 
            this.groupBoxFormWrite.Controls.Add(this.labelCityWrite);
            this.groupBoxFormWrite.Controls.Add(this.labelAgeWrite);
            this.groupBoxFormWrite.Controls.Add(this.labelSurnameWrite);
            this.groupBoxFormWrite.Controls.Add(this.labelNameWrite);
            this.groupBoxFormWrite.Controls.Add(this.label1);
            this.groupBoxFormWrite.Controls.Add(this.label2);
            this.groupBoxFormWrite.Controls.Add(this.label3);
            this.groupBoxFormWrite.Controls.Add(this.label4);
            this.groupBoxFormWrite.Location = new System.Drawing.Point(253, 11);
            this.groupBoxFormWrite.Name = "groupBoxFormWrite";
            this.groupBoxFormWrite.Size = new System.Drawing.Size(226, 158);
            this.groupBoxFormWrite.TabIndex = 1;
            this.groupBoxFormWrite.TabStop = false;
            this.groupBoxFormWrite.Text = "Profile";
            // 
            // labelCityWrite
            // 
            this.labelCityWrite.Location = new System.Drawing.Point(69, 122);
            this.labelCityWrite.Name = "labelCityWrite";
            this.labelCityWrite.Size = new System.Drawing.Size(138, 16);
            this.labelCityWrite.TabIndex = 3;
            // 
            // labelAgeWrite
            // 
            this.labelAgeWrite.Location = new System.Drawing.Point(69, 94);
            this.labelAgeWrite.Name = "labelAgeWrite";
            this.labelAgeWrite.Size = new System.Drawing.Size(138, 16);
            this.labelAgeWrite.TabIndex = 2;
            // 
            // labelSurnameWrite
            // 
            this.labelSurnameWrite.Location = new System.Drawing.Point(69, 66);
            this.labelSurnameWrite.Name = "labelSurnameWrite";
            this.labelSurnameWrite.Size = new System.Drawing.Size(138, 16);
            this.labelSurnameWrite.TabIndex = 1;
            // 
            // labelNameWrite
            // 
            this.labelNameWrite.Location = new System.Drawing.Point(69, 38);
            this.labelNameWrite.Name = "labelNameWrite";
            this.labelNameWrite.Size = new System.Drawing.Size(138, 16);
            this.labelNameWrite.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "City:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Surname:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Age:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 181);
            this.Controls.Add(this.groupBoxFormWrite);
            this.Controls.Add(this.groupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Profile";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBoxFormWrite.ResumeLayout(false);
            this.groupBoxFormWrite.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.GroupBox groupBoxFormWrite;
        private System.Windows.Forms.Label labelCityWrite;
        private System.Windows.Forms.Label labelAgeWrite;
        private System.Windows.Forms.Label labelSurnameWrite;
        private System.Windows.Forms.Label labelNameWrite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

