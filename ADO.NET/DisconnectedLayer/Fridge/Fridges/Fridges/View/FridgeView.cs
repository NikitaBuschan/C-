using Fridges.View;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fridges
{
    public partial class FridgeView : Form, IFriedgeView
    {
        public event EventHandler ShowReceipt;
        public ReceiptView ReceiptView { get; set; }
        private SqlConnection SqlConnection { get; set; }
        private readonly string connectionString = @"Data Source=DESKTOP-FE00VPV\SQLEXPRESS;Initial Catalog=Fridges;Integrated Security=True";

        public FridgeView()
        {
            InitializeComponent();
            SqlConnection = new SqlConnection(connectionString);
        }            

        private void FridgeShopView_Load(object sender, EventArgs e)
        {
            LoadFridges();
            FillComboBoxes();
            lblCostTxt.Text = dataGridViewFridges.Rows[0].Cells[3].Value.ToString();
        }

        private void dataGridViewFridges_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
                lblCostTxt.Text = dataGridViewFridges.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void comboBoxCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColors.SelectedIndex == 0 && comboBoxCompanies.SelectedIndex == 0)
            {
                LoadFridges();
                return;
            }

            SqlDataAdapter sqlAdapter;
            var data = new DataSet();

            if (comboBoxColors.SelectedIndex == 0)
                sqlAdapter = GetSelectWithCompanies(comboBoxCompanies.Items[comboBoxCompanies.SelectedIndex].ToString());
            else if (comboBoxColors.SelectedIndex > 0)
                sqlAdapter = GetCompaniesAndColors(comboBoxCompanies.Items[comboBoxCompanies.SelectedIndex].ToString(),
                    comboBoxColors.Items[comboBoxColors.SelectedIndex].ToString());
            else
                return;
            sqlAdapter.Fill(data);
            dataGridViewFridges.DataSource = data;
            dataGridViewFridges.DataMember = data.Tables[0].TableName;

            AutoSizeMod();
        }

        private void comboBoxColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxColors.SelectedIndex == 0 && comboBoxCompanies.SelectedIndex == 0)
            {
                LoadFridges();
                return;
            }

            SqlDataAdapter sqlAdapter;
            var data = new DataSet();

            if (comboBoxCompanies.SelectedIndex == 0)
                sqlAdapter = GetSelectWithColors(comboBoxColors.Items[comboBoxColors.SelectedIndex].ToString());
            else if (comboBoxCompanies.SelectedIndex > 0 && comboBoxColors.SelectedIndex > 0)
                sqlAdapter = GetCompaniesAndColors(comboBoxCompanies.Items[comboBoxCompanies.SelectedIndex].ToString(),
                    comboBoxColors.Items[comboBoxColors.SelectedIndex].ToString());
            else
                return;

            sqlAdapter.Fill(data);
            dataGridViewFridges.DataSource = data;
            dataGridViewFridges.DataMember = data.Tables[0].TableName;

            AutoSizeMod();
        }

        private void btnMakeOrder_Click(object sender, EventArgs e) =>
                ShowReceipt?.Invoke(this, EventArgs.Empty);


        private void LoadFridges()
        {
            var FridgesData = new DataSet("Fridges");
            var sqlDataAdapter = GetFridges();

            sqlDataAdapter.Fill(FridgesData);

            dataGridViewFridges.DataSource = FridgesData;
            dataGridViewFridges.DataMember = FridgesData.Tables[0].TableName;

            AutoSizeMod();

            dataGridViewFridges.Rows[dataGridViewFridges.SelectedCells[0].RowIndex].Selected = true;
        }

        private void AutoSizeMod()
        {
            for (int i = 0; i < dataGridViewFridges.Columns.Count; i++)
                dataGridViewFridges.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void FillComboBoxes()
        {
            var data = new DataSet();
            var sqlAdapter = GetCompanies();

            sqlAdapter.Fill(data);

            comboBoxCompanies.Items.Add("All");
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                comboBoxCompanies.Items.Add(data.Tables[0].Rows[i].ItemArray[1]);
            comboBoxCompanies.SelectedIndex = 0;

            data = new DataSet();
            sqlAdapter = GetColors();
            sqlAdapter.Fill(data);

            comboBoxColors.Items.Add("All");
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                comboBoxColors.Items.Add(data.Tables[0].Rows[i].ItemArray[1]);
            comboBoxColors.SelectedIndex = 0;
        }

        private SqlDataAdapter GetCompanies() =>
            new SqlDataAdapter("SELECT * FROM Companies", SqlConnection);

        private SqlDataAdapter GetColors() =>
            new SqlDataAdapter("SELECT * FROM Colors", SqlConnection);

        private SqlDataAdapter GetSelectWithCompanies(string Company) =>
            new SqlDataAdapter($"select F.Model AS Model, C.Name AS Company, Colors.Name AS Color, F.Cost AS Cost from Fridges F join Companies C ON F.Company_FK = C.ID join Colors ON F.Color_FK = Colors.ID where C.Name = N'{Company}'", SqlConnection);

        private SqlDataAdapter GetSelectWithColors(string Color) =>
            new SqlDataAdapter($"select F.Model AS Model, C.Name AS Company, Colors.Name AS Color, F.Cost AS Cost from Fridges F join Companies C ON F.Company_FK = C.ID join Colors ON F.Color_FK = Colors.ID where Colors.Name = N'{Color}'", SqlConnection);

        private SqlDataAdapter GetCompaniesAndColors(string Company, string Color) =>
            new SqlDataAdapter($"select F.Model AS Model, C.Name AS Company, Colors.Name AS Color, F.Cost AS Cost from Fridges F join Companies C ON F.Company_FK = C.ID join Colors ON F.Color_FK = Colors.ID where Colors.Name = N'{Color}' AND C.Name = N'{Company}'", SqlConnection);

        private SqlDataAdapter GetFridges() =>
            new SqlDataAdapter("select F.Model AS Model, C.Name AS Company, Colors.Name AS Color, F.Cost AS Cost from Fridges F join Companies C ON F.Company_FK = C.ID join Colors ON F.Color_FK = Colors.ID", SqlConnection);

        public SqlDataAdapter GetSellers() =>
            new SqlDataAdapter("SELECT * FROM Sellers", SqlConnection);

        public DataGridView GetDataGridView() => 
            this.dataGridViewFridges;
    }
}
