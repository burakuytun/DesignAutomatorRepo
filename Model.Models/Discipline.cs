using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            SectionDisciplineMap = new HashSet<SectionDisciplineMap>();
            TypeDisciplineMap = new HashSet<TypeDisciplineMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SectionDisciplineMap> SectionDisciplineMap { get; set; }
        public virtual ICollection<TypeDisciplineMap> TypeDisciplineMap { get; set; }
    }
}
