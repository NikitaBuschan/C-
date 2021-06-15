using System;
using System.Windows.Forms;

namespace Exam
{
    public partial class SearchView : Form
    {
        public event EventHandler Start;
        public event EventHandler Pause;
        public event EventHandler Cancel;

        public ProgressBar ProgressBar { get; set; }

        public Button ButtonStart { get; set; }
        public Button ButtonPause { get; set; }
        public Button ButtonCancel { get; set; }

        public SearchView()
        {
            InitializeComponent();

            ProgressBar = this.progressBar;
            ButtonStart = this.btnStart;
            ButtonPause = this.btnPause;
            ButtonCancel = this.btnCancel;
        }

        private void btnStart_Click(object sender, EventArgs e) =>
            Start?.Invoke(this, EventArgs.Empty);

        private void btnPause_Click(object sender, EventArgs e) =>
            Pause?.Invoke(this, EventArgs.Empty);

        private void btnCancel_Click(object sender, EventArgs e) =>
            Cancel?.Invoke(this, EventArgs.Empty);
    }
}
