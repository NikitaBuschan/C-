using System;
using System.Windows.Forms;

namespace Fridges
{
    public partial class ReceiptView : Form
    {
        public string Path { get; set; }

        public ReceiptView()
        {
            InitializeComponent();
        }
        public Label OrderNumber() => lblOrderNumberTxt;

        public Label Date() => lblDateTxt;

        public Label Seller() => lblSellerTxt;

        public Label Company() => lblCompanyTxt;

        public Label Model() => lblModelTxt;

        public Label Color() => lblColorTxt;

        public Label Cost() => lblCostTxt;

        public Button BtnSave() => btnSave;

        public Button BtnClose() => btnClose;

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            using (var save = new SaveFileDialog() { DefaultExt = ".xml", Filter = "XML files|.xml" })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    Path = save.FileName;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit", "Do you wont ot exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
