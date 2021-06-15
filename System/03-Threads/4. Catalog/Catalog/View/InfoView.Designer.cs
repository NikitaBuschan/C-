namespace Catalog.Properties
{
    partial class InfoView
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
            this.lblPath = new System.Windows.Forms.Label();
            this.lblShowPath = new System.Windows.Forms.Label();
            this.lblFoldersCount = new System.Windows.Forms.Label();
            this.lblShowFolderCount = new System.Windows.Forms.Label();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.lblShowFileCount = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblShowFileSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(25, 24);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Path:";
            // 
            // lblShowPath
            // 
            this.lblShowPath.AutoSize = true;
            this.lblShowPath.Location = new System.Drawing.Point(135, 24);
            this.lblShowPath.Name = "lblShowPath";
            this.lblShowPath.Size = new System.Drawing.Size(0, 13);
            this.lblShowPath.TabIndex = 1;
            // 
            // lblFoldersCount
            // 
            this.lblFoldersCount.AutoSize = true;
            this.lblFoldersCount.Location = new System.Drawing.Point(25, 50);
            this.lblFoldersCount.Name = "lblFoldersCount";
            this.lblFoldersCount.Size = new System.Drawing.Size(74, 13);
            this.lblFoldersCount.TabIndex = 2;
            this.lblFoldersCount.Text = "Folders count:";
            // 
            // lblShowFolderCount
            // 
            this.lblShowFolderCount.AutoSize = true;
            this.lblShowFolderCount.Location = new System.Drawing.Point(135, 50);
            this.lblShowFolderCount.Name = "lblShowFolderCount";
            this.lblShowFolderCount.Size = new System.Drawing.Size(0, 13);
            this.lblShowFolderCount.TabIndex = 3;
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(25, 76);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(56, 13);
            this.lblFileCount.TabIndex = 4;
            this.lblFileCount.Text = "File count:";
            // 
            // lblShowFileCount
            // 
            this.lblShowFileCount.AutoSize = true;
            this.lblShowFileCount.Location = new System.Drawing.Point(135, 76);
            this.lblShowFileCount.Name = "lblShowFileCount";
            this.lblShowFileCount.Size = new System.Drawing.Size(0, 13);
            this.lblShowFileCount.TabIndex = 5;
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(25, 100);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(47, 13);
            this.lblFileSize.TabIndex = 6;
            this.lblFileSize.Text = "File size:";
            // 
            // lblShowFileSize
            // 
            this.lblShowFileSize.AutoSize = true;
            this.lblShowFileSize.Location = new System.Drawing.Point(135, 100);
            this.lblShowFileSize.Name = "lblShowFileSize";
            this.lblShowFileSize.Size = new System.Drawing.Size(0, 13);
            this.lblShowFileSize.TabIndex = 7;
            // 
            // InfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 136);
            this.Controls.Add(this.lblShowFileSize);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblShowFileCount);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.lblShowFolderCount);
            this.Controls.Add(this.lblFoldersCount);
            this.Controls.Add(this.lblShowPath);
            this.Controls.Add(this.lblPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoView";
            this.Text = "Info view";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblShowPath;
        private System.Windows.Forms.Label lblFoldersCount;
        private System.Windows.Forms.Label lblShowFolderCount;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label lblShowFileCount;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label lblShowFileSize;
    }
}