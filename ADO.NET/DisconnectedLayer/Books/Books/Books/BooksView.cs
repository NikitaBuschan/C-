using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Books
{
    public partial class BooksView : Form
    {
        private SqlConnection SqlConnection { get; set; }
        private string connectionString = @"Data Source=DESKTOP-FE00VPV\SQLEXPRESS;Initial Catalog=Books;Integrated Security=True";

        public BooksView()
        {
            InitializeComponent();
            comboBoxAuthors.Enabled = false;
            comboBoxPresses.Enabled = false;
            checkBoxAuthors.Checked = true;
            checkBoxPresses.Checked = true;
        }

        private void BooksView_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(connectionString);
            FillComboBoxes();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewBooks.Columns.Clear();

            FillDataAll();

            comboBoxAuthors.Enabled = true;
            comboBoxPresses.Enabled = true;
        }

        private void FillDataAll()
        {

            SqlDataAdapter sqlDataAdapter = null;
            var BooksData = new DataSet("Books");

            if (comboBoxAuthors.SelectedIndex == 0 && comboBoxPresses.SelectedIndex == 0)
                sqlDataAdapter = GetBooks();
            else if (comboBoxAuthors.SelectedIndex != 0 && comboBoxPresses.SelectedIndex != 0)
                sqlDataAdapter = GetBooksWihtAuthorAndPresses(comboBoxAuthors.Items[comboBoxAuthors.SelectedIndex].ToString(), comboBoxPresses.Items[comboBoxAuthors.SelectedIndex].ToString());
            else if (comboBoxAuthors.SelectedIndex != 0)
                sqlDataAdapter = GetAuthorBooks(comboBoxAuthors.Items[comboBoxAuthors.SelectedIndex].ToString());
            else if (comboBoxPresses.SelectedIndex != 0)
                sqlDataAdapter = GetPressesBooks(comboBoxPresses.Items[comboBoxAuthors.SelectedIndex].ToString());


            sqlDataAdapter.Fill(BooksData);

            dataGridViewBooks.DataSource = BooksData;
            dataGridViewBooks.DataMember = BooksData.Tables[0].TableName;

            if (checkBoxAuthors.Checked == true && checkBoxPresses.Checked == true)
            {
                dataGridViewBooks.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewBooks.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (checkBoxAuthors.Checked == true)
            {
                if (dataGridViewBooks.Columns.Count == 2)
                    dataGridViewBooks.Columns.RemoveAt(1);
                dataGridViewBooks.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (checkBoxPresses.Checked == true)
            {
                if (dataGridViewBooks.Columns.Count == 2)
                    dataGridViewBooks.Columns.RemoveAt(0);
                dataGridViewBooks.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                dataGridViewBooks.Columns.RemoveAt(0);
                dataGridViewBooks.Columns.RemoveAt(0);
                return;
            }
        }

        private void FillComboBoxes()
        {
            comboBoxAuthors.Items.Clear();

            var sqlAdapter = GetAuthors();
            var data = new DataSet("Authors");

            sqlAdapter.Fill(data);

            comboBoxAuthors.Items.Add("All");
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                comboBoxAuthors.Items.Add(data.Tables[0].Rows[i].ItemArray[0]);

            comboBoxAuthors.SelectedIndex = 0;

            sqlAdapter = GetPresses();
            data = new DataSet("Presses");

            sqlAdapter.Fill(data);

            comboBoxPresses.Items.Add("All");
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                comboBoxPresses.Items.Add(data.Tables[0].Rows[i].ItemArray[0]);

            comboBoxPresses.SelectedIndex = 0;
        }

        private SqlDataAdapter GetAuthors() =>
            new SqlDataAdapter("SELECT Name AS Author FROM Authors", SqlConnection);

        private SqlDataAdapter GetPresses() =>
            new SqlDataAdapter("SELECT Name AS Presses  FROM Presses", SqlConnection);

        private SqlDataAdapter GetBooks() =>
            new SqlDataAdapter("SELECT A.Name AS Author, B.Name AS Book FROM Authors A, Books B WHERE A.ID = B.Author_FK", SqlConnection);

        private SqlDataAdapter GetAuthorBooks(string Author) =>
                   new SqlDataAdapter($"select A.Name AS Author, B.Name AS Book from Books B join Authors A ON B.Author_FK = A.ID where A.Name = N'{Author}'", SqlConnection);

        private SqlDataAdapter GetPressesBooks(string Presses) =>
           new SqlDataAdapter($"select P.Name AS Presses, B.Name AS Book from Books B join Presses P ON B.Presses_FK = P.ID where P.Name = N'{Presses}'", SqlConnection);

        private SqlDataAdapter GetBooksWihtAuthorAndPresses(string Author, string Presses) =>
            new SqlDataAdapter($"select B.Name AS Book, A.Name AS Author, P.Name AS Presses from Books B join Authors A ON B.Author_FK = A.ID join Presses P ON B.Presses_FK = P.ID where A.Name = N'{Author}' AND P.Name = N'{Presses}'", SqlConnection);

        private void btnExit_Click(object sender, EventArgs e) =>
                    this.Close();
    }
}
