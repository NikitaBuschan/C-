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
    public partial class AddFilter : Form
    {
        public string Filter { get; private set; }

        public AddFilter()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                Filter = textBox.Text;
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
