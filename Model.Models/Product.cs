using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Product
    {
        public Product()
        {
            AssignedProduct = new HashSet<AssignedProduct>();
            ProductData = new HashSet<ProductData>();
            ProductHeaders = new HashSet<ProductHeader>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? ProductLibId { get; set; }

        public virtual ProductLibrary ProductLib { get; set; }
        public virtual ICollection<AssignedProduct> AssignedProduct { get; set; }
        public virtual ICollection<ProductData> ProductData { get; set; }
        public virtual ICollection<ProductHeader> ProductHeaders { get; set; }
    }
}
