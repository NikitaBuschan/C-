using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConnectedLayer_01
{
    public partial class MagazineView : Form, IMagazineView
    {
        private ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Sales"];
        public ListViewItem Item { get; set; }
        public event EventHandler ShowList;

        public MagazineView()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e) =>
            ShowList?.Invoke(sender, e);

        public void MainForm_Load()
        {
            try
            {
                using (var connection = new SqlConnection(settings.ConnectionString))
                {
                    connection.Open();
                    FillListView(connection);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        public void FillListView(SqlConnection connection)
        {
            try
            {
                string sqlString = 
                    "SELECT " +
                    "Seller.FirstName + ' ' + Seller.LastName AS Seller," +
                    "Buyer.FirstName + ' ' + Buyer.LastName AS Buyer," +
                    "Sales.Sum AS[Sum]," +
                    "Sales.Date AS[Date]" +
                    "FROM " +
                    "Sales " +
                    "join Seller on Seller_fk = Seller.ID " +
                    "join Buyer on Buyer_fk = Buyer.ID";
                using (SqlCommand command = new SqlCommand(sqlString, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = listView.Items.Add(new ListViewItem());
                        item.Text = (string)reader["Seller"];
                        item.SubItems.Add((string)reader["Buyer"]);
                        item.SubItems.Add((reader["Sum"]).ToString());
                        item.SubItems.Add((reader["Date"]).ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
