using System.Collections;
using System.Collections.Generic;

namespace Test1
{
    public class Groupddd
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public virtual ICollection<Specialization> Specialization { get; set; }
    }
}
