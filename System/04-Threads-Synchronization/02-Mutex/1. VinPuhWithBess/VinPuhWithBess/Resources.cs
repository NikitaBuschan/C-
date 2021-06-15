using System.Threading;

namespace VinPuhWithBess
{
    public class Resources
    {
        public static Mutex VinniMutex { get; } = new Mutex();
    }
}
