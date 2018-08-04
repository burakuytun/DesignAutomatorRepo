using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Section
    {
        public Section()
        {
            BaseType = new HashSet<BaseType>();
            SectionDisciplineMap = new HashSet<SectionDisciplineMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BaseType> BaseType { get; set; }
        public virtual ICollection<SectionDisciplineMap> SectionDisciplineMap { get; set; }
    }
}
