using Exam.View;
using System;
using System.Windows.Forms;

namespace Exam
{
    public partial class ForbiddenWordsView : Form, IForbiddenWordsView
    {
        public AddWordView AddWordView { get; set; }
        public SearchView SearchView { get; set; }

        public event EventHandler LoadWords;
        public event EventHandler AddWord;
        public event EventHandler DeleteWord;
        public event EventHandler SaveWords;
        public event EventHandler Search;

        public ListBox ListBoxFileList { get; set; }
        public ListBox ListBoxForbiddenWords { get; set; }

        public ForbiddenWordsView()
        {
            InitializeComponent();

            ListBoxFileList = this.listBoxFilesList;
            ListBoxForbiddenWords = this.listBoxForbiddenWords;
        }

        private void btnLoadWordsFromFile_Click(object sender, EventArgs e) =>
            LoadWords?.Invoke(this, EventArgs.Empty);

        private void btnAddWord_Click(object sender, EventArgs e) =>
            AddWord?.Invoke(this, EventArgs.Empty);

        private void btnDeleteWord_Click(object sender, EventArgs e) =>
            DeleteWord?.Invoke(this, EventArgs.Empty);

        private void btnSaveWords_Click(object sender, EventArgs e) =>
            SaveWords?.Invoke(this, EventArgs.Empty);

        private void btnSerchInFileSystem_Click(object sender, EventArgs e) =>
            Search?.Invoke(this, EventArgs.Empty);
    }
}
