
namespace Fridges.Model
{
    public class Seller
    {
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Seller(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
