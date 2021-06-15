using System;
using System.Windows.Forms;

namespace Exam.View
{
    public interface IForbiddenWordsView
    {
        AddWordView AddWordView { get; set; }
        SearchView SearchView { get; set; }

        event EventHandler LoadWords;
        event EventHandler AddWord;
        event EventHandler DeleteWord;
        event EventHandler SaveWords;
        event EventHandler Search;

        ListBox ListBoxFileList { get; set; }
        ListBox ListBoxForbiddenWords { get; set; }
    }
}
