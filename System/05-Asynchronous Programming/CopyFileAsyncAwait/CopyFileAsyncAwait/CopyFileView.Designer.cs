namespace CopyFileAsyncAwait
{
    partial class CopyFileAsyncAwait
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
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnFile2 = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tbWhere = new System.Windows.Forms.TextBox();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.lbWhere = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(303, 90);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 9;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnFile2
            // 
            this.btnFile2.Location = new System.Drawing.Point(303, 50);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(75, 23);
            this.btnFile2.TabIndex = 7;
            this.btnFile2.Text = "File...";
            this.btnFile2.UseVisualStyleBackColor = true;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(303, 24);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 3;
            this.btnFile.Text = "File...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(22, 90);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(275, 23);
            this.progressBar.TabIndex = 10;
            // 
            // tbWhere
            // 
            this.tbWhere.Location = new System.Drawing.Point(69, 52);
            this.tbWhere.Name = "tbWhere";
            this.tbWhere.Size = new System.Drawing.Size(228, 20);
            this.tbWhere.TabIndex = 8;
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(69, 26);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(228, 20);
            this.tbFrom.TabIndex = 4;
            // 
            // lbWhere
            // 
            this.lbWhere.AutoSize = true;
            this.lbWhere.Location = new System.Drawing.Point(19, 55);
            this.lbWhere.Name = "lbWhere";
            this.lbWhere.Size = new System.Drawing.Size(42, 13);
            this.lbWhere.TabIndex = 5;
            this.lbWhere.Text = "Where:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(19, 29);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "From:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // CopyFileAsyncAwait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 137);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnFile2);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tbWhere);
            this.Controls.Add(this.tbFrom);
            this.Controls.Add(this.lbWhere);
            this.Controls.Add(this.lblFrom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CopyFileAsyncAwait";
            this.Text = "Copy file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnFile2;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox tbWhere;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.Label lbWhere;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

