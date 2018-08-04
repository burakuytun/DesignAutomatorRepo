using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class TypeDisciplineMap
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public int? DisciplineId { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual Type Type { get; set; }
    }
}
