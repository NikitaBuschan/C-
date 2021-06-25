namespace _02_Products.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Info { get; set; }
        public string FullInfo { get; set; }
        public double Cost { get; set; }

        public Product(int id, string name, string image, string info, string fullInfo, double cost)
        {
            Id = id;
            Name = name;
            Image = image;
            Info = info;
            FullInfo = fullInfo;
            Cost = cost;
        }
    }
}
