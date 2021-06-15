using System.Collections.Generic;
using System.Linq;

namespace Shop
{
    class ChainOfStores
    {
        public List<Shop> Shops { get; } = new List<Shop>();

        public void AddShop(string name) => Shops.Add(new Shop(name));
        public Shop this[string name]
        {
            get 
            {
                foreach (var item in Shops.Where(item => item.Name == name))
                    return item;
                return null;
            }
        }
        public Shop this[int index]
        {
            get { return Shops[index]; }
        }
    }
}