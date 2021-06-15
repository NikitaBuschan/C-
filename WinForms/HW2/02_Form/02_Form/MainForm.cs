using System.Windows.Forms;

namespace _02_Form
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void textBox_Changed(object sender, System.EventArgs e)
        {
            labelNameWrite.Text = textBoxName.Text;
            labelSurnameWrite.Text = textBoxSurname.Text;
            labelAgeWrite.Text = textBoxAge.Text;
            labelCityWrite.Text = textBoxCity.Text;
            labelNameWrite.Update();
            labelSurnameWrite.Update();
            labelAgeWrite.Update();
            labelCityWrite.Update();
        }
    }
}