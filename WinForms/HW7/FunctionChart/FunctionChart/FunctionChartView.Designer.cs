namespace FunctionChart
{
    partial class FunctionChartView
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
            this.btnFillFunction = new System.Windows.Forms.Button();
            this.gbFuntion = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnFillFunction
            // 
            this.btnFillFunction.Location = new System.Drawing.Point(136, 12);
            this.btnFillFunction.Name = "btnFillFunction";
            this.btnFillFunction.Size = new System.Drawing.Size(162, 23);
            this.btnFillFunction.TabIndex = 0;
            this.btnFillFunction.Text = "Fill function";
            this.btnFillFunction.UseVisualStyleBackColor = true;
            this.btnFillFunction.Click += new System.EventHandler(this.buttonFillFunction_Click);
            // 
            // gbFuntion
            // 
            this.gbFuntion.Location = new System.Drawing.Point(12, 53);
            this.gbFuntion.Name = "gbFuntion";
            this.gbFuntion.Size = new System.Drawing.Size(410, 385);
            this.gbFuntion.TabIndex = 1;
            this.gbFuntion.TabStop = false;
            // 
            // FunctionChartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 450);
            this.Controls.Add(this.gbFuntion);
            this.Controls.Add(this.btnFillFunction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FunctionChartView";
            this.Text = "Main form";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FunctionChartView_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFillFunction;
        private System.Windows.Forms.GroupBox gbFuntion;
    }
}

