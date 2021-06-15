using System;

namespace Fridges.Model
{
    public class Receipt
    {
        public int OrderNumber { get; private set; }
        public DateTime DateTime { get; private set; }
        public Seller Seller { get; private set; }
        public Fridge Fridge { get; private set; }

        public Receipt(int orderNumber, Seller seller, Fridge fridge)
        {
            DateTime = DateTime.Now;
            OrderNumber = orderNumber;
            Seller = seller;
            Fridge = fridge;
        }
    }
}
