namespace Exam
{
    partial class ForbiddenWordsView
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
            this.listBoxFilesList = new System.Windows.Forms.ListBox();
            this.listBoxForbiddenWords = new System.Windows.Forms.ListBox();
            this.btnLoadWordsFromFile = new System.Windows.Forms.Button();
            this.btnAddWord = new System.Windows.Forms.Button();
            this.btnDeleteWord = new System.Windows.Forms.Button();
            this.btnSaveWords = new System.Windows.Forms.Button();
            this.btnSerchInFileSystem = new System.Windows.Forms.Button();
            this.lblFileInfo = new System.Windows.Forms.Label();
            this.lblWords = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxFilesList
            // 
            this.listBoxFilesList.FormattingEnabled = true;
            this.listBoxFilesList.Location = new System.Drawing.Point(12, 50);
            this.listBoxFilesList.Name = "listBoxFilesList";
            this.listBoxFilesList.Size = new System.Drawing.Size(323, 381);
            this.listBoxFilesList.TabIndex = 0;
            // 
            // listBoxForbiddenWords
            // 
            this.listBoxForbiddenWords.FormattingEnabled = true;
            this.listBoxForbiddenWords.Location = new System.Drawing.Point(357, 50);
            this.listBoxForbiddenWords.Name = "listBoxForbiddenWords";
            this.listBoxForbiddenWords.Size = new System.Drawing.Size(172, 381);
            this.listBoxForbiddenWords.TabIndex = 0;
            // 
            // btnLoadWordsFromFile
            // 
            this.btnLoadWordsFromFile.Location = new System.Drawing.Point(545, 60);
            this.btnLoadWordsFromFile.Name = "btnLoadWordsFromFile";
            this.btnLoadWordsFromFile.Size = new System.Drawing.Size(92, 23);
            this.btnLoadWordsFromFile.TabIndex = 1;
            this.btnLoadWordsFromFile.Text = "Load words";
            this.btnLoadWordsFromFile.UseVisualStyleBackColor = true;
            this.btnLoadWordsFromFile.Click += new System.EventHandler(this.btnLoadWordsFromFile_Click);
            // 
            // btnAddWord
            // 
            this.btnAddWord.Location = new System.Drawing.Point(545, 102);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(92, 23);
            this.btnAddWord.TabIndex = 2;
            this.btnAddWord.Text = "Add word";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // btnDeleteWord
            // 
            this.btnDeleteWord.Location = new System.Drawing.Point(545, 131);
            this.btnDeleteWord.Name = "btnDeleteWord";
            this.btnDeleteWord.Size = new System.Drawing.Size(92, 23);
            this.btnDeleteWord.TabIndex = 3;
            this.btnDeleteWord.Text = "Delete word";
            this.btnDeleteWord.UseVisualStyleBackColor = true;
            this.btnDeleteWord.Click += new System.EventHandler(this.btnDeleteWord_Click);
            // 
            // btnSaveWords
            // 
            this.btnSaveWords.Location = new System.Drawing.Point(545, 160);
            this.btnSaveWords.Name = "btnSaveWords";
            this.btnSaveWords.Size = new System.Drawing.Size(92, 23);
            this.btnSaveWords.TabIndex = 4;
            this.btnSaveWords.Text = "Save words";
            this.btnSaveWords.UseVisualStyleBackColor = true;
            this.btnSaveWords.Click += new System.EventHandler(this.btnSaveWords_Click);
            // 
            // btnSerchInFileSystem
            // 
            this.btnSerchInFileSystem.Location = new System.Drawing.Point(545, 408);
            this.btnSerchInFileSystem.Name = "btnSerchInFileSystem";
            this.btnSerchInFileSystem.Size = new System.Drawing.Size(92, 23);
            this.btnSerchInFileSystem.TabIndex = 5;
            this.btnSerchInFileSystem.Text = "Search";
            this.btnSerchInFileSystem.UseVisualStyleBackColor = true;
            this.btnSerchInFileSystem.Click += new System.EventHandler(this.btnSerchInFileSystem_Click);
            // 
            // lblFileInfo
            // 
            this.lblFileInfo.AutoSize = true;
            this.lblFileInfo.Location = new System.Drawing.Point(12, 25);
            this.lblFileInfo.Name = "lblFileInfo";
            this.lblFileInfo.Size = new System.Drawing.Size(51, 13);
            this.lblFileInfo.TabIndex = 6;
            this.lblFileInfo.Text = "Files info:";
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.Location = new System.Drawing.Point(354, 25);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(41, 13);
            this.lblWords.TabIndex = 7;
            this.lblWords.Text = "Words:";
            // 
            // ForbiddenWordsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 444);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.lblFileInfo);
            this.Controls.Add(this.btnSerchInFileSystem);
            this.Controls.Add(this.btnSaveWords);
            this.Controls.Add(this.btnDeleteWord);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.btnLoadWordsFromFile);
            this.Controls.Add(this.listBoxForbiddenWords);
            this.Controls.Add(this.listBoxFilesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ForbiddenWordsView";
            this.Text = "Forbidden words";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxFilesList;
        private System.Windows.Forms.ListBox listBoxForbiddenWords;
        private System.Windows.Forms.Button btnLoadWordsFromFile;
        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.Button btnDeleteWord;
        private System.Windows.Forms.Button btnSaveWords;
        private System.Windows.Forms.Button btnSerchInFileSystem;
        private System.Windows.Forms.Label lblFileInfo;
        private System.Windows.Forms.Label lblWords;
    }
}

