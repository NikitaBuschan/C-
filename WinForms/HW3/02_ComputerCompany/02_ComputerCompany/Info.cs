using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_ComputerCompany
{
    public partial class Info : Form
    {
        private Item itemInfo  = new Item();

        public Info()
        {
            InitializeComponent();
        }

        public Info(Item item)
        {
            InitializeComponent();
            itemInfo = item;
            labelName.Text = "Name:";
            labelCost.Text = "Cost:";
            textBoxName.Text = itemInfo.Name;
            textBoxCost.Text = itemInfo.Cost.ToString();
        }

        private void buttonExit_Click(object sender, EventArgs e) => Close();

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            textBoxName.ReadOnly = false;
            textBoxCost.ReadOnly = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text.Length > 0)
            {
                itemInfo.Name = textBoxName.Text;
                itemInfo.Cost = Convert.ToInt32(textBoxCost.Text);
                textBoxName.ReadOnly = true;
                textBoxCost.ReadOnly = true;
                DialogResult = DialogResult.OK;
            }
        }

        public Item GetInfo() => itemInfo;
    }
}