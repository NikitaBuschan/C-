namespace ConnectedLayer_01
{
    partial class MagazineView
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
            this.listView = new System.Windows.Forms.ListView();
            this.Продавец = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Покупатель = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Сумма = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Дата = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Продавец,
            this.Покупатель,
            this.Сумма,
            this.Дата});
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(535, 427);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // Продавец
            // 
            this.Продавец.Text = "Продавец";
            this.Продавец.Width = 150;
            // 
            // Покупатель
            // 
            this.Покупатель.Text = "Покупатель";
            this.Покупатель.Width = 150;
            // 
            // Сумма
            // 
            this.Сумма.Text = "Сумма сделки";
            this.Сумма.Width = 100;
            // 
            // Дата
            // 
            this.Дата.Text = "Дата";
            this.Дата.Width = 130;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // MagazineView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView);
            this.MaximizeBox = false;
            this.Name = "MagazineView";
            this.Text = "Magazine";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader Продавец;
        private System.Windows.Forms.ColumnHeader Покупатель;
        private System.Windows.Forms.ColumnHeader Сумма;
        private System.Windows.Forms.ColumnHeader Дата;
        private System.Windows.Forms.Button button1;
    }
}

