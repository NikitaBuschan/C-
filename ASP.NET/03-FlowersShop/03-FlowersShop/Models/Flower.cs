using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_FlowersShop.Models
{
    public class Flower
    {
        public string FlowerName { get; set; }
        public int Count { get; set; }
        public Address Address { get; set; }
        public string Comment { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }

        public Flower(string flowerName, int count, Address address, string comment, string customerName, DateTime date)
        {
            FlowerName = flowerName;
            Count = count;
            Address = address;
            Comment = comment;
            CustomerName = customerName;
            Date = date;
        }
    }
}
