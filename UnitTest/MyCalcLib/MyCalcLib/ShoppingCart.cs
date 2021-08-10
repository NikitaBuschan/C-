using System;
using System.Collections.Generic;
using System.Text;

namespace MyCalcLib
{
    [Serializable]
    public class ShoppingCart : IDisposable
    {

        public List<Item> Items = new List<Item>();

        public int Count
        {
            get { return Items.Count; }
        }

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Dispose()
        {
            // ddd
        }

        public void Remove(int index)
        {
            Items.RemoveAt(index);
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
