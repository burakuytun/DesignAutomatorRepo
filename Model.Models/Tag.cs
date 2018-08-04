using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Tag
    {
        public Tag()
        {
            TypeTagMap = new HashSet<TypeTagMap>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DataType { get; set; }
        public bool? IsLogical { get; set; }
        public string DefaultValue { get; set; }

        public virtual ICollection<TypeTagMap> TypeTagMap { get; set; }
    }
}
