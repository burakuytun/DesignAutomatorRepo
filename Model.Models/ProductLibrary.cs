using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class ProductLibrary
    {
        public ProductLibrary()
        {
            ProductLibDnaclient = new HashSet<ProductLibDnaclient>();
            ProductLibraryHeaders = new HashSet<ProductLibraryHeader>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? TypeId { get; set; }
        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<ProductLibDnaclient> ProductLibDnaclient { get; set; }
        public virtual ICollection<ProductLibraryHeader> ProductLibraryHeaders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
