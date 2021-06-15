namespace ExeRunner
{
    partial class ExeRunnerView
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
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.lblChooseFile = new System.Windows.Forms.Label();
            this.groupBoxChooseFile = new System.Windows.Forms.GroupBox();
            this.groupBoxChooseFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChooseFile.Location = new System.Drawing.Point(205, 27);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(276, 33);
            this.btnChooseFile.TabIndex = 0;
            this.btnChooseFile.Text = "Choose file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // lblChooseFile
            // 
            this.lblChooseFile.AutoSize = true;
            this.lblChooseFile.Font = new System.Drawing.Font("Microsoft YaHei Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblChooseFile.Location = new System.Drawing.Point(14, 31);
            this.lblChooseFile.Name = "lblChooseFile";
            this.lblChooseFile.Size = new System.Drawing.Size(154, 21);
            this.lblChooseFile.TabIndex = 1;
            this.lblChooseFile.Text = "Choose any exe file";
            // 
            // groupBoxChooseFile
            // 
            this.groupBoxChooseFile.Controls.Add(this.lblChooseFile);
            this.groupBoxChooseFile.Controls.Add(this.btnChooseFile);
            this.groupBoxChooseFile.Location = new System.Drawing.Point(11, 8);
            this.groupBoxChooseFile.Name = "groupBoxChooseFile";
            this.groupBoxChooseFile.Size = new System.Drawing.Size(495, 87);
            this.groupBoxChooseFile.TabIndex = 2;
            this.groupBoxChooseFile.TabStop = false;
            this.groupBoxChooseFile.Text = "Choose file to run";
            // 
            // ExeRunnerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 103);
            this.Controls.Add(this.groupBoxChooseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ExeRunnerView";
            this.Text = "Exe runner form";
            this.groupBoxChooseFile.ResumeLayout(false);
            this.groupBoxChooseFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label lblChooseFile;
        private System.Windows.Forms.GroupBox groupBoxChooseFile;
    }
}

