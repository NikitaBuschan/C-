
namespace Fridges.Model
{
    public class Fridge
    {
        public string Model { get; private set; }
        public string Company { get; private set; }
        public string Color { get; private set; }
        public int Cost { get; private set; }

        public Fridge(string model, string company, string color, int cost)
        {
            Model = model;
            Company = company;
            Color = color;
            Cost = cost;
        }
    }
}
