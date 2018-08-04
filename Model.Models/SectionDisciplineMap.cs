using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class SectionDisciplineMap
    {
        public int Id { get; set; }
        public int? SectionId { get; set; }
        public int? DisciplineId { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual Section Section { get; set; }
    }
}
