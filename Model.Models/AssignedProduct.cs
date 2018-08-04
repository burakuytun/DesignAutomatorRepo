using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class AssignedProduct
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? DeviceId { get; set; }
        public int? DnaclientId { get; set; }

        public virtual Device Device { get; set; }
        public virtual DnaClient Dnaclient { get; set; }
        public virtual Product Product { get; set; }
    }
}
