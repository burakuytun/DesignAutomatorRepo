using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class TypeTagMap
    {
        public TypeTagMap()
        {
            Dna = new HashSet<Dna>();
        }

        public int Id { get; set; }
        public int? TypeId { get; set; }
        public int? TagId { get; set; }
        public bool? IsVisible { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<Dna> Dna { get; set; }
    }
}
