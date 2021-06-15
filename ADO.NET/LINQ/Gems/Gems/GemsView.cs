using Gems.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gems
{
    public partial class GemsView : Form
    {
        public string pathOfXmlFile = $"{AppDomain.CurrentDomain.BaseDirectory}";
        public GemsView()
        {
            InitializeComponent();
            CreateDB();
            CreateXml();
            FillDataGridView();
            FillComboBox();
        }

        public void CreateDB()
        {
            using (var db = new GemContext())
            {
                var typeOrnamental = new Model.Type() { ID = 1, Name = "Поделочный" };
                var typePrecious = new Model.Type() { ID = 2, Name = "Драгоценный" };
                var typeSemiprecious = new Model.Type() { ID = 3, Name = "Полудрагоценный" };
                db.Types.AddRange(new List<Model.Type>() { typeOrnamental, typePrecious, typeSemiprecious });
                db.SaveChanges();

                var ruby = new Gem() { ID = 1, Name = "Ruby", Color = "Red", Opacity = false, Description = "Some desc", Type = typePrecious };
                var emerald = new Gem() { ID = 2, Name = "Emerald", Color = "Green", Opacity = false, Description = "Some desc", Type = typePrecious };
                var agate = new Gem() { ID = 3, Name = "Agate", Color = "Red", Opacity = true, Description = "Some desc", Type = typeSemiprecious };
                db.Gems.AddRange(new List<Gem>() { ruby, emerald, agate });
                db.SaveChanges();
            }
        }

        public void CreateXml() =>
            XmlLib.SaveFile($"{pathOfXmlFile}Gems.xml" , XmlLib.CreateGems());
        

        public void FillComboBox()
        {
            using (var db = new GemContext())
            {
                var gems = from a in db.Gems
                           select new
                           {
                               Color = a.Color
                           };

                comboBox.Items.Add("All");

                bool temp = false;
                foreach (var gem in gems)
                {
                    foreach (var item in comboBox.Items)
                        if (item.ToString() == gem.Color)
                            temp = true;

                    if (temp == false)
                        comboBox.Items.Add(gem.Color);
                    else
                        temp = false;
                }

                comboBox.SelectedIndex = 0;
            }
        }

        public void FillDataGridView(string Color = "")
        {
            using (var db = new GemContext())
            {
                var gems = from a in db.Gems
                           select new
                           {
                               ID = a.ID,
                               Name = a.Name,
                               Color = a.Color,
                               Opacity = a.Opacity,
                               Type = a.Type.Name,
                               Desctiption = a.Description
                           };

                if (Color.Length > 0)
                    gems = from a in db.Gems
                           where a.Color == Color
                           select new
                           {
                               ID = a.ID,
                               Name = a.Name,
                               Color = a.Color,
                               Opacity = a.Opacity,
                               Type = a.Type.Name,
                               Desctiption = a.Description
                           };

                dataGridView.Columns.Add("ID", "ID");
                dataGridView.Columns.Add("Name", "Name");
                dataGridView.Columns.Add("Color", "Color");
                dataGridView.Columns.Add("Opacity", "Opacity");
                dataGridView.Columns.Add("Type", "Type");
                dataGridView.Columns.Add("Desctiption", "Desctiption");

                int temp = 0;
                foreach (var gem in gems)
                {
                    dataGridView.Rows.Add();
                    dataGridView.Rows[temp].Cells["ID"].Value = gem.ID;
                    dataGridView.Rows[temp].Cells["Name"].Value = gem.Name;
                    dataGridView.Rows[temp].Cells["Color"].Value = gem.Color;
                    dataGridView.Rows[temp].Cells["Opacity"].Value = gem.Opacity;
                    dataGridView.Rows[temp].Cells["Type"].Value = gem.Type;
                    dataGridView.Rows[temp].Cells["Desctiption"].Value = gem.Desctiption;
                    temp++;
                }

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                    dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            if (comboBox.SelectedIndex == 0)
                FillDataGridView();
            else
                FillDataGridView(comboBox.Items[comboBox.SelectedIndex].ToString());
        }
    }
}
