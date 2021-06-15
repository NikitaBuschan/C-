using Ukrain;
using Russia;

namespace Poland
{
    class Warszawa
    {
        public int People { get; private set; }
        public Warszawa(int count)
        {
            People = count;
        }
        public static bool operator >(Warszawa a, Moscow b)
        {
            return a.People > b.People;
        }
        public static bool operator >(Warszawa a, Kiev b)
        {
            return a.People > b.People;
        }
        public static bool operator <(Warszawa a, Moscow b)
        {
            return a.People < b.People;
        }
        public static bool operator <(Warszawa a, Kiev b)
        {
            return a.People < b.People;
        }
    }
}