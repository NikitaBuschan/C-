namespace Shop
{
    class Product
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        public override string ToString()
        {
            return $"Name: {Name} \n" + $"Cost: {Cost}";
        }
    }
}