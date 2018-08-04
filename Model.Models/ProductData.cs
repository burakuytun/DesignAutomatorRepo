using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class ProductData
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? DnaclientId { get; set; }
        public int? DeviceId { get; set; }
        public string Header { get; set; }
        public string Value { get; set; }

        public virtual Device Device { get; set; }
        public virtual DnaClient Dnaclient { get; set; }
        public virtual Product Product { get; set; }
    }
}
