using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.Model
{
    public class Group
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Departament Departament { get; set; }   // Навигационное свойство

        // Все студенты, принадлежащие данной группе
        public virtual IEnumerable<Student> Students { get; set; }
    }
}
