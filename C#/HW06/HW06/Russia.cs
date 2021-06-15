using Ukrain;
using Poland;

namespace Russia
{
    class Moscow
    {
        public int People { get; private set; }
        public Moscow(int count)
        {
            People = count;
        }
        public static bool operator >(Moscow a, Kiev b)
        {
            return a.People > b.People;
        }
        public static bool operator >(Moscow a, Warszawa b)
        {
            return a.People > b.People;
        }
        public static bool operator <(Moscow a, Kiev b)
        {
            return a.People < b.People;
        }
        public static bool operator <(Moscow a, Warszawa b)
        {
            return a.People < b.People;
        }
    }
}