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
    public struct Item
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public Item(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }

    public partial class FormMain : Form
    {
        public List<Item> Products { get; private set; } = new List<Item>();
        private Info info;
        private int totalPrice = 0;

        public FormMain()
        {
            InitializeComponent();
            Products.Add(new Item("Videocard", 200));
            Products.Add(new Item("Disk", 50));
            Products.Add(new Item("Mouse", 1200));

            foreach (var item in Products)
            {
                totalPrice += item.Cost;
                listBox.Items.Add($"{item.Name}");
                comboBox.Items.Add(item.Name);
            }

            comboBox.SelectedIndex = 0;
            listBox.SelectedIndex = 0;
            labelTotalPrice.Text = $"Total price: {totalPrice}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) =>
            labelPrice.Text = $"Cost: {Products[comboBox.SelectedIndex].Cost}";

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            totalPrice += Products[comboBox.SelectedIndex].Cost;
            labelTotalPrice.Text = $"Total price: {totalPrice.ToString()}";

            Products.Add(Products[comboBox.SelectedIndex]);
            listBox.Items.Add(Products[comboBox.SelectedIndex].Name);
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex < 0)
                return;
            info = new Info(Products[listBox.SelectedIndex]);
            info.ShowDialog();
            if (info.DialogResult == DialogResult.OK)
            {
                totalPrice -= Products[listBox.SelectedIndex].Cost;
                Products[listBox.SelectedIndex] = info.GetInfo();
                totalPrice += Products[listBox.SelectedIndex].Cost;
                labelTotalPrice.Text = $"Total price: {totalPrice.ToString()}";
            }
        }
    }
}