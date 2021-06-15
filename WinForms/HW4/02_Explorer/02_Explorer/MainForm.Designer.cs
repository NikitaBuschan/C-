namespace _02_Explorer
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.labelItems = new System.Windows.Forms.Label();
            this.labelSelectedItems = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox.FormattingEnabled = true;
            this.listBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBox.Location = new System.Drawing.Point(12, 35);
            this.listBox.Margin = new System.Windows.Forms.Padding(0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(102, 507);
            this.listBox.TabIndex = 2;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(48, 9);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(615, 20);
            this.textBoxUrl.TabIndex = 3;
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(115, 35);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(548, 507);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            // 
            // labelItems
            // 
            this.labelItems.AutoSize = true;
            this.labelItems.Location = new System.Drawing.Point(12, 545);
            this.labelItems.Name = "labelItems";
            this.labelItems.Size = new System.Drawing.Size(0, 13);
            this.labelItems.TabIndex = 5;
            // 
            // labelSelectedItems
            // 
            this.labelSelectedItems.AutoSize = true;
            this.labelSelectedItems.Location = new System.Drawing.Point(101, 545);
            this.labelSelectedItems.Name = "labelSelectedItems";
            this.labelSelectedItems.Size = new System.Drawing.Size(0, 13);
            this.labelSelectedItems.TabIndex = 5;
            // 
            // buttonBack
            // 
            this.buttonBack.BackgroundImage = global::_02_Explorer.Properties.Resources.Back;
            this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBack.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonBack.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.buttonBack.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(12, 9);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(25, 20);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 569);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelSelectedItems);
            this.Controls.Add(this.labelItems);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Explorer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Label labelItems;
        private System.Windows.Forms.Label labelSelectedItems;
        private System.Windows.Forms.Button buttonBack;
    }
}

