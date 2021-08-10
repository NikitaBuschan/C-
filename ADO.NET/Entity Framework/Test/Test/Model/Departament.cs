using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.Model
{
    public class Departament
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        // Все группы, относящиеся к данной специальности
        public ICollection<Group> Groups { get; set; }
    }
}
