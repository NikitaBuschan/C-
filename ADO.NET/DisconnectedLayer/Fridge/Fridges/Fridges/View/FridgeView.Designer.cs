namespace Fridges
{
    partial class FridgeView
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
            this.dataGridViewFridges = new System.Windows.Forms.DataGridView();
            this.comboBoxCompanies = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.comboBoxColors = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnMakeOrder = new System.Windows.Forms.Button();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblCostTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFridges)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFridges
            // 
            this.dataGridViewFridges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFridges.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewFridges.Name = "dataGridViewFridges";
            this.dataGridViewFridges.Size = new System.Drawing.Size(320, 282);
            this.dataGridViewFridges.TabIndex = 0;
            this.dataGridViewFridges.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFridges_CellClick);
            // 
            // comboBoxCompanies
            // 
            this.comboBoxCompanies.FormattingEnabled = true;
            this.comboBoxCompanies.Location = new System.Drawing.Point(413, 39);
            this.comboBoxCompanies.Name = "comboBoxCompanies";
            this.comboBoxCompanies.Size = new System.Drawing.Size(164, 21);
            this.comboBoxCompanies.TabIndex = 1;
            this.comboBoxCompanies.SelectedIndexChanged += new System.EventHandler(this.comboBoxCompanies_SelectedIndexChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(347, 42);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(54, 13);
            this.lblCompany.TabIndex = 3;
            this.lblCompany.Text = "Company:";
            // 
            // comboBoxColors
            // 
            this.comboBoxColors.FormattingEnabled = true;
            this.comboBoxColors.Location = new System.Drawing.Point(413, 75);
            this.comboBoxColors.Name = "comboBoxColors";
            this.comboBoxColors.Size = new System.Drawing.Size(164, 21);
            this.comboBoxColors.TabIndex = 5;
            this.comboBoxColors.SelectedIndexChanged += new System.EventHandler(this.comboBoxColors_SelectedIndexChanged);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(347, 78);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 6;
            this.lblColor.Text = "Color:";
            // 
            // btnMakeOrder
            // 
            this.btnMakeOrder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMakeOrder.Location = new System.Drawing.Point(457, 263);
            this.btnMakeOrder.Name = "btnMakeOrder";
            this.btnMakeOrder.Size = new System.Drawing.Size(120, 31);
            this.btnMakeOrder.TabIndex = 7;
            this.btnMakeOrder.Text = "Make order";
            this.btnMakeOrder.UseVisualStyleBackColor = true;
            this.btnMakeOrder.Click += new System.EventHandler(this.btnMakeOrder_Click);
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCost.Location = new System.Drawing.Point(347, 183);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(37, 15);
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "Cost: ";
            // 
            // lblCostTxt
            // 
            this.lblCostTxt.AutoSize = true;
            this.lblCostTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCostTxt.Location = new System.Drawing.Point(404, 185);
            this.lblCostTxt.Name = "lblCostTxt";
            this.lblCostTxt.Size = new System.Drawing.Size(0, 18);
            this.lblCostTxt.TabIndex = 9;
            // 
            // FridgeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 305);
            this.Controls.Add(this.lblCostTxt);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.btnMakeOrder);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.comboBoxColors);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.comboBoxCompanies);
            this.Controls.Add(this.dataGridViewFridges);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FridgeView";
            this.Text = "Frigde shop";
            this.Load += new System.EventHandler(this.FridgeShopView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFridges)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFridges;
        private System.Windows.Forms.ComboBox comboBoxCompanies;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.ComboBox comboBoxColors;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnMakeOrder;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblCostTxt;
    }
}

