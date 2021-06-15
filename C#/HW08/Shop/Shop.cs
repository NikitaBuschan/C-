using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    class Shop
    {
        public string Name { get; private set; }
        public List<Product> Products { get; } = new List<Product>();

        public Shop(string name) => Name = name;
        public void AddProduct(string name, int cost) => Products.Add(new Product(name, cost));
        public Product this[string name]
        {
            get
            {
                foreach (var item in Products.Where(item => item.Name == name))
                    return item;
                return null;
            }
        }
        public Product this[int index]
        {
            get { return Products[index]; }
        }
    }
}