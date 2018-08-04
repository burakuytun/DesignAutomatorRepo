using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            ProductLibrary = new HashSet<ProductLibrary>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductLibrary> ProductLibrary { get; set; }
    }
}
