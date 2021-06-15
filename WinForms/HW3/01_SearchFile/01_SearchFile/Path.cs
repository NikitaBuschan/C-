using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_SearchFile
{
    public partial class Path : Form
    {
        public string PathStr { get; private set; }

        public Path()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                PathStr = textBox.Text;
                Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.KeyCode == Keys.Enter && textBox.Text.Length > 0)
            {
                this.DialogResult = DialogResult.OK;
                PathStr = textBox.Text;
                Close();
            }
        }
    }
}