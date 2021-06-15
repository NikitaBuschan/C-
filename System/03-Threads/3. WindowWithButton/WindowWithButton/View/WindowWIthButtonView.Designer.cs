namespace WindowWithButton
{
    partial class WindowWithButtonView
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
            this.btnButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnButton
            // 
            this.btnButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnButton.Font = new System.Drawing.Font("Georgia", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnButton.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnButton.Location = new System.Drawing.Point(50, 37);
            this.btnButton.Name = "btnButton";
            this.btnButton.Size = new System.Drawing.Size(195, 158);
            this.btnButton.TabIndex = 0;
            this.btnButton.Text = "Button";
            this.btnButton.UseVisualStyleBackColor = false;
            this.btnButton.Click += new System.EventHandler(this.btnButton_Click);
            // 
            // WindowWIthButtonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(294, 233);
            this.Controls.Add(this.btnButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WindowWIthButtonView";
            this.Text = "Window with button";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnButton;
    }
}

