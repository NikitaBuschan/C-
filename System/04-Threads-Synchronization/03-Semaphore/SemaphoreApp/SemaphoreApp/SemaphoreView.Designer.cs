namespace SemaphoreApp
{
    partial class SemaphoreView
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
            this.btnCreateThread = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.listBoxWorking = new System.Windows.Forms.ListBox();
            this.listBoxAwaiting = new System.Windows.Forms.ListBox();
            this.listBoxCreating = new System.Windows.Forms.ListBox();
            this.lblWorkingThreads = new System.Windows.Forms.Label();
            this.lblWaitingThreads = new System.Windows.Forms.Label();
            this.lblCreatingThreads = new System.Windows.Forms.Label();
            this.lblCountOfplace = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateThread
            // 
            this.btnCreateThread.Location = new System.Drawing.Point(473, 153);
            this.btnCreateThread.Name = "btnCreateThread";
            this.btnCreateThread.Size = new System.Drawing.Size(126, 23);
            this.btnCreateThread.TabIndex = 1;
            this.btnCreateThread.Text = "Create thread";
            this.btnCreateThread.UseVisualStyleBackColor = true;
            this.btnCreateThread.Click += new System.EventHandler(this.btnCreateThread_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(46, 156);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown.TabIndex = 2;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // listBoxWorking
            // 
            this.listBoxWorking.FormattingEnabled = true;
            this.listBoxWorking.Location = new System.Drawing.Point(12, 44);
            this.listBoxWorking.Name = "listBoxWorking";
            this.listBoxWorking.Size = new System.Drawing.Size(203, 69);
            this.listBoxWorking.TabIndex = 3;
            this.listBoxWorking.DoubleClick += new System.EventHandler(this.listBoxWorking_DoubleClick);
            // 
            // listBoxAwaiting
            // 
            this.listBoxAwaiting.FormattingEnabled = true;
            this.listBoxAwaiting.Location = new System.Drawing.Point(221, 44);
            this.listBoxAwaiting.Name = "listBoxAwaiting";
            this.listBoxAwaiting.Size = new System.Drawing.Size(203, 69);
            this.listBoxAwaiting.TabIndex = 3;
            // 
            // listBoxCreating
            // 
            this.listBoxCreating.FormattingEnabled = true;
            this.listBoxCreating.Location = new System.Drawing.Point(430, 44);
            this.listBoxCreating.Name = "listBoxCreating";
            this.listBoxCreating.Size = new System.Drawing.Size(203, 69);
            this.listBoxCreating.TabIndex = 3;
            this.listBoxCreating.DoubleClick += new System.EventHandler(this.listBoxCreating_DoubleClick);
            // 
            // lblWorkingThreads
            // 
            this.lblWorkingThreads.AutoSize = true;
            this.lblWorkingThreads.Location = new System.Drawing.Point(59, 17);
            this.lblWorkingThreads.Name = "lblWorkingThreads";
            this.lblWorkingThreads.Size = new System.Drawing.Size(85, 13);
            this.lblWorkingThreads.TabIndex = 4;
            this.lblWorkingThreads.Text = "Working threads";
            // 
            // lblWaitingThreads
            // 
            this.lblWaitingThreads.AutoSize = true;
            this.lblWaitingThreads.Location = new System.Drawing.Point(279, 17);
            this.lblWaitingThreads.Name = "lblWaitingThreads";
            this.lblWaitingThreads.Size = new System.Drawing.Size(85, 13);
            this.lblWaitingThreads.TabIndex = 5;
            this.lblWaitingThreads.Text = "Awaiting threads";
            // 
            // lblCreatingThreads
            // 
            this.lblCreatingThreads.AutoSize = true;
            this.lblCreatingThreads.Location = new System.Drawing.Point(485, 17);
            this.lblCreatingThreads.Name = "lblCreatingThreads";
            this.lblCreatingThreads.Size = new System.Drawing.Size(84, 13);
            this.lblCreatingThreads.TabIndex = 6;
            this.lblCreatingThreads.Text = "Creating threads";
            // 
            // lblCountOfplace
            // 
            this.lblCountOfplace.AutoSize = true;
            this.lblCountOfplace.Location = new System.Drawing.Point(35, 130);
            this.lblCountOfplace.Name = "lblCountOfplace";
            this.lblCountOfplace.Size = new System.Drawing.Size(142, 13);
            this.lblCountOfplace.TabIndex = 7;
            this.lblCountOfplace.Text = "Count of place in semaphore";
            // 
            // SemaphoreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 188);
            this.Controls.Add(this.lblCountOfplace);
            this.Controls.Add(this.lblCreatingThreads);
            this.Controls.Add(this.lblWaitingThreads);
            this.Controls.Add(this.lblWorkingThreads);
            this.Controls.Add(this.listBoxCreating);
            this.Controls.Add(this.listBoxAwaiting);
            this.Controls.Add(this.listBoxWorking);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.btnCreateThread);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SemaphoreView";
            this.Text = "Semaphore";
            this.Load += new System.EventHandler(this.SemaphoreView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateThread;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.ListBox listBoxWorking;
        private System.Windows.Forms.ListBox listBoxAwaiting;
        private System.Windows.Forms.ListBox listBoxCreating;
        private System.Windows.Forms.Label lblWorkingThreads;
        private System.Windows.Forms.Label lblWaitingThreads;
        private System.Windows.Forms.Label lblCreatingThreads;
        private System.Windows.Forms.Label lblCountOfplace;
    }
}

