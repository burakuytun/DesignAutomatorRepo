using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Device
    {
        public Device()
        {
            AssignedProduct = new HashSet<AssignedProduct>();
            ProductData = new HashSet<ProductData>();
        }

        public int Id { get; set; }
        public string DeviceName { get; set; }
        public int? TypeId { get; set; }
        public string Active { get; set; }
        public bool? IsAvailableForExternalUsers { get; set; }

        public virtual Type Type { get; set; }
        public virtual ICollection<AssignedProduct> AssignedProduct { get; set; }
        public virtual ICollection<ProductData> ProductData { get; set; }
    }
}
