using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fridges.View
{
    public interface IFriedgeView
    {
        event EventHandler ShowReceipt;
        ReceiptView ReceiptView { get; set; }
        SqlDataAdapter GetSellers();
        DataGridView GetDataGridView();
    }
}
