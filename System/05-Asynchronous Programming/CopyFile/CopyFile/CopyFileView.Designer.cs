namespace CopyFile
{
    partial class CopyFile
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
            this.lblFrom = new System.Windows.Forms.Label();
            this.lbWhere = new System.Windows.Forms.Label();
            this.tbFrom = new System.Windows.Forms.TextBox();
            this.tbWhere = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnFile2 = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(20, 31);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            this.lblFrom.Click += new System.EventHandler(this.lblFrom_Click);
            // 
            // lbWhere
            // 
            this.lbWhere.AutoSize = true;
            this.lbWhere.Location = new System.Drawing.Point(20, 57);
            this.lbWhere.Name = "lbWhere";
            this.lbWhere.Size = new System.Drawing.Size(42, 13);
            this.lbWhere.TabIndex = 0;
            this.lbWhere.Text = "Where:";
            this.lbWhere.Click += new System.EventHandler(this.lbWhere_Click);
            // 
            // tbFrom
            // 
            this.tbFrom.Location = new System.Drawing.Point(70, 28);
            this.tbFrom.Name = "tbFrom";
            this.tbFrom.Size = new System.Drawing.Size(228, 20);
            this.tbFrom.TabIndex = 0;
            this.tbFrom.TextChanged += new System.EventHandler(this.tbFrom_TextChanged);
            // 
            // tbWhere
            // 
            this.tbWhere.Location = new System.Drawing.Point(70, 54);
            this.tbWhere.Name = "tbWhere";
            this.tbWhere.Size = new System.Drawing.Size(228, 20);
            this.tbWhere.TabIndex = 1;
            this.tbWhere.TextChanged += new System.EventHandler(this.tbWhere_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(23, 92);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(275, 23);
            this.progressBar.TabIndex = 2;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(304, 26);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(75, 23);
            this.btnFile.TabIndex = 0;
            this.btnFile.Text = "File...";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnFile2
            // 
            this.btnFile2.Location = new System.Drawing.Point(304, 52);
            this.btnFile2.Name = "btnFile2";
            this.btnFile2.Size = new System.Drawing.Size(75, 23);
            this.btnFile2.TabIndex = 1;
            this.btnFile2.Text = "File...";
            this.btnFile2.UseVisualStyleBackColor = true;
            this.btnFile2.Click += new System.EventHandler(this.btnFile2_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(304, 92);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // CopyFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 140);
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
            this.Name = "CopyFile";
            this.Text = "Copy file";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lbWhere;
        private System.Windows.Forms.TextBox tbFrom;
        private System.Windows.Forms.TextBox tbWhere;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnFile2;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

