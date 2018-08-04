using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class BaseType
    {
        public BaseType()
        {
            Types = new HashSet<Type>();
        }

        public int Id { get; set; }
        public int? SectionId { get; set; }
        public string Name { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<Type> Types { get; set; }
    }
}
