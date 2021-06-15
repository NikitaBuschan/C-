using Poland;
using Russia;

namespace Ukrain
{
    class Kiev
    {
        public int People { get; private set; }
        public Kiev(int count)
        {
            People = count;
        }
        public static bool operator >(Kiev a, Moscow b)
        {
            return a.People > b.People;
        }
        public static bool operator >(Kiev a, Warszawa b)
        {
            return a.People > b.People;
        }
        public static bool operator <(Kiev a, Moscow b)
        {
            return a.People < b.People;
        }
        public static bool operator <(Kiev a, Warszawa b)
        {
            return a.People < b.People;
        }
    }
}