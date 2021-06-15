namespace Books
{
    partial class BooksView
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
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.checkBoxAuthors = new System.Windows.Forms.CheckBox();
            this.checkBoxPresses = new System.Windows.Forms.CheckBox();
            this.comboBoxAuthors = new System.Windows.Forms.ComboBox();
            this.comboBoxPresses = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblPresses = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.Size = new System.Drawing.Size(261, 426);
            this.dataGridViewBooks.TabIndex = 0;
            // 
            // checkBoxAuthors
            // 
            this.checkBoxAuthors.AutoSize = true;
            this.checkBoxAuthors.Location = new System.Drawing.Point(297, 29);
            this.checkBoxAuthors.Name = "checkBoxAuthors";
            this.checkBoxAuthors.Size = new System.Drawing.Size(62, 17);
            this.checkBoxAuthors.TabIndex = 1;
            this.checkBoxAuthors.Text = "Authors";
            this.checkBoxAuthors.UseVisualStyleBackColor = true;
            // 
            // checkBoxPresses
            // 
            this.checkBoxPresses.AutoSize = true;
            this.checkBoxPresses.Location = new System.Drawing.Point(383, 29);
            this.checkBoxPresses.Name = "checkBoxPresses";
            this.checkBoxPresses.Size = new System.Drawing.Size(63, 17);
            this.checkBoxPresses.TabIndex = 1;
            this.checkBoxPresses.Text = "Presses";
            this.checkBoxPresses.UseVisualStyleBackColor = true;
            // 
            // comboBoxAuthors
            // 
            this.comboBoxAuthors.FormattingEnabled = true;
            this.comboBoxAuthors.Location = new System.Drawing.Point(297, 93);
            this.comboBoxAuthors.Name = "comboBoxAuthors";
            this.comboBoxAuthors.Size = new System.Drawing.Size(149, 21);
            this.comboBoxAuthors.TabIndex = 2;
            // 
            // comboBoxPresses
            // 
            this.comboBoxPresses.FormattingEnabled = true;
            this.comboBoxPresses.Location = new System.Drawing.Point(297, 145);
            this.comboBoxPresses.Name = "comboBoxPresses";
            this.comboBoxPresses.Size = new System.Drawing.Size(149, 21);
            this.comboBoxPresses.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(306, 190);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(131, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(333, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(294, 77);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 5;
            this.lblAuthor.Text = "Author:";
            // 
            // lblPresses
            // 
            this.lblPresses.AutoSize = true;
            this.lblPresses.Location = new System.Drawing.Point(294, 129);
            this.lblPresses.Name = "lblPresses";
            this.lblPresses.Size = new System.Drawing.Size(47, 13);
            this.lblPresses.TabIndex = 6;
            this.lblPresses.Text = "Presses:";
            // 
            // BooksView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 450);
            this.Controls.Add(this.lblPresses);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.comboBoxPresses);
            this.Controls.Add(this.comboBoxAuthors);
            this.Controls.Add(this.checkBoxPresses);
            this.Controls.Add(this.checkBoxAuthors);
            this.Controls.Add(this.dataGridViewBooks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BooksView";
            this.Text = "Books";
            this.Load += new System.EventHandler(this.BooksView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.CheckBox checkBoxAuthors;
        private System.Windows.Forms.CheckBox checkBoxPresses;
        private System.Windows.Forms.ComboBox comboBoxAuthors;
        private System.Windows.Forms.ComboBox comboBoxPresses;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblPresses;
    }
}

