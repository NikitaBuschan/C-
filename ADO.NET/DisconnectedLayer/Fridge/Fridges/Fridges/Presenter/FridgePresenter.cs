using Fridges.Model;
using Fridges.View;
using System;
using System.Data;
using System.Windows.Forms;

namespace Fridges.Presenter
{
    public class FridgePresenter
    {
        private IFridgeModel Model { get; set; }
        private IFriedgeView View { get; set; }

        public FridgePresenter(IFridgeModel model, IFriedgeView view)
        {
            Model = model;
            View = view;

            View.ShowReceipt += (e, o) =>
            {
                var data = new DataSet();
                var sqlAdapter = View.GetSellers();
                sqlAdapter.Fill(data);

                Model.Receipt = new Receipt(
                    new Random().Next(0, 100),
                    new Seller(
                        data.Tables[0].Rows[new Random().Next(0, data.Tables[0].Rows.Count)].ItemArray[1].ToString(),
                        Convert.ToInt32(data.Tables[0].Rows[new Random().Next(0, data.Tables[0].Rows.Count)].ItemArray[2])),
                    new Fridge(
                        View.GetDataGridView().Rows[View.GetDataGridView().CurrentRow.Index].Cells[0].Value.ToString(),
                        View.GetDataGridView().Rows[View.GetDataGridView().CurrentRow.Index].Cells[1].Value.ToString(),
                        View.GetDataGridView().Rows[View.GetDataGridView().CurrentRow.Index].Cells[2].Value.ToString(),
                        Convert.ToInt32(View.GetDataGridView().Rows[View.GetDataGridView().CurrentRow.Index].Cells[3].Value)));

                View.ReceiptView = new ReceiptView();
                View.ReceiptView.OrderNumber().Text = Model.Receipt.OrderNumber.ToString();
                View.ReceiptView.Date().Text = Model.Receipt.DateTime.ToString();
                View.ReceiptView.Seller().Text = Model.Receipt.Seller.Name;
                View.ReceiptView.Company().Text = Model.Receipt.Fridge.Company;
                View.ReceiptView.Model().Text = Model.Receipt.Fridge.Model;
                View.ReceiptView.Color().Text = Model.Receipt.Fridge.Color;
                View.ReceiptView.Cost().Text = Model.Receipt.Fridge.Cost.ToString();

                if (View.ReceiptView.ShowDialog() == DialogResult.OK)
                {
                    XmlLib.SaveReceipt(
                        View.ReceiptView.Path,
                        XmlLib.CreateReceipt(
                            Model.Receipt.OrderNumber, 
                            XmlLib.CreateSeller(
                                Model.Receipt.Seller.Name,
                                Model.Receipt.Seller.Age), 
                            XmlLib.CreateFridge(
                                Model.Receipt.Fridge.Model,
                                Model.Receipt.Fridge.Company,
                                Model.Receipt.Fridge.Color,
                                Model.Receipt.Fridge.Cost)));
                }
            };
        }
    }
}
